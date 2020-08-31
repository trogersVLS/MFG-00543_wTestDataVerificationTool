using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

namespace TestDataVerificationTool
{
    public partial class AboutForm : Form
    {

        public string ReturnValue1 { get; set; }
        public AboutForm()
        {
            InitializeComponent();
            this.lblBuildVersion.Text = string.Format("v{0}.{1}.{2}",
                                                       Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(),
                                                       Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString(),
                                                       Assembly.GetExecutingAssembly().GetName().Version.Build.ToString());

            this.lblRevisionLetter.Text = ConfigurationManager.AppSettings["Revision"];
        }


    }
}
