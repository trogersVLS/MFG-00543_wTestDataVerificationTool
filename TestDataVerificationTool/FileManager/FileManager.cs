using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Security.AccessControl;

namespace TestDataVerificationTool
{

    /***********************************
     * FileManager.cs
     * 
     * - This class validates the presence of local files needed to run 
     * the application
     * 
     *******************************/
    public class FileManager
    {
        public static void ValidateFiles()
        {
            
            string SettingsPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" +  ConfigurationManager.AppSettings["ConfigPath"];

            //Settings is read-only.
            if (!File.Exists(SettingsPath))
            {

                throw new FileNotFoundException("Settings.xml does not exist in the program directory.");
            }

        

        }


    }
}
