using System;
using System.Windows.Forms;

namespace WebCamPassport
{
    public partial class Options : Form
    {
        public static string optionsLocation;
        public static bool scaleEnabled;
        public static bool autoStart;
        public static string quality;

        public Options()
        {
            InitializeComponent();
            WebCam.GetCamListCombobox(OptionsWebCamList);
            WebCam.GetCamSettingsCombobox(OptionsWebCamSettings);
            AcceptButton = optionsOk;
            CancelButton = optionCancel;
            OptionsCropBoxRatioCombobox.Items.Add("No Ratio");
            OptionsCropBoxRatioCombobox.Items.Add("Passport");
            RestoreSettings();
            GetRatio();
        }

        private void browseSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Main.saveLocation;
            fbd.ShowDialog();
            optionsLocation = fbd.SelectedPath;
            savePath.Text = optionsLocation;
        }

        private void OptionsWebCamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebCam.GetCamSettingsCombobox(OptionsWebCamSettings);
        }
        
        //GetRatio
        public void GetRatio()
        {
            if (OptionsCropBoxRatioCombobox.SelectedIndex == 1)
            {
                CropBox.ratioEnabled = true;
                CropBox.ratio = 1.33f;
            }
            else
            {
                CropBox.ratioEnabled = false;
            }
        }

        private void OptionsCropBoxRatioCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
           GetRatio();
        }
        
        private void OptionsNoScalingRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (OptionsNoScalingRadio.Checked == true)
            {
                OptionsScaleHeightTextBox.Enabled = false;
                OptionsScaleWidthTextBox.Enabled = false;
                scaleEnabled = false;
            }
        }

        private void OptionsScalingRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (OptionsScalingRadio.Checked == true)
            {
                OptionsScaleHeightTextBox.Enabled = true;
                OptionsScaleWidthTextBox.Enabled = true;
                scaleEnabled = true;
            }
        }

        private void OptionsScaleHeightTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Allow navigation keyboard arrows
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                    e.SuppressKeyPress = false;
                    return;
                default:
                    break;
            }

            //Block non-number characters
            char currentKey = (char)e.KeyCode;
            bool modifier = e.Control || e.Alt || e.Shift;
            bool nonNumber = char.IsLetter(currentKey) ||
                             char.IsSymbol(currentKey) ||
                             char.IsWhiteSpace(currentKey) ||
                             char.IsPunctuation(currentKey);

            if (!modifier && nonNumber)
                e.SuppressKeyPress = true;

            //Handle pasted Text
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Preview paste data (removing non-number characters)
                string pasteText = Clipboard.GetText();
                string strippedText = "";
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (char.IsDigit(pasteText[i]))
                        strippedText += pasteText[i].ToString();
                }

                if (strippedText != pasteText)
                {
                    //There were non-numbers in the pasted text
                    e.SuppressKeyPress = true;

                    //OPTIONAL: Manually insert text stripped of non-numbers
                    TextBox me = (TextBox)sender;
                    int start = me.SelectionStart;
                    string newTxt = me.Text;
                    newTxt = newTxt.Remove(me.SelectionStart, me.SelectionLength); //remove highlighted text
                    newTxt = newTxt.Insert(me.SelectionStart, strippedText); //paste
                    me.Text = newTxt;
                    me.SelectionStart = start + strippedText.Length;
                }
                else
                    e.SuppressKeyPress = false;
            }
        }

        private void OptionsScaleWidthTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Allow navigation keyboard arrows
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                    e.SuppressKeyPress = false;
                    return;
                default:
                    break;
            }

            //Block non-number characters
            char currentKey = (char)e.KeyCode;
            bool modifier = e.Control || e.Alt || e.Shift;
            bool nonNumber = char.IsLetter(currentKey) ||
                             char.IsSymbol(currentKey) ||
                             char.IsWhiteSpace(currentKey) ||
                             char.IsPunctuation(currentKey);

            if (!modifier && nonNumber)
                e.SuppressKeyPress = true;

            //Handle pasted Text
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Preview paste data (removing non-number characters)
                string pasteText = Clipboard.GetText();
                string strippedText = "";
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (char.IsDigit(pasteText[i]))
                        strippedText += pasteText[i].ToString();
                }

                if (strippedText != pasteText)
                {
                    //There were non-numbers in the pasted text
                    e.SuppressKeyPress = true;

                    //OPTIONAL: Manually insert text stripped of non-numbers
                    TextBox me = (TextBox)sender;
                    int start = me.SelectionStart;
                    string newTxt = me.Text;
                    newTxt = newTxt.Remove(me.SelectionStart, me.SelectionLength); //remove highlighted text
                    newTxt = newTxt.Insert(me.SelectionStart, strippedText); //paste
                    me.Text = newTxt;
                    me.SelectionStart = start + strippedText.Length;
                }
                else
                    e.SuppressKeyPress = false;
            }
        }

        private void OptionsScaleHeightTextBox_Leave(object sender, EventArgs e)
        {
            if (CropBox.ratioEnabled == true)
            {
                float scaleHeight = float.Parse(OptionsScaleHeightTextBox.Text);
                int scaleWidth = (int)(scaleHeight / CropBox.ratio);
                OptionsScaleWidthTextBox.Text = Convert.ToString(scaleWidth);
            }
        }

        private void AutoHighQuality_CheckedChanged(object sender, EventArgs e)
        {
            if(AutoHighQuality.Checked == true)
            {
                OptionsWebCamList.Enabled = false;
                OptionsWebCamSettings.Enabled = false;
                quality = "AutoHighQuality";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(CameraAuto.Checked == true)
            {
                OptionsWebCamList.Enabled = false;
                OptionsWebCamSettings.Enabled = false;
                quality = "CameraAuto";
            }
        }

        private void Custom_CheckedChanged(object sender, EventArgs e)
        {
            if(Custom.Checked == true)
            {
                OptionsWebCamList.Enabled = true;
                OptionsWebCamSettings.Enabled = true;
                quality = "Custom";
            }
        }

        private void OptionsAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (OptionsAutoStart.Checked == true)
            {
                autoStart = true;
            }
            else
            {
                autoStart = false;
            }
        }

        private void RestoreSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;
            
            //Save Location
            if (settings.SaveLocation == "")
            {
                Main.saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                savePath.Text = Main.saveLocation;
            }
            else
            {
                savePath.Text = settings.SaveLocation;
            }

            //Ratio
            if (settings.Ratio != "")
            {
                OptionsCropBoxRatioCombobox.SelectedIndex = OptionsCropBoxRatioCombobox.FindString(Properties.Settings.Default.Ratio);
            }           

            // Quality
            if (settings.quality == "AutoHighQuality")
            {
                AutoHighQuality.Checked = true;
            }
            else if(settings.quality == "CameraAuto")
            {
                CameraAuto.Checked = true;
            }
            else if (settings.quality == "Custom")
            {
                Custom.Checked = true;
            }

            
            //Scale
            if(settings.scaleEnabled == true)
            {
                OptionsScalingRadio.Checked = true;
                OptionsScaleHeightTextBox.Text = settings.scaleHeight;
                OptionsScaleWidthTextBox.Text = settings.scaleWidth;

            }
            else
            {
                OptionsNoScalingRadio.Checked = true;
            }

            //autostart
            if(settings.autoStart == true)
            {
                OptionsAutoStart.Enabled = true;
            }
        }

        private void OptionsScaleWidthTextBox_Leave(object sender, EventArgs e)
        {
            if (CropBox.ratioEnabled == true)
            {
                float scaleWidth = float.Parse(OptionsScaleWidthTextBox.Text);
                int scaleHeight = (int)(scaleWidth * CropBox.ratio);
                OptionsScaleHeightTextBox.Text = Convert.ToString(scaleHeight);
            }
        }
    }
}
