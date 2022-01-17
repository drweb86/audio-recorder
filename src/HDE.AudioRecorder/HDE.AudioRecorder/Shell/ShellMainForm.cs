using HDE.Platform.AspectOrientedFramework.WinForms;

namespace HDE.AudioRecorder
{
    public partial class ShellMainForm : Form, IMainFormView
    {
        public TabControl TabControl
        {
            get { return _shellTabControl; }
        }

        public MenuStrip MainMenu
        {
            get { return _shellMenuStrip; }
        }

        public void SetController(object controller)
        {
            FixVs2022BugCantRemoveFirstTab();
            HideTabControlHeader();
            MainMenu.Visible = false; // because single tool.
        }

        private void FixVs2022BugCantRemoveFirstTab()
        {
            TabControl.TabPages.Remove(tabPage1);
        }

        private void HideTabControlHeader()
        {
            TabControl.Appearance = TabAppearance.FlatButtons;
            TabControl.ItemSize = new Size(0, 1);
            TabControl.SizeMode = TabSizeMode.Fixed;
        }

        public ShellMainForm()
        {
            InitializeComponent();
        }
    }
}