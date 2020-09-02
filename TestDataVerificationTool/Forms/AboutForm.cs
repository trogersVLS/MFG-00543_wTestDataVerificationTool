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
