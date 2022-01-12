namespace HDE.AudioRecorder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void _mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _recordingTabPage_Click(object sender, EventArgs e)
        {

        }

        private void OnLoad(object sender, EventArgs e)
        {
            _audioInputDeviceComboBox.BeginUpdate();
            _audioInputDeviceComboBox.Items.Clear();
            _audioInputDeviceComboBox.Items.AddRange(Program.Controller.Model.InputDevices.ToArray());
            _audioInputDeviceComboBox.SelectedItem = Program.Controller.Model.DefaultInputDevice;
            _audioInputDeviceComboBox.EndUpdate();

            _audioOutputDeviceComboBox.BeginUpdate();
            _audioOutputDeviceComboBox.Items.Clear();
            _audioOutputDeviceComboBox.Items.AddRange(Program.Controller.Model.OutputDevices.ToArray());
            _audioOutputDeviceComboBox.SelectedItem = Program.Controller.Model.DefaultOutputDevice;
            _audioOutputDeviceComboBox.EndUpdate();

            _outputFolderTextBox.Text = Program.Controller.Model.OutputFolder;
        }
    }
}