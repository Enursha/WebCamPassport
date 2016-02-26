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
        
        public Main()
        {
            InitializeComponent();
            Options settingsForm = new Options();
            CropBox.pictureBox1 = pictureBox1;
            WebCam.GetCamListCombobox(settingsForm.OptionsWebCamList);
            WebCam.GetCamSettingsCombobox(settingsForm.OptionsWebCamSettings);
            WebCam.GetVideoImage(pictureBox1);
            if (Properties.Settings.Default.autoStart == true)
            {
                CamStart();
            }
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

        public void CamStart()
        {
            WebCam.StartWebCam();
            label2.Text = "Camera running...";
            start.Text = "&Stop";
            timer1.Enabled = true;
        }

        private void CamStop()
        {
            timer1.Enabled = false;
            WebCam.CloseVideoSource();
            label2.Text = "Camera stopped.";
            start.Text = "&Start";
            pictureBox1.Image = null;
        }

        //take picture button
        private void takePic_Click(object sender, EventArgs e)
        {
                CropBox.TakePic(pictureBox1, snapShot);
        }

        //get total received frame at 1 second tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Camera running... ";
        }

        private void Main_Closing()
        {
            WebCam.CloseVideoSource();
        }

        private void cropPic_Click(object sender, EventArgs e)
        {
            
            int centreX = (pictureBox1.Height / 2) - (212 / 2);
            int centreY = (pictureBox1.Width / 2) - (160 / 2);
            cropBox = new CropBox(new Rectangle(centreY, centreX, 160, 212));
            cropBox.SetPictureBox(pictureBox1);
            cropBox.allowDeformingDuringMovement = true; //if mouse can set cropbox beond Main picturebox
            pictureBox1.Invalidate();
        }
        
        private void options_Click(object sender, EventArgs e)
        {
            CamStop();
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
                Properties.Settings.Default.Ratio = Convert.ToString(settingsForm.OptionsCropBoxRatioCombobox.SelectedItem);
                Properties.Settings.Default.SaveLocation = settingsForm.savePath.Text;
                Properties.Settings.Default.scaleEnabled = Options.scaleEnabled;
                Properties.Settings.Default.scaleHeight = settingsForm.OptionsScaleHeightTextBox.Text;
                Properties.Settings.Default.scaleWidth = settingsForm.OptionsScaleWidthTextBox.Text;
                Properties.Settings.Default.autoStart = Options.autoStart;
                Properties.Settings.Default.Save();
                settingsForm.Close();
            }
            CamStart();
        }

        private void mainSave_Click(object sender, EventArgs e)
        {
            CropBox.TakePic(pictureBox1, snapShot);

            if (Properties.Settings.Default.SaveLocation == "")
            {
                saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }

            else
            {
                saveLocation = Properties.Settings.Default.SaveLocation;
            }

            if (Properties.Settings.Default.scaleEnabled == true)
            {
                int scaleWidth = Convert.ToInt32(Properties.Settings.Default.scaleWidth);
                int scaleHeight = Convert.ToInt32(Properties.Settings.Default.scaleHeight);
                var destRect = new Rectangle(0, 0, scaleWidth, scaleHeight);
                var destImage = new Bitmap(scaleWidth, scaleHeight);

                destImage.SetResolution(snapShot.Image.HorizontalResolution, snapShot.Image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(snapShot.Image, destRect, 0, 0, snapShot.Image.Width, snapShot.Image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
                destImage.Save(saveLocation + "\\Photo_" + DateTime.Now.ToString("yyyyMMdd_hh_mm_ss") + ".jpg", ImageFormat.Jpeg);
            }
            else
            {
                snapShot.Image.Save(saveLocation + "\\Photo_" + DateTime.Now.ToString("yyyyMMdd_hh_mm_ss") + ".jpg", ImageFormat.Jpeg);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebCam.CloseVideoSource();
        }
    }
}