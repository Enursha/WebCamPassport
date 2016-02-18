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
        public static FilterInfoCollection VideoDevices;
        public static VideoCaptureDevice videoSource;
        private static ComboBox WebCamList;
        private static ComboBox WebCamSettings;
        public static PictureBox VideoImage;

        //GetCamList
        public static void GetCamListCombobox(ComboBox c)
            
        {
            WebCamList = c;

            try
            {
                VideoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                WebCamList.Items.Clear();

                foreach (FilterInfo device in VideoDevices)
                {
                    WebCamList.Items.Add(device.Name);
                }

                if (Properties.Settings.Default.WebCamDevice == null)
                {
                    WebCamList.SelectedIndex = 0; //First cam found is default
                }
                else
                {
                    WebCamList.SelectedIndex = WebCamList.FindString(Properties.Settings.Default.WebCamDevice);
                }
            }
            catch (ApplicationException)
            {
                //DeviceExist = false;
                WebCamList.Items.Add("No capture device on your system");
            }
        }

        //GetCamSettings
        public static void GetCamSettingsCombobox(ComboBox c)
        {
            WebCamSettings = c;

            try
            {
                videoSource = new VideoCaptureDevice(VideoDevices[WebCamList.SelectedIndex].MonikerString);
                WebCamSettings.Items.Clear();
                //DeviceExist = true;
                foreach (var capability in videoSource.VideoCapabilities)
                {
                    WebCamSettings.Items.Add(capability.FrameSize.ToString() + ":" + capability.MaximumFrameRate.ToString() + ":" + capability.BitCount.ToString());
                }

                if (Properties.Settings.Default.WebCamResolution == null || Properties.Settings.Default.WebCamDevice != Convert.ToString(WebCamList.SelectedItem))
                {
                    WebCamSettings.SelectedIndex = 0;
                }
                else
                {
                    WebCamSettings.SelectedIndex = WebCamSettings.FindString(Properties.Settings.Default.WebCamResolution);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //DeviceExist = false;
                WebCamSettings.Items.Add("No capture device on your system");
            }
        }

        //close the device safely
        public static void CloseVideoSource()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }


        //Start WebCam

        public static void StartWebCam()
        {
            try
            {
                //WebCam temp = new WebCam();
                videoSource = new VideoCaptureDevice(VideoDevices[WebCamList.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.VideoResolution = videoSource.VideoCapabilities[WebCamSettings.SelectedIndex];
                videoSource.Start();
            }
            catch(ArgumentOutOfRangeException)
            {
                string message = "No Web Camera Detected.";
                    string caption = "Fail State";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                //if (result == System.Windows.Forms.DialogResult.OK)
                //{
                //    this.Close();
                //}
            }
        }

        //eventhandler if new frame is ready
        public static void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            VideoImage.Image = img;
            VideoImage.Invalidate();
            GC.Collect();
        }

        public static void GetVideoImage(PictureBox p)
        {
          VideoImage = p;
        }
    }
}
