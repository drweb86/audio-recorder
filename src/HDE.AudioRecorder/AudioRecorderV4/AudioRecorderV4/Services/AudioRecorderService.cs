using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool IsAudioRecording 
        { 
            get 
            { 
                return _inputWasapiLoopbackCapture != null;
            } 
        }
        public string StartRecording(string inputDeviceFriendlyName, string outputDeviceFriendlyName, string folderName)
        {
            var outputDevice = _audioRecorder.GetOutputDevice(outputDeviceFriendlyName);
            _outputWasapiLoopbackCapture = new WasapiLoopbackCapture(outputDevice);
            _wafeFormat = _outputWasapiLoopbackCapture.WaveFormat;
            _outputWasapiLoopbackCapture.DataAvailable += OutputCallback;

            var waveSource = new WaveInEvent();
            waveSource.DeviceNumber = FindWaveInDeviceName(inputDeviceFriendlyName);
            waveSource.WaveFormat = _wafeFormat;
            _inputWasapiLoopbackCapture = waveSource;
            _inputWasapiLoopbackCapture.DataAvailable += InputCallback;

            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            _inputFileName = Path.Combine(folderName, $"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}-input.wav");
            _inputFileWriter = new WaveFileWriter(_inputFileName, _wafeFormat);

            _outputFileName = Path.Combine(folderName, $"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}-output.wav");
            _outputFileWriter = new WaveFileWriter(_outputFileName, _wafeFormat);

            _mixFileName = Path.Combine(folderName, $"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}.wav");

            _inputWasapiLoopbackCapture.StartRecording();
            _outputWasapiLoopbackCapture.StartRecording();

            return _mixFileName;
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

        public void StopRecording()
        {
            _inputWasapiLoopbackCapture.StopRecording();
            _inputWasapiLoopbackCapture.DataAvailable -= InputCallback;
            _inputWasapiLoopbackCapture.Dispose();
            _inputWasapiLoopbackCapture = null;
            _inputFileWriter.Dispose();
            _inputFileWriter = null;

            _outputWasapiLoopbackCapture.StopRecording();
            _outputWasapiLoopbackCapture.DataAvailable -= OutputCallback;
            _outputWasapiLoopbackCapture.Dispose();
            _outputWasapiLoopbackCapture = null;
            _outputFileWriter.Dispose();
            _outputFileWriter = null;

            MixFiles();
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
