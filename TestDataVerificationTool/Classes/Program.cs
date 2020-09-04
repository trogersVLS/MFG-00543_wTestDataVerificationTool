using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace TestDataVerificationTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Validate files first
            try
            {
                FileManager.ValidateFiles();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
