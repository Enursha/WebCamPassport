using System;
using System.Windows.Forms;

namespace WebCamPassport
{
    public partial class Options : Form
    {
        public static string optionsLocation;
        

        public Options()
        {
            InitializeComponent();
            WebCam.GetCamListCombobox(OptionsWebCamList);
            WebCam.GetCamSettingsCombobox(OptionsWebCamSettings);
            AcceptButton = optionsOk;
            CancelButton = optionCancel;
            comboBox3.Items.Add("No Ratio");
            comboBox3.Items.Add("Passport");

            if (Properties.Settings.Default.SaveLocation == null)
            {
                Main.saveLocation = Convert.ToString(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
                savePath.Text = Main.saveLocation;
            }
            else
            {
                savePath.Text = Properties.Settings.Default.SaveLocation;
            }

            if (Properties.Settings.Default.Ratio == null)
            {
                comboBox3.SelectedIndex = 1;
            }
            else
            {
                comboBox3.SelectedIndex = comboBox3.FindString(Properties.Settings.Default.Ratio);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void browseSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Properties.Settings.Default.SaveLocation;
            fbd.ShowDialog();
            optionsLocation = fbd.SelectedPath;
            savePath.Text = optionsLocation;
        }

        private void OptionsWebCamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebCam.GetCamSettingsCombobox(OptionsWebCamSettings);
        }
        
        //GetRatio
        public static void getRatio()
        {
            Options settingsForm = new Options();

            if (settingsForm.comboBox3.SelectedIndex == 0)
            {
                CropBox.ratioEnabled = false;
            }
            if (settingsForm.comboBox3.SelectedIndex == 1)
            {
                CropBox.ratioEnabled = true;
                CropBox.ratio = 1.33f;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            getRatio();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Ratio = Convert.ToString(comboBox3.SelectedItem);
        }
    }
}
