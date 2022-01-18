using HDE.AudioRecorder.Tools.AudioRecorder.Controller;
using HDE.AudioRecorder.Tools.AudioRecorder.Views;
using HDE.Platform.AspectOrientedFramework.WinForms;

namespace HDE.AudioRecorder.Tools.AudioRecorder
{
    public class AudioRecorderTool: ToolBase
    {
        #region Fields

        private AudioRecorderToolController _controller;
        private TabPage _tabPage;
        private AudioRecorderToolViewUserControl _mainView;

        #endregion

        public override void Activate()
        {
            base.Activate();

            if (_controller == null)
            {
                _controller = new AudioRecorderToolController(Log);
                _controller.Initialize();
                _tabPage = new TabPage(ToolName);
                _mainView = new AudioRecorderToolViewUserControl { Dock = DockStyle.Fill };
                _mainView.Init(_controller);
                _tabPage.Controls.Add(_mainView);
                TabControl.TabPages.Add(_tabPage);
                TabControl.SelectTab(_tabPage);
            }
            else // Select tab page.
            {
                TabControl.SelectTab(_tabPage);
            }
        }

        public override void Dispose()
        {
            if (_controller != null)
            {
                _mainView.TearDown();
                _mainView = null;
                _controller.Dispose();
                _controller = null;
                TabControl.TabPages.Remove(_tabPage);
                _tabPage = null;
                base.Dispose();
            }
        }
    }
}
