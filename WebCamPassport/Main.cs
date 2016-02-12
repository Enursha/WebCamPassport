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
        public static string saveLocation;
        CropBox cropBox;
        Bitmap croppedbmp;
        


        public Main()
        {
            InitializeComponent();
            Options settingsForm = new Options();
            //CropBox cropBox = new CropBox.TakePic();
            CropBox.pictureBox1 = pictureBox1;
            CamStart();
            WebCam.GetCamListCombobox(settingsForm.OptionsWebCamList);
            WebCam.GetCamSettingsCombobox(settingsForm.OptionsWebCamSettings);
            WebCam.GetVideoImage(pictureBox1);
            
        }

        //toggle start and stop button
        private void start_Click(object sender, EventArgs e)
        {
            if (start.Text == "&Start")
            {
                CamStart();
            }
            else
            {
                CamStop();
            }
        }
        private void CamStart()
        {
        WebCam.StartWebCam();
                label2.Text = "Device running...";
                start.Text = "&Stop";
                timer1.Enabled = true;
        }

        private void CamStop()
        {
            timer1.Enabled = false;
            WebCam.CloseVideoSource();
            label2.Text = "Device stopped.";
            start.Text = "&Start";
            pictureBox1.Image = null;
        }

        //take picture button
        private void takePic_Click(object sender, EventArgs e)
        {
                CropBox.TakePic(pictureBox1, snapShot);
        }

        //public void TakePic()
        //{
        //    Point p = cropBox.rect.Location;
        //    Point unscaled_p = new Point();
        //    int unscaled_height;
        //    int unscaled_width;

        //    // image and container dimensions
        //    int w_i = pictureBox1.Image.Width;
        //    int h_i = pictureBox1.Image.Height;
        //    int w_c = pictureBox1.Width;
        //    int h_c = pictureBox1.Height;

        //    float imageRatio = w_i / (float)h_i; // image W:H ratio
        //    float containerRatio = w_c / (float)h_c; // container W:H ratio

        //    if (imageRatio >= containerRatio)
        //    {
        //        // horizontal image
        //        float scaleFactor = w_c / (float)w_i;
        //        float scaledHeight = h_i * scaleFactor;
        //        // calculate gap between top of container and top of image
        //        float filler = Math.Abs(h_c - scaledHeight) / 2;
        //        unscaled_p.X = (int)(p.X / scaleFactor);
        //        unscaled_p.Y = (int)((p.Y - filler) / scaleFactor);
        //        unscaled_width = (int)(cropBox.rect.Width / scaleFactor);
        //        unscaled_height = (int)(cropBox.rect.Height / scaleFactor);
        //    }
        //    else
        //    {
        //        // vertical image
        //        float scaleFactor = h_c / (float)h_i;
        //        float scaledWidth = w_i * scaleFactor;
        //        float filler = Math.Abs(w_c - scaledWidth) / 2;
        //        unscaled_p.X = (int)((p.X - filler) / scaleFactor);
        //        unscaled_p.Y = (int)(p.Y / scaleFactor);
        //        unscaled_width = (int)(cropBox.rect.Width / scaleFactor);
        //        unscaled_height = (int)(cropBox.rect.Height / scaleFactor);
        //    }


        //    Rectangle cropBoxUnscaled = new Rectangle(unscaled_p.X, unscaled_p.Y, unscaled_width, unscaled_height);
        //    Bitmap bmp = new Bitmap(pictureBox1.Image);
        //    croppedbmp = bmp.Clone(cropBoxUnscaled, bmp.PixelFormat);
        //    snapShot.Image = croppedbmp;
        //    snapShot.Invalidate();
        //}





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
            cropBox = new CropBox(new Rectangle(30, 30, 160, 212));
            cropBox.SetPictureBox(pictureBox1);
            Options.getRatio();
            cropBox.allowDeformingDuringMovement = true;
            //timer1.Enabled = false;
            //WebCam.CloseVideoSource();
            //label2.Text = "Device stopped.";
            //start.Text = "&Start";
            //CamStop();
            pictureBox1.Invalidate();
            //CropBox.TakePic(pictureBox1, snapShot);
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = saveLocation;
            sfd.Filter = "Image (*.jpg)|*.jpg|Image (*.bmp)|*.bmp";
            ImageFormat format = ImageFormat.Jpeg;
            sfd.DefaultExt = "jpg";
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

        private void options_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Options settingsForm = new Options();

            // Show the settings form
            DialogResult dr = settingsForm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                settingsForm.Close();
            }
            else if (dr == DialogResult.OK)
            {
                saveLocation = Options.optionsLocation;
                Properties.Settings.Default.WebCamDevice = Convert.ToString(settingsForm.OptionsWebCamList.SelectedItem);
                Properties.Settings.Default.WebCamResolution = Convert.ToString(settingsForm.OptionsWebCamSettings.SelectedItem);
                Properties.Settings.Default.Ratio = Convert.ToString(settingsForm.comboBox3.SelectedItem);
                Properties.Settings.Default.SaveLocation = settingsForm.savePath.Text;
                Properties.Settings.Default.Save();
                settingsForm.Close();
            }

        }

        private void mainSave_Click(object sender, EventArgs e)
        {
            CropBox.TakePic(pictureBox1, snapShot);
            saveLocation = Properties.Settings.Default.SaveLocation;
            snapShot.Image.Save(saveLocation + "\\Photo_" + DateTime.Now.ToString("yyyyMMdd_hh_mm_ss") + ".jpg", ImageFormat.Jpeg);
        }
    }
}