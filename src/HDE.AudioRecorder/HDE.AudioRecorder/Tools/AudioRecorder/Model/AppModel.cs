using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDE.AudioRecorder.Model
{
    internal class AppModel
    {
        public List<string> InputDevices { get; internal set; }
        public List<string> OutputDevices { get; internal set; }
        public string DefaultOutputDevice { get; internal set; }
        public string DefaultInputDevice { get; internal set; }
        public string OutputFolder { get; internal set; }
    }
}
