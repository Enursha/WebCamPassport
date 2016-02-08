using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WebCamPassport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (Properties.Settings.Default.WebCamDevice == null)
            //{
            //    Options settingsForm = new Options();

            //    // Show the settings form
            //    DialogResult dr = settingsForm.ShowDialog();
            //    if (dr == DialogResult.Cancel)
            //    {
            //        settingsForm.Close();
            //    }
            //    else if (dr == DialogResult.OK)
            //    {
            //        Properties.Settings.Default.SaveLocation = Options.optionsLocation;
            //        settingsForm.Close();
            //    }
            //    Application.Run(new Main());

            //}
            //else
            //{
            //    Application.Run(new Main());
            //}
            Application.Run(new Main());
        }
    }
}
