using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Services
{
    internal class AudioRecorderService
    {
        private readonly AudioDevicesListService _audioRecorder = new AudioDevicesListService();

        private IWaveIn _inputWasapiLoopbackCapture;
        private WasapiLoopbackCapture _outputWasapiLoopbackCapture;
        private WaveFileWriter _inputFileWriter;
        private WaveFileWriter _outputFileWriter;
        private string _inputFileName;
        private string _outputFileName;
        private string _mixFileName;
        private WaveFormat _wafeFormat;
        private DateTime _recordingStarted;

        public bool IsAudioRecording 
        { 
            get 
            { 
                return _inputWasapiLoopbackCapture != null || _outputWasapiLoopbackCapture != null;
            } 
        }
        public void StartRecording(string inputDeviceFriendlyName, string outputDeviceFriendlyName)
        {
            var recordingFolder = ApplicationData.Current.TemporaryFolder.Path;
            if (outputDeviceFriendlyName != null)
            {
                var outputDevice = _audioRecorder.GetOutputDevice(outputDeviceFriendlyName);
                _outputWasapiLoopbackCapture = new WasapiLoopbackCapture(outputDevice);
                _wafeFormat = _outputWasapiLoopbackCapture.WaveFormat;
                _outputWasapiLoopbackCapture.DataAvailable += OutputCallback;
                _outputFileName = Path.Combine(recordingFolder, $"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}-output.wav");
                _outputFileWriter = new WaveFileWriter(_outputFileName, _outputWasapiLoopbackCapture.WaveFormat);
            }

            if (inputDeviceFriendlyName != null)
            {
                var waveSource = new WaveInEvent();
                waveSource.DeviceNumber = FindWaveInDeviceName(inputDeviceFriendlyName);
                if (_wafeFormat != null)
                {
                    waveSource.WaveFormat = _wafeFormat;
                }
                _inputWasapiLoopbackCapture = waveSource;
                _inputWasapiLoopbackCapture.DataAvailable += InputCallback;
                _inputFileName = Path.Combine(recordingFolder, $"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}-input.wav");
                _inputFileWriter = new WaveFileWriter(_inputFileName, _wafeFormat ?? _inputWasapiLoopbackCapture.WaveFormat);
            }

            _recordingStarted = DateTime.Now;


            if (_inputWasapiLoopbackCapture != null)
            {
                _inputWasapiLoopbackCapture.StartRecording();
            }
            if (_outputWasapiLoopbackCapture != null)
            {
                _outputWasapiLoopbackCapture.StartRecording();
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
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            var fileFormatString = resourceLoader.GetString("RecordingFileName");
            var fileName = string.Format(fileFormatString,
                _recordingStarted.ToString("yyyy-MM-dd"),
                _recordingStarted.ToString("HH-mm-ss"),
                DateTime.Now.ToString("HH-mm-ss"));
            _mixFileName = Path.Combine(folderName, $"{fileName}.wav");

            if (_inputWasapiLoopbackCapture != null)
            {
                _inputWasapiLoopbackCapture.StopRecording();
                _inputWasapiLoopbackCapture.DataAvailable -= InputCallback;
                _inputWasapiLoopbackCapture.Dispose();
                _inputWasapiLoopbackCapture = null;
                _inputFileWriter.Dispose();
                _inputFileWriter = null;
            }

            if (_outputWasapiLoopbackCapture != null)
            {
                _outputWasapiLoopbackCapture.StopRecording();
                _outputWasapiLoopbackCapture.DataAvailable -= OutputCallback;
                _outputWasapiLoopbackCapture.Dispose();
                _outputWasapiLoopbackCapture = null;
                _outputFileWriter.Dispose();
                _outputFileWriter = null;
            }

            if (_inputFileName == null || _outputFileName == null)
            {
                CopyFile(_inputFileName ?? _outputFileName, _mixFileName);
            }
            else
            {
                MixFiles();
            }
        }

        private void CopyFile(string sourceFile, string destinationFile)
        {
            File.Copy(sourceFile, destinationFile, true);
        }

        private void MixFiles()
        {
            using (var mixer = new WaveMixerStream32 { AutoStop = true })
            using (var wav1 = new WaveFileReader(_inputFileName))
            using (var wav2 = new WaveFileReader(_outputFileName))
            { 
                mixer.AddInputStream(new WaveChannel32(wav1));
                mixer.AddInputStream(new WaveChannel32(wav2));
                WaveFileWriter.CreateWaveFile(_mixFileName, new Wave32To16Stream(mixer));
            }
        }

        private void InputCallback(object sender, WaveInEventArgs data)
        {
            _inputFileWriter.Write(data.Buffer, 0, data.BytesRecorded);
        }

        private void OutputCallback(object sender, WaveInEventArgs data)
        {
            _outputFileWriter.Write(data.Buffer, 0, data.BytesRecorded);
        }

        /*Resample! var paths = new[] {
    @"input1.wav",
    @"input2.wav",
    @"input3.wav"
};

// open all the input files
var readers = paths.Select(f => new WaveFileReader(f)).ToArray();

// choose the sample rate we will mix at
var maxSampleRate = readers.Max(r => r.WaveFormat.SampleRate);

// create the mixer inputs, resampling if necessary
var mixerInputs = readers.Select(r => r.WaveFormat.SampleRate == maxSampleRate ?
    r.ToSampleProvider() :
    new MediaFoundationResampler(r, WaveFormat.CreateIeeeFloatWaveFormat(maxSampleRate, r.WaveFormat.Channels)).ToSampleProvider());

// create the mixer
var mixer = new MixingSampleProvider(mixerInputs);

// write the mixed audio to a 16 bit WAV file
WaveFileWriter.CreateWaveFile16(@"d:\mixed.wav", mixer);

// clean up the readers
foreach(var reader in readers)
{
    reader.Dispose();
};*/
    }
}
