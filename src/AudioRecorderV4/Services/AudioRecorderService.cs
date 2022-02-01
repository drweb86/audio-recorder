using AudioRecorderV4.Services;
using AudioRecorderV4.Utils;
using HDE.Platform.Logging;
using NAudio.Lame;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.IO;
using System.Linq;
using Windows.Storage;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Services
{
    internal class AudioRecorderService
    {
        private readonly AudioDevicesListService _audioDevicesListService;
        private readonly ILog _log;

        public AudioRecorderService(AudioDevicesListService audioDevicesListService, ILog log)
        {
            _audioDevicesListService = audioDevicesListService;
            _log = log;
        }

        private IWaveIn _inputWasapiLoopbackCapture;
        private WaveFileWriter _inputFileWriter;
        private string _inputFileName;
        private string _outputFileName;
        private DateTime _recordingStarted;
        private DateTime _recordingEnded;
        private WasapiLoopbackRecordingJob _recordSpeakerJob;

        public bool IsAudioRecording 
        { 
            get 
            { 
                return _inputWasapiLoopbackCapture != null || _recordSpeakerJob != null;
            } 
        }
        public void StartRecording(string inputDeviceFriendlyName, string outputDeviceFriendlyName)
        {
            _log.Debug($"Start recording input {inputDeviceFriendlyName}, output {outputDeviceFriendlyName}");
            var recordingFolder = ApplicationData.Current.TemporaryFolder.Path;
            if (outputDeviceFriendlyName != null)
            {
                _outputFileName = Path.Combine(recordingFolder, $"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}-output.wav");
                _recordSpeakerJob = new WasapiLoopbackRecordingJob(_outputFileName, outputDeviceFriendlyName);
            }

            if (inputDeviceFriendlyName != null)
            {
                var waveSource = new WaveInEvent();
                waveSource.DeviceNumber = FindWaveInDeviceName(inputDeviceFriendlyName);
                _inputWasapiLoopbackCapture = waveSource;
                _inputWasapiLoopbackCapture.DataAvailable += InputCallback;
                _inputFileName = Path.Combine(recordingFolder, $"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}-input.wav");
                _inputFileWriter = new WaveFileWriter(_inputFileName, _inputWasapiLoopbackCapture.WaveFormat);
            }

            _recordingStarted = DateTime.Now;

            if (_inputWasapiLoopbackCapture != null)
            {
                _inputWasapiLoopbackCapture.StartRecording();
            }
            if (outputDeviceFriendlyName != null)
            {
                _recordSpeakerJob.Start();
            }
        }

        private int FindWaveInDeviceName(string inputDeviceFriendlyName)
        {
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var capabilities = WaveIn.GetCapabilities(i);
                if (capabilities.ProductName == inputDeviceFriendlyName.Substring(0, 31))
                {
                    return i;
                }
            }
            return 0;
        }

        public void StopRecording(string folderName)
        {
            _recordingEnded = DateTime.Now;

            if (_inputWasapiLoopbackCapture != null)
            {
                _inputWasapiLoopbackCapture.StopRecording();
                _inputWasapiLoopbackCapture.DataAvailable -= InputCallback;
                _inputWasapiLoopbackCapture.Dispose();
                _inputWasapiLoopbackCapture = null;
                _inputFileWriter.Flush();
                _inputFileWriter.Dispose();
                _inputFileWriter = null;
            }

            if (_recordSpeakerJob != null)
            {
                _recordSpeakerJob.Stop();
                _recordSpeakerJob = null;
            }

            string fileToConvert = null;
            if (_inputFileName == null || _outputFileName == null)
            {
                fileToConvert = _inputFileName ?? _outputFileName;
            }
            else
            {
                var temp = ApplicationData.Current.TemporaryFolder.Path;
                var mixedWaveFile = Path.Combine(temp, $"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}-mix.wav");

                MixFiles(_inputFileName, _outputFileName, mixedWaveFile);

                fileToConvert = mixedWaveFile;
            }

            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var outputMp3FileName = FileNameGenerator.GetOutputMp3FileName(_recordingStarted, _recordingEnded, folderName);
            ConvertWaveToMp3(fileToConvert, outputMp3FileName);
        }

        private void ConvertWaveToMp3(string sourceWaveFile, string destinationMp3File)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();

            var tag = new ID3TagData
            {
                Title = Path.GetFileNameWithoutExtension(destinationMp3File),
                Artist = Environment.UserName,
                Album = resourceLoader.GetString("AudioRecordings"),
                Year = _recordingEnded.Year.ToString(),
                Genre = resourceLoader.GetString("AudioRecording"),
            };

            using (var reader = new AudioFileReader(sourceWaveFile))
            using (var writer = new LameMP3FileWriter(destinationMp3File, reader.WaveFormat, 320, tag))
            {
                reader.CopyTo(writer);
            }
        }

        private void Dump(string file, WaveFormat wave)
        {
            _log.Debug($"Wave file 1 {file} format: SampleRate {wave.SampleRate}, Channels {wave.Channels}, ExtraSize {wave.ExtraSize}, AverageBytesPerSecond {wave.AverageBytesPerSecond}, Encoding {wave.Encoding}, BitsPerSample {wave.BitsPerSample}");
        }

        private void MixFiles(string inputWaveFile1, string inputWaveFile2, string resultWaveFile)
        {
            _log.Debug("Preparing to mix files using MediaFoundationResampler (required Vista+, Server with Windows Desktop Experience).");
            using (var stream1 = new FileStream(inputWaveFile1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var stream2 = new FileStream(inputWaveFile2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader1 = new WaveFileReader(stream1))
            using (var reader2 = new WaveFileReader(stream2))
            {
                var waveFormats = new[] { reader1.WaveFormat, reader2.WaveFormat };
                Dump(inputWaveFile1, reader1.WaveFormat);
                Dump(inputWaveFile2, reader2.WaveFormat);

                var maxChannels = waveFormats.Max(formats => formats.Channels);
                var maxRate = waveFormats.Max(formats => formats.SampleRate);

                var maxAllowedRate = 48000;
                var maxAllowedChannels = 2;
                var outputFormat = new WaveFormat(
                    maxRate > maxAllowedRate ? maxAllowedRate : maxRate,
                    16,
                    maxChannels > maxAllowedChannels ? maxAllowedChannels : maxChannels);
                Dump(resultWaveFile, outputFormat);

                var maxQuality = 60;
                try
                {
                    using (var resampler1 = new MediaFoundationResampler(reader1, outputFormat) { ResamplerQuality = maxQuality })
                    using (var resampler2 = new MediaFoundationResampler(reader2, outputFormat) { ResamplerQuality = maxQuality })
                    {
                        var resamplers = new[]
                        {
                        resampler1.ToSampleProvider(),
                        resampler2.ToSampleProvider()
                    };

                        var mixer = new MixingSampleProvider(resamplers);

                        WaveFileWriter.CreateWaveFile16(resultWaveFile, mixer);
                    }
                }
                catch (Exception e)
                {
                    _log.Error(e);
                    throw;
                }
            }
        }

        private void InputCallback(object sender, WaveInEventArgs data)
        {
            _inputFileWriter.Write(data.Buffer, 0, data.BytesRecorded);
        }
    }
}
