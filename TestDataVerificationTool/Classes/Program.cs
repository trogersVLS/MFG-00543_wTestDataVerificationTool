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

            //Sanity check to confirm that Config variables are correct for the build
            Trace.WriteLine("Location is " + ConfigurationManager.AppSettings["Location"]);
            Trace.WriteLine("Settings path is " + ConfigurationManager.AppSettings["ConfigPath"]);

            Trace.WriteLine("Sypro Connection String: " + ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["SysproDB"]]);
            Trace.WriteLine("Test Connection String: " + ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["TestDB"]]);
            Trace.WriteLine("Verification Connection String: " + ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["VerificationDB"]]);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
