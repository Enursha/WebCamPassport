using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebCamPassport
{
    public partial class Form1 : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        int cropX, cropY, cropWidth, cropHeight;

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
        private void takePicture_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            CloseVideoSource();
            label2.Text = "Device stopped.";
            start.Text = "&Start";
        }

        //Mouse Up
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (cropWidth < 1)
            {
                return;
            }
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap bit = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
            Bitmap crop = new Bitmap(cropWidth, cropHeight);
            //Graphics gfx = Graphics.FromImage(crop);
            //gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;//here add  System.Drawing.Drawing2D namespace;
            //gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;//here add  System.Drawing.Drawing2D namespace;
            //gfx.CompositingQuality = CompositingQuality.HighQuality;//here add  System.Drawing.Drawing2D namespace;
            //gfx.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
            //snapShot.Image = crop;
            pictureBox1.Refresh();
        }

        // Mouse Move
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (pictureBox1.Image == null)
            // return;

            if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
            {
                pictureBox1.Refresh();
                cropWidth = e.X - cropX;
                cropHeight = e.Y - cropY;
            }
            pictureBox1.Refresh();
        }
        
        //here rectangle border pen color=red and size=2;
        Pen borderpen = new Pen(Color.Red, 2);
        //fill the rectangle color =white
        SolidBrush rectbrush = new SolidBrush(Color.FromArgb(100, Color.White));

        //Paint
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Graphics gfx = e.Graphics;
            gfx.DrawRectangle(borderpen, rect);
            gfx.FillRectangle(rectbrush, rect);
        }

        //Mouse Down
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
            {
                pictureBox1.Refresh();
                cropX = e.X;
                cropY = e.Y;
                Cursor = Cursors.Cross;
             }
            pictureBox1.Refresh();
        }

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