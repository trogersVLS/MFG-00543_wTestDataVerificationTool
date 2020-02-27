using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFG_00543_Test_Data_Verification_Tool
{
    public partial class FrmAbout : Form
    {
        public FrmAbout() => InitializeComponent();

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
