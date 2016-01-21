﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;


namespace WebCamPassport
{
    public partial class Form1 : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        UserRect cropBox;
        Bitmap croppedbmp;
        

        public Form1()
        {
            InitializeComponent();
            getCamList();
            getCamSettings();
            comboBox3.Items.Add("Passport");
            comboBox3.SelectedIndex = 0;
            
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
                comboBox1.SelectedIndex = 0; //make default to first cam
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
        private void takePic_Click(object sender, EventArgs e)
        {
            Point p = cropBox.rect.Location;
            Point unscaled_p = new Point();
            int unscaled_height;
            int unscaled_width;

            // image and container dimensions
            int w_i = pictureBox1.Image.Width;
            int h_i = pictureBox1.Image.Height;
            int w_c = pictureBox1.Width;
            int h_c = pictureBox1.Height;

            float imageRatio = w_i / (float)h_i; // image W:H ratio
            float containerRatio = w_c / (float)h_c; // container W:H ratio

            if (imageRatio >= containerRatio)
            {
                // horizontal image
                float scaleFactor = w_c / (float)w_i;
                float scaledHeight = h_i * scaleFactor;
                // calculate gap between top of container and top of image
                float filler = Math.Abs(h_c - scaledHeight) / 2;
                unscaled_p.X = (int)(p.X / scaleFactor);
                unscaled_p.Y = (int)((p.Y - filler) / scaleFactor);
                unscaled_width = (int)(cropBox.rect.Width / scaleFactor);
                unscaled_height = (int)(cropBox.rect.Height / scaleFactor);
            }
            else
            {
                // vertical image
                float scaleFactor = h_c / (float)h_i;
                float scaledWidth = w_i * scaleFactor;
                float filler = Math.Abs(w_c - scaledWidth) / 2;
                unscaled_p.X = (int)((p.X - filler) / scaleFactor);
                unscaled_p.Y = (int)(p.Y / scaleFactor);
                unscaled_width = (int)(cropBox.rect.Width / scaleFactor);
                unscaled_height = (int)(cropBox.rect.Height / scaleFactor);
            }


            label1.Text = unscaled_p.X.ToString() + " " + unscaled_p.Y.ToString() + " " + unscaled_width.ToString() + " " + unscaled_height.ToString();
            Rectangle cropBoxUnscaled = new Rectangle(unscaled_p.X, unscaled_p.Y, unscaled_width, unscaled_height);
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            croppedbmp = bmp.Clone(cropBoxUnscaled, bmp.PixelFormat);
            snapShot.Image = croppedbmp;
            snapShot.Invalidate();
        }


        #region Box

        private void Box()
        {
            
        }

        #endregion

        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = img;
            pictureBox1.Invalidate();
            GC.Collect();
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

        //Begin Crop
        private void cropPic_Click(object sender, EventArgs e)
        {
            cropBox = new UserRect(new Rectangle(10, 10, 45, 55));
            cropBox.SetPictureBox(pictureBox1);
            pictureBox1.Refresh();
            cropBox.ratio = 1.33f;
            cropBox.allowDeformingDuringMovement = true;
            timer1.Enabled = false;
            CloseVideoSource();
            label2.Text = "Device stopped.";
            start.Text = "&Start";
        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                snapShot.Image.Save(sfd.FileName, format);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = snapShot.Image;
        }
    }
}