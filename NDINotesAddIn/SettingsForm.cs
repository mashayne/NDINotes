using System;
using System.Windows.Forms;
using NDINotesAddIn.Properties;

namespace NDINotesAddIn
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textSize.Value = Settings.Default.TextSize;
            textColor.Value = Settings.Default.TextColor;
            backgroundColor.Value = Settings.Default.BackgroundColor;
            ndiOutputToggle.Checked = Settings.Default.NDIOutput;
        }

        private void textSize_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.TextSize = (int)textSize.Value;
            Settings.Default.Save();
        }

        private void textColor_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.TextColor = (int)textColor.Value;
            Settings.Default.Save();
        }

        private void backgroundColor_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.BackgroundColor = (int)backgroundColor.Value;
            Settings.Default.Save();
        }

        private void ndiOutputToggle_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.NDIOutput = ndiOutputToggle.Checked;
            Settings.Default.Save();
        }
    }
}