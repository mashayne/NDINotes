```csharp
using System;
using Microsoft.Office.Interop.PowerPoint;

namespace NDINotesAddIn
{
    public class SlideNotesExtractor
    {
        public string CurrentSlideNotes { get; private set; }

        public SlideNotesExtractor()
        {
            CurrentSlideNotes = string.Empty;
        }

        public void ExtractNotesFromCurrentSlide(Slide slide)
        {
            if (slide == null)
            {
                throw new ArgumentNullException(nameof(slide));
            }

            if (slide.NotesPage != null && slide.NotesPage.Shapes.Count > 0)
            {
                foreach (Shape shape in slide.NotesPage.Shapes)
                {
                    if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
                        {
                            CurrentSlideNotes += shape.TextFrame.TextRange.Text;
                        }
                    }
                }
            }
        }
    }
}
```