using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

namespace WebCamPassport
{
    public partial class Form1 : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public Form1()
        {
            InitializeComponent();
            getCamList();
            getCamSettings();

        }

        // get the devices name
        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                comboBox1.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
                comboBox1.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                comboBox1.Items.Add("No capture device on your system");
            }
        }


        #region Get Camera Settings
        private void getCamSettings()
        {
            try
            {
                videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                if (videoSource == null)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (var capability in videoSource.VideoCapabilities)
                {
                    comboBox2.Items.Add(capability.FrameSize.ToString() + ":" + capability.MaximumFrameRate.ToString() + ":" + capability.BitCount.ToString());
                }

                comboBox2.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                comboBox2.Items.Add("No capture device on your system");
            }
        }
        #endregion

        //refresh button
        private void rfsh_Click(object sender, EventArgs e)
        {
            getCamList();
            getCamSettings();
        }

        //toggle start and stop button
        private void start_Click(object sender, EventArgs e)
        {
            if (start.Text == "&Start")
            {
                if (DeviceExist)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    videoSource.VideoResolution = videoSource.VideoCapabilities[comboBox2.SelectedIndex];
                    videoSource.Start();
                    label2.Text = "Device running...";
                    start.Text = "&Stop";
                    timer1.Enabled = true;
                }
                else
                {
                    label2.Text = "Error: No Device selected.";
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer1.Enabled = false;
                    CloseVideoSource();
                    label2.Text = "Device stopped.";
                    start.Text = "&Start";

                    pictureBox1.Image = null;
                }
            }
        }

        //take picture button
        private void takePicture_Click(object sender, EventArgs e) { }
        //{
        //    apFrame;
        //}
        //private void apFrame()
        //{
        
        //    Bitmap img = (Bitmap).Clone();
        //    //do processing here
        //    snapShot.Image = img;
        //}
    
    
        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var img = (Bitmap)eventArgs.Frame.Clone();
            //do processing here
            if (pictureBox1.Image != null) {
               pictureBox1.Image.Dispose();
               
            }
            pictureBox1.Image = img;
                
            
        }

        //close the device safely
        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.Stop();
                    videoSource = null;
                }
        }

        //get total received frame at 1 second tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Device running... " + videoSource.FramesReceived.ToString() + " FPS";
        }

        //prevent sudden close while device is running
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
        }

        
    }
}