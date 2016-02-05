using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace WebCamPassport
{
    public class WebCam
    {
        //private static bool DeviceExist = false;
        private static FilterInfoCollection VideoDevices;
        private static VideoCaptureDevice videoSource;
        private static ComboBox WebCamList;
        private static ComboBox WebCamSettings;
        private static PictureBox VideoImage;
        private static PictureBox VideoImageSend;

        //GetCamList
        public static void GetCamList(ComboBox c)
            
        {
            WebCamList = c;

            try
            {
                VideoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                WebCamList.Items.Clear();
                //DeviceExist = true;
                foreach (FilterInfo device in VideoDevices)
                {
                    WebCamList.Items.Add(device.Name);
                }
                WebCamList.SelectedIndex = 0; //First cam found is default
            }
            catch (ApplicationException)
            {
                //DeviceExist = false;
                WebCamList.Items.Add("No capture device on your system");
            }
        }

        //GetCamSettings
        public static void GetCamSettings(ComboBox c)
        {
            WebCamSettings = c;

            try
            {
                videoSource = new VideoCaptureDevice(VideoDevices[WebCamList.SelectedIndex].MonikerString);
                if (videoSource == null)
                    throw new ApplicationException();

                //DeviceExist = true;
                foreach (var capability in videoSource.VideoCapabilities)
                {
                    WebCamSettings.Items.Add(capability.FrameSize.ToString() + ":" + capability.MaximumFrameRate.ToString() + ":" + capability.BitCount.ToString());
                }

                WebCamSettings.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                //DeviceExist = false;
                WebCamSettings.Items.Add("No capture device on your system");
            }
        }

        //close the device safely
        public static void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.Stop();
                    videoSource = null;
                }
        }

        //Start WebCam

        public static void StartWebCam()
        {
            WebCam temp = new WebCam();
            videoSource = new VideoCaptureDevice(VideoDevices[WebCamList.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(temp.video_NewFrame);
            videoSource.VideoResolution = videoSource.VideoCapabilities[WebCamSettings.SelectedIndex];
            videoSource.Start();
        }

        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            VideoImage = new PictureBox();
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            VideoImage.Image = img;
            VideoImage.Invalidate();
            GC.Collect();
        }
        
        public static void GetVideoImage(PictureBox p)
        {
            VideoImageSend = new PictureBox();
            p = VideoImageSend;
            VideoImageSend.Image = VideoImage.Image;
        }
    }
}
