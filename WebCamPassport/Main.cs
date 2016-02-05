using System;
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
    public partial class Main : Form
    {
       
        CropBox cropBox;
        Bitmap croppedbmp;
        
        
        public Main()
        {
            InitializeComponent();
            WebCam.GetVideoImage(pictureBox1);
            WebCam.GetCamList(MainWebCamList);
            WebCam.GetCamSettings(MainWebCamSettings);
            comboBox3.Items.Add("No Ratio");
            comboBox3.Items.Add("Passport");
            comboBox3.SelectedIndex = 1;
        }

        //refresh button
        private void rfsh_Click(object sender, EventArgs e)
        {
            WebCam.GetCamList(MainWebCamList);
            WebCam.GetCamSettings(MainWebCamSettings);
        }

        //toggle start and stop button
        private void start_Click(object sender, EventArgs e)
        {
            if (start.Text == "&Start")
            {
                WebCam.StartWebCam();
                label2.Text = "Device running...";
                start.Text = "&Stop";
                timer1.Enabled = true;

            }
            else
            {
                timer1.Enabled = false;
                WebCam.CloseVideoSource();
                label2.Text = "Device stopped.";
                start.Text = "&Start";
                pictureBox1.Image = null;
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


      
        

        

        //get total received frame at 1 second tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Device running... ";
        }

        //prevent sudden close while device is running
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WebCam.CloseVideoSource();
        }

        //Begin Crop
        private void cropPic_Click(object sender, EventArgs e)
        {
            cropBox = new CropBox(new Rectangle(10, 10, 45, 55));
            cropBox.SetPictureBox(pictureBox1);
            getRatio();
            cropBox.allowDeformingDuringMovement = true;
            timer1.Enabled = false;
            WebCam.CloseVideoSource();
            label2.Text = "Device stopped.";
            start.Text = "&Start";
            pictureBox1.Invalidate();
            
        }

        //GetRatio
        private void getRatio ()
        {
            if (comboBox3.SelectedIndex == 0)
            {
                CropBox.ratioEnabled = false;
            }
            if (comboBox3.SelectedIndex == 1)
            {
                CropBox.ratioEnabled = true;
                CropBox.ratio = 1.33f;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            getRatio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Jpeg;
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
                    case ".png":
                        format = ImageFormat.Png;
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