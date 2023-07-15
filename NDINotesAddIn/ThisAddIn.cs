```csharp
using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using NDINotesAddIn.Properties;

namespace NDINotesAddIn
{
    public partial class ThisAddIn
    {
        private SlideNotesExtractor slideNotesExtractor;
        private NDIOutput ndiOutput;
        private SettingsForm settingsForm;
        private Ribbon1 ribbon;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            slideNotesExtractor = new SlideNotesExtractor();
            ndiOutput = new NDIOutput(Settings.Default.NDINotes);
            settingsForm = new SettingsForm();

            Application.SlideShowNextSlide += new ApplicationEvents2_SlideShowNextSlideEventHandler(SlideShowNextSlide);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            ndiOutput.Dispose();
        }

        private void SlideShowNextSlide(SlideShowWindow Wn)
        {
            string currentSlideNotes = slideNotesExtractor.GetNotesFromSlide(Wn.View.Slide);
            ndiOutput.Send(currentSlideNotes);
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            ribbon = new Ribbon1();
            ribbon.ToggleNDIOutput += new EventHandler(ToggleNDIOutput);
            ribbon.UpdateTextSize += new EventHandler(UpdateTextSize);
            ribbon.UpdateTextColor += new EventHandler(UpdateTextColor);
            ribbon.UpdateBackgroundColor += new EventHandler(UpdateBackgroundColor);
            return Globals.Factory.GetRibbonFactory().CreateRibbonManager(new IRibbonExtension[] { ribbon });
        }

        private void ToggleNDIOutput(object sender, EventArgs e)
        {
            ndiOutput.ToggleOutput();
        }

        private void UpdateTextSize(object sender, EventArgs e)
        {
            ndiOutput.TextSize = settingsForm.TextSize;
        }

        private void UpdateTextColor(object sender, EventArgs e)
        {
            ndiOutput.TextColor = settingsForm.TextColor;
        }

        private void UpdateBackgroundColor(object sender, EventArgs e)
        {
            ndiOutput.BackgroundColor = settingsForm.BackgroundColor;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
```