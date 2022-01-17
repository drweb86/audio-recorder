namespace HDE.AudioRecorder
{
    partial class ShellMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainTabControl = new System.Windows.Forms.TabControl();
            this._recordingTabPage = new System.Windows.Forms.TabPage();
            this._linkFileLinkLabel = new System.Windows.Forms.LinkLabel();
            this._startRecordingButton = new System.Windows.Forms.Button();
            this._settingsTabPage = new System.Windows.Forms.TabPage();
            this._mainSettingsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._inputDeviceLabel = new System.Windows.Forms.Label();
            this._chooseOutputDeviceLabel = new System.Windows.Forms.Label();
            this._outputFoldersLabel = new System.Windows.Forms.Label();
            this._audioOutputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this._audioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this._outputFolderTextBox = new System.Windows.Forms.TextBox();
            this._shellTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._shellMenuStrip = new System.Windows.Forms.MenuStrip();
            this._mainTabControl.SuspendLayout();
            this._recordingTabPage.SuspendLayout();
            this._settingsTabPage.SuspendLayout();
            this._mainSettingsTableLayoutPanel.SuspendLayout();
            this._shellTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTabControl
            // 
            this._mainTabControl.Controls.Add(this._recordingTabPage);
            this._mainTabControl.Controls.Add(this._settingsTabPage);
            this._mainTabControl.Location = new System.Drawing.Point(595, 117);
            this._mainTabControl.Name = "_mainTabControl";
            this._mainTabControl.SelectedIndex = 0;
            this._mainTabControl.Size = new System.Drawing.Size(569, 315);
            this._mainTabControl.TabIndex = 0;
            // 
            // _recordingTabPage
            // 
            this._recordingTabPage.Controls.Add(this._linkFileLinkLabel);
            this._recordingTabPage.Controls.Add(this._startRecordingButton);
            this._recordingTabPage.Location = new System.Drawing.Point(4, 24);
            this._recordingTabPage.Name = "_recordingTabPage";
            this._recordingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._recordingTabPage.Size = new System.Drawing.Size(561, 287);
            this._recordingTabPage.TabIndex = 0;
            this._recordingTabPage.Text = "Recording";
            this._recordingTabPage.UseVisualStyleBackColor = true;
            // 
            // _linkFileLinkLabel
            // 
            this._linkFileLinkLabel.AutoSize = true;
            this._linkFileLinkLabel.Location = new System.Drawing.Point(37, 139);
            this._linkFileLinkLabel.Name = "_linkFileLinkLabel";
            this._linkFileLinkLabel.Size = new System.Drawing.Size(60, 15);
            this._linkFileLinkLabel.TabIndex = 1;
            this._linkFileLinkLabel.TabStop = true;
            this._linkFileLinkLabel.Text = "linkLabel1";
            this._linkFileLinkLabel.Visible = false;
            this._linkFileLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkFileLinkLabel_LinkClicked);
            // 
            // _startRecordingButton
            // 
            this._startRecordingButton.Location = new System.Drawing.Point(37, 41);
            this._startRecordingButton.Name = "_startRecordingButton";
            this._startRecordingButton.Size = new System.Drawing.Size(136, 82);
            this._startRecordingButton.TabIndex = 0;
            this._startRecordingButton.Text = "Record";
            this._startRecordingButton.UseVisualStyleBackColor = true;
            this._startRecordingButton.Click += new System.EventHandler(this._startRecordingButton_Click);
            // 
            // _settingsTabPage
            // 
            this._settingsTabPage.Controls.Add(this._mainSettingsTableLayoutPanel);
            this._settingsTabPage.Location = new System.Drawing.Point(4, 24);
            this._settingsTabPage.Name = "_settingsTabPage";
            this._settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._settingsTabPage.Size = new System.Drawing.Size(561, 287);
            this._settingsTabPage.TabIndex = 1;
            this._settingsTabPage.Text = "Settings";
            this._settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // _mainSettingsTableLayoutPanel
            // 
            this._mainSettingsTableLayoutPanel.ColumnCount = 2;
            this._mainSettingsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.27791F));
            this._mainSettingsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.72209F));
            this._mainSettingsTableLayoutPanel.Controls.Add(this._inputDeviceLabel, 0, 0);
            this._mainSettingsTableLayoutPanel.Controls.Add(this._chooseOutputDeviceLabel, 0, 1);
            this._mainSettingsTableLayoutPanel.Controls.Add(this._outputFoldersLabel, 0, 2);
            this._mainSettingsTableLayoutPanel.Controls.Add(this._audioOutputDeviceComboBox, 1, 1);
            this._mainSettingsTableLayoutPanel.Controls.Add(this._audioInputDeviceComboBox, 1, 0);
            this._mainSettingsTableLayoutPanel.Controls.Add(this._outputFolderTextBox, 1, 2);
            this._mainSettingsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainSettingsTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this._mainSettingsTableLayoutPanel.Name = "_mainSettingsTableLayoutPanel";
            this._mainSettingsTableLayoutPanel.RowCount = 4;
            this._mainSettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainSettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainSettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainSettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainSettingsTableLayoutPanel.Size = new System.Drawing.Size(555, 281);
            this._mainSettingsTableLayoutPanel.TabIndex = 0;
            // 
            // _inputDeviceLabel
            // 
            this._inputDeviceLabel.AutoSize = true;
            this._inputDeviceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inputDeviceLabel.Location = new System.Drawing.Point(3, 0);
            this._inputDeviceLabel.Name = "_inputDeviceLabel";
            this._inputDeviceLabel.Size = new System.Drawing.Size(123, 30);
            this._inputDeviceLabel.TabIndex = 0;
            this._inputDeviceLabel.Text = "Choose audio input device:";
            this._inputDeviceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _chooseOutputDeviceLabel
            // 
            this._chooseOutputDeviceLabel.AutoSize = true;
            this._chooseOutputDeviceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chooseOutputDeviceLabel.Location = new System.Drawing.Point(3, 30);
            this._chooseOutputDeviceLabel.Name = "_chooseOutputDeviceLabel";
            this._chooseOutputDeviceLabel.Size = new System.Drawing.Size(123, 30);
            this._chooseOutputDeviceLabel.TabIndex = 1;
            this._chooseOutputDeviceLabel.Text = "Choose audio output device:";
            this._chooseOutputDeviceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _outputFoldersLabel
            // 
            this._outputFoldersLabel.AutoSize = true;
            this._outputFoldersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._outputFoldersLabel.Location = new System.Drawing.Point(3, 60);
            this._outputFoldersLabel.Name = "_outputFoldersLabel";
            this._outputFoldersLabel.Size = new System.Drawing.Size(123, 30);
            this._outputFoldersLabel.TabIndex = 2;
            this._outputFoldersLabel.Text = "Save recordings to folder:";
            this._outputFoldersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _audioOutputDeviceComboBox
            // 
            this._audioOutputDeviceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._audioOutputDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._audioOutputDeviceComboBox.FormattingEnabled = true;
            this._audioOutputDeviceComboBox.Location = new System.Drawing.Point(132, 33);
            this._audioOutputDeviceComboBox.Name = "_audioOutputDeviceComboBox";
            this._audioOutputDeviceComboBox.Size = new System.Drawing.Size(420, 23);
            this._audioOutputDeviceComboBox.TabIndex = 4;
            // 
            // _audioInputDeviceComboBox
            // 
            this._audioInputDeviceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._audioInputDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._audioInputDeviceComboBox.FormattingEnabled = true;
            this._audioInputDeviceComboBox.Location = new System.Drawing.Point(132, 3);
            this._audioInputDeviceComboBox.Name = "_audioInputDeviceComboBox";
            this._audioInputDeviceComboBox.Size = new System.Drawing.Size(420, 23);
            this._audioInputDeviceComboBox.TabIndex = 5;
            // 
            // _outputFolderTextBox
            // 
            this._outputFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._outputFolderTextBox.Location = new System.Drawing.Point(132, 63);
            this._outputFolderTextBox.Name = "_outputFolderTextBox";
            this._outputFolderTextBox.Size = new System.Drawing.Size(420, 23);
            this._outputFolderTextBox.TabIndex = 3;
            // 
            // _shellTabControl
            // 
            this._shellTabControl.Controls.Add(this.tabPage1);
            this._shellTabControl.Location = new System.Drawing.Point(23, 51);
            this._shellTabControl.Name = "_shellTabControl";
            this._shellTabControl.SelectedIndex = 0;
            this._shellTabControl.Size = new System.Drawing.Size(433, 262);
            this._shellTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _shellMenuStrip
            // 
            this._shellMenuStrip.Location = new System.Drawing.Point(0, 0);
            this._shellMenuStrip.Name = "_shellMenuStrip";
            this._shellMenuStrip.Size = new System.Drawing.Size(1215, 24);
            this._shellMenuStrip.TabIndex = 2;
            this._shellMenuStrip.Text = "menuStrip1";
            // 
            // ShellMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 453);
            this.Controls.Add(this._shellTabControl);
            this.Controls.Add(this._mainTabControl);
            this.Controls.Add(this._shellMenuStrip);
            this.MainMenuStrip = this._shellMenuStrip;
            this.Name = "ShellMainForm";
            this.Text = "Recording Conference Calls ( https://github.com/drweb86/audio-recorder )";
            this.Load += new System.EventHandler(this.OnLoad);
            this._mainTabControl.ResumeLayout(false);
            this._recordingTabPage.ResumeLayout(false);
            this._recordingTabPage.PerformLayout();
            this._settingsTabPage.ResumeLayout(false);
            this._mainSettingsTableLayoutPanel.ResumeLayout(false);
            this._mainSettingsTableLayoutPanel.PerformLayout();
            this._shellTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl _mainTabControl;
        private TabPage _recordingTabPage;
        private TabPage _settingsTabPage;
        private Button _startRecordingButton;
        private TableLayoutPanel _mainSettingsTableLayoutPanel;
        private Label _inputDeviceLabel;
        private Label _chooseOutputDeviceLabel;
        private Label _outputFoldersLabel;
        private ComboBox _audioOutputDeviceComboBox;
        private ComboBox _audioInputDeviceComboBox;
        private TextBox _outputFolderTextBox;
        private LinkLabel _linkFileLinkLabel;
        private TabControl _shellTabControl;
        private TabPage tabPage1;
        private MenuStrip _shellMenuStrip;
    }
}