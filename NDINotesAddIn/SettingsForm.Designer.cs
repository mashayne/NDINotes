namespace NDINotesAddIn
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button toggleNDIOutput;
        private System.Windows.Forms.NumericUpDown textSizeControl;
        private System.Windows.Forms.ColorDialog textColorControl;
        private System.Windows.Forms.ColorDialog backgroundColorControl;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.toggleNDIOutput = new System.Windows.Forms.Button();
            this.textSizeControl = new System.Windows.Forms.NumericUpDown();
            this.textColorControl = new System.Windows.Forms.ColorDialog();
            this.backgroundColorControl = new System.Windows.Forms.ColorDialog();

            ((System.ComponentModel.ISupportInitialize)(this.textSizeControl)).BeginInit();

            this.toggleNDIOutput.Text = "Toggle NDI Output";
            this.toggleNDIOutput.Click += new System.EventHandler(this.ToggleNDIOutput_Click);

            this.textSizeControl.Minimum = 1;
            this.textSizeControl.Maximum = 100;
            this.textSizeControl.Value = Settings.Default.TextSize;
            this.textSizeControl.ValueChanged += new System.EventHandler(this.TextSizeControl_ValueChanged);

            this.Controls.Add(this.toggleNDIOutput);
            this.Controls.Add(this.textSizeControl);

            ((System.ComponentModel.ISupportInitialize)(this.textSizeControl)).EndInit();

            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
        }

        private void ToggleNDIOutput_Click(object sender, System.EventArgs e)
        {
            Settings.Default.NDIOutputEnabled = !Settings.Default.NDIOutputEnabled;
            Settings.Default.Save();
        }

        private void TextSizeControl_ValueChanged(object sender, System.EventArgs e)
        {
            Settings.Default.TextSize = (int)this.textSizeControl.Value;
            Settings.Default.Save();
        }

        private void SettingsForm_Load(object sender, System.EventArgs e)
        {
            this.textSizeControl.Value = Settings.Default.TextSize;
        }
    }
}