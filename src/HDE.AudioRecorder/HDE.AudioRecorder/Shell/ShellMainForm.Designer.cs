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
            this._shellTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._shellMenuStrip = new System.Windows.Forms.MenuStrip();
            this._shellTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // _shellTabControl
            // 
            this._shellTabControl.Controls.Add(this.tabPage1);
            this._shellTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._shellTabControl.Location = new System.Drawing.Point(0, 24);
            this._shellTabControl.Name = "_shellTabControl";
            this._shellTabControl.SelectedIndex = 0;
            this._shellTabControl.Size = new System.Drawing.Size(1215, 429);
            this._shellTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1207, 401);
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
            this.Controls.Add(this._shellMenuStrip);
            this.MainMenuStrip = this._shellMenuStrip;
            this.Name = "ShellMainForm";
            this.Text = "Recording Conference Calls ( https://github.com/drweb86/audio-recorder )";
            this._shellTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TabControl _shellTabControl;
        private TabPage tabPage1;
        private MenuStrip _shellMenuStrip;
    }
}