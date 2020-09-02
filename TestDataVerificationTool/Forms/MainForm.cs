using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


namespace TestDataVerificationTool
{
    
    
    public partial class MainForm : Form
    {
        private readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." +
                                  Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();

        private readonly string TITLE = "MFG-00543 Test Data Verification Tool";
        private bool AUTOMATE_VERIFICATION = bool.Parse(ConfigurationManager.AppSettings["Auto"]);
        private VerfApp BackendApp;

        public MainForm()
        {
            //Initialize the database connection.
            InitializeComponent();

        }

        /****************************************************
         * Event Handlers
         *
         *
         *
         ***************************************************/
        private void FrmApp_Load(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            btnFail.Enabled = false;
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            btnFail.BackColor = System.Drawing.Color.Gray;
            operatorID.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            lblDescription.Text = "";
            this.Text = string.Format("{0} v{1} {2}", this.TITLE, this.VERSION, ConfigurationManager.AppSettings["Location"]);
            if(ConfigurationManager.AppSettings["Location"] == "Bothell")
            {
                this.bothellToolStripMenuItem.Checked = true;
                this.kokomoToolStripMenuItem.Checked = false;
            }
            else if (ConfigurationManager.AppSettings["Location"] == "Kokomo")
            {
                this.kokomoToolStripMenuItem.Checked = true;
                this.bothellToolStripMenuItem.Checked = false;

            }

            //Create new instance of backend process and message passing capability
            Progress<(string, ACTION_TYPE)> message = new Progress<(string, ACTION_TYPE)>(s => this.DisplayMessage(s));
            try
            {
                this.BackendApp = new VerfApp(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AboutForm())
            {
                var result = form.ShowDialog();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RtbStatus_TextChanged(object sender, EventArgs e)
        {
            //Keeps the caret at the end of the message box.
            //rtbStatus.SelectionStart = rtbStatus.Text.Length;
            //rtbStatus.ScrollToCaret();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            //Disable any other button functions until function has completed
            btnFail.Enabled = false;
            btnConfirm.Enabled = false;
            this.button1.BackColor = Color.Green;
            this.button1.Text = "PASS";
            BackendApp.InsertVerf(true, operatorID.Text);
            //rtbStatus.AppendText(string.Format("{0}: Verification for SN {1} complete.\nSN {1} PASSED\n", System.DateTime.Now, txtUnitSN.Text));



            ResetForm();
        }

        private void ButtonFail_Click(object sender, EventArgs e)
        {
            //Disable any other button functions until function has completed
            btnFail.Enabled = false;
            btnConfirm.Enabled = false;
            this.button1.BackColor = Color.Red;
            this.button1.Text = "FAIL";
            BackendApp.InsertVerf(false, operatorID.Text);
            //rtbStatus.AppendText(string.Format("{0}: Verification for SN {1} complete.\nSN {1} FAILED\n", System.DateTime.Now, txtUnitSN.Text));


            ResetForm();

        }

        

        private void UpdateRecordCount(object sender, EventArgs e)
        {
            //Data source shows an extra blank row at end, subtract 1 for true count
            int count = (this.DataGrid.Rows.Count == 0 ? 0 : this.DataGrid.Rows.Count - 1);
            this.RecordCount.Text = count.ToString();
        }

        

        private void txtUnitSN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtUnitSN.Text != ""))
            {
                this.button1.Text = "Waiting ...";
                this.button1.BackColor = Color.Yellow;
                Application.DoEvents();
                e.Handled = true;
                if (LoadData())
                {   
                    btnFail.Enabled = true;
                    btnConfirm.Enabled = true;
                    btnConfirm.BackColor = System.Drawing.Color.Green;
                    btnFail.BackColor = System.Drawing.Color.Red;

                    if (AUTOMATE_VERIFICATION)
                    {
                        //Determine PASS or FAIL
                        VerifyTestData();
                    }
                }
                else
                {
                    //No data found.
                    if (BackendApp.RequiresTestData(this.lblDescription.Text))
                    {
                        this.ButtonFail_Click(null, null);
                    }
                    else
                    {
                        this.button1.BackColor = Color.Gray;
                        this.button1.Text = "No Data";
                    }
                }
                
            }
           
        }
        

        private void txtUnitSN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                var newKey = new KeyEventArgs(Keys.Enter);
                txtUnitSN_KeyDown(null, newKey);
            }
        }
        /****************************************************
         * Form State Transitions
         *
         ***************************************************/
        private bool LoadData() 
        {
            string partnumber;
            string description;
            string tablename;
            string serial = this.txtUnitSN.Text;
            DataTable data = null;
            if (serial != null)
            {
                if(BackendApp.GetTestData(serial, out data, out partnumber, out description, out tablename))
                {

                    DataGrid.DataSource = data;
                    //Update status accordingly
                    HighlightPassFail(tablename);
                }
                else
                {
                    DataGrid.DataSource = null;
                }
                
                lblDescription.Text = string.Format("{0} - {1}", partnumber, description);
                if ((data != null) && (data.Rows.Count > 0)) return true;
                

            }
            return false;
        }
        private void ResetForm()
        {
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            btnFail.BackColor = System.Drawing.Color.Gray;
            if (!AUTOMATE_VERIFICATION)
            {
                DataGrid.DataSource = null;
                lblDescription.Text = "";
            }
            


            txtUnitSN.Focus();
            txtUnitSN.SelectAll();
        }

        public void Reset()
        {
            this.DataGrid.DataSource = null;
            this.txtUnitSN.Text = null;
            this.RecordCount.Text = null;
        }

        public void VerifyTestData()
        {
            //If test data is passing?
            if (lblDescription.Text.Contains("Assembly, V"))
            {
                FinalTestVerify();
            }
            else 
            {
                if (DataGrid.Rows.Count > 0)
                {
                    if (DataGrid.Rows[0].Cells["OverallPassFail"].Value.ToString() == "PASS")
                    {
                        this.ButtonConfirm_Click(null, null);
                    }
                    else if (DataGrid.Rows[0].Cells["OverallPassFail"].Value.ToString() == "FAIL")
                    {
                        this.ButtonFail_Click(null, null);
                    }
                    else
                    {
                        throw new Exception("How'd I get here?");
                    }
                }
                else
                {
                    //this.ButtonFail_Click(null, null);
                }
                
            }

        }

        public void FinalTestVerify()
        {
            string ColumnName = "TestResult";
            //Verify that the values are what they should be.
            int cnt = 0;
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells[DataGrid.Columns[ColumnName].Index].Value != null)
                {
                    if (row.Cells[DataGrid.Columns[ColumnName].Index].Value.ToString() == "PASS")
                    {
                        cnt++;
                    }
                }
            }
            if(BackendApp.FinalTestNumbersCheck(lblDescription.Text, cnt))
            {
                this.ButtonConfirm_Click(null, null);
            }
            else
            {
                this.ButtonFail_Click(null, null);
            }

        }
        /****************************************************
        * Helper Functions
        *
        ***************************************************/
        public void DisplayMessage((string s, ACTION_TYPE messageType) input)
        {

            switch (input.messageType)
            {
                case (ACTION_TYPE.Debug):
                    break;
                case (ACTION_TYPE.Status):
                    break;
                case (ACTION_TYPE.Error):
                    break;
                case (ACTION_TYPE.PartNumber):
                    break;
                case (ACTION_TYPE.Database):
                    break;
                default:
                    break;
            }

        }
        private void HighlightPassFail(string tableName)
        {
            string ColumnName;
            if (tableName == "Production_Test_Final_Test") ColumnName = "TestResult";
            else ColumnName = "OverallPassFail";

            Dictionary<string, Color> ColorMap = new Dictionary<string, Color>();
            ColorMap.Add("pass", Color.Green);
            ColorMap.Add("fail", Color.Red);

            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells[DataGrid.Columns[ColumnName].Index].Value != null)
                {
                    var key = row.Cells[DataGrid.Columns[ColumnName].Index].Value.ToString().ToLower();
                    Color color;

                    if (ColorMap.TryGetValue(key, out color))
                    {
                        row.Cells[DataGrid.Columns[ColumnName].Index].Style.BackColor = color;
                        row.Cells[DataGrid.Columns[ColumnName].Index].Style.Font = new Font(DataGrid.Font, FontStyle.Bold);
                    }
                }
            }
        }



        private void FinalTest_Menu_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //Before ONLY checked
            if (BeforeBurnIn_Menu.Checked && !AfterBurnIn_Menu.Checked)
            {
                this.BeforeBurnIn_Menu.Checked = false;
                this.AfterBurnIn_Menu.Checked = true;
                config.AppSettings.Settings["FT_Keyword"].Value = "After%";   
            }
            //After ONLY Checked
            else if (!BeforeBurnIn_Menu.Checked && AfterBurnIn_Menu.Checked)
            {
                this.BeforeBurnIn_Menu.Checked = true;
                this.AfterBurnIn_Menu.Checked = false;
                config.AppSettings.Settings["FT_Keyword"].Value = "Before%";
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        private void LocationMenuItem_Click(object sender, EventArgs e)
        {

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (bothellToolStripMenuItem.Checked)
            {
                this.bothellToolStripMenuItem.Checked = false;
                this.kokomoToolStripMenuItem.Checked = true;

                config.AppSettings.Settings["Location"].Value = "Kokomo";
            }
            else if (kokomoToolStripMenuItem.Checked)
            {
                this.kokomoToolStripMenuItem.Checked = false;
                this.bothellToolStripMenuItem.Checked = true;
                config.AppSettings.Settings["Location"].Value = "Bothell";
            }

            
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            this.BackendApp.Reconnect();
            this.Text = string.Format("{0} v{1} {2}", this.TITLE, this.VERSION, ConfigurationManager.AppSettings["Location"]);
        }

        private void automationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!automationToolStripMenuItem.Checked)
            {
                this.automationToolStripMenuItem.Checked = true;
                this.AUTOMATE_VERIFICATION = true;
                config.AppSettings.Settings["Auto"].Value = "true";
            }
            else
            {
                this.automationToolStripMenuItem.Checked = false;
                this.AUTOMATE_VERIFICATION = false;
                config.AppSettings.Settings["Auto"].Value = "false";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
        }
    }
}