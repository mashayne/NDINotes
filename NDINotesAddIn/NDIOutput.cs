```csharp
using System;
using NewTek.NDI;

namespace NDINotesAddIn
{
    public class NDIOutput
    {
        private Send _ndiSend;
        private string _ndiName;

        public NDIOutput(string ndiName)
        {
            _ndiName = ndiName;
            _ndiSend = new Send(CreateSendSettings(), true);
        }

        private Send.Settings CreateSendSettings()
        {
            return new Send.Settings
            {
                NDIlib_send_create_t = new NDIlib_send_create_t
                {
                    p_ndi_name = _ndiName,
                    clock_video = true,
                    clock_audio = false
                }
            };
        }

        public void SendNotes(string notes)
        {
            var frame = new VideoFrame(1920, 1080, NDIlib_FourCC_type_e.NDIlib_FourCC_type_RGBA_BGRA, (byte[])null);
            frame.FrameMetadata = notes;
            _ndiSend.SendVideo(frame);
        }

        public void Dispose()
        {
            _ndiSend.Dispose();
        }
    }
}
```