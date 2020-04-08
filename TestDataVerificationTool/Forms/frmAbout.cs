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

namespace TestDataVerificationTool
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            this.RevLabel.Text = ConfigurationManager.AppSettings["Revision"];
        }
        public string ReturnValue1 { get; set; }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = "ACK";
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();

        }


    }
}
