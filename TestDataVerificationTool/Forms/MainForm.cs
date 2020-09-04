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
        private bool AUTOMATE_VERIFICATION;
        private VerfApp BackendApp;

        const string BothellLocationTag = "Bothell";
        const string KokomoLocationTag = "Kokomo";
        const string KokomoArchiveLocationTag = "KokomoArchive";

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
        private async void FrmApp_Load(object sender, EventArgs e)
        {
            //Backend app for all backend logic
            this.BackendApp = new VerfApp();
            btnConfirm.Enabled = false;
            btnFail.Enabled = false;
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            btnFail.BackColor = System.Drawing.Color.Gray;
            operatorID.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            lblDescription.Text = "";

            //The location settings should persist. Use the last known config location.
            LocationMenuItem_Click(ConfigurationManager.AppSettings["Location"], null);
            this.Text = string.Format("{0} v{1} {2}", this.TITLE, this.VERSION, ConfigurationManager.AppSettings["Location"]);

            //Set the default final test settings to After Burn In (just in case).
            FinalTestMenuItem_Click(AfterBurnIn_Menu.Text, null);

            this.AUTOMATE_VERIFICATION = bool.Parse(ConfigurationManager.AppSettings["Auto"]);

            this.automationToolStripMenuItem.Checked = this.AUTOMATE_VERIFICATION;
            

           
            try
            {     
                await this.BackendApp.Reconnect();
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
                    Application.DoEvents();

                    if (AUTOMATE_VERIFICATION)
                    {
                        //Determine PASS or FAIL
                        VerifyTestData();
                    }
                }
                else
                {

                    this.button1.BackColor = Color.Gray;
                    this.button1.Text = "No Data";
                    Application.DoEvents();
                    if (BackendApp.RequiresTestData(this.lblDescription.Text))
                    {
                        if (AUTOMATE_VERIFICATION)
                        {
                            this.ButtonFail_Click(null, null);
                        }
                        
                    }
                    
                    //No data found.
                    
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
                if ((data != null)) return true;
                

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
                if (DataGrid.Rows[0].Cells["OverallPassFail"].Value != null)
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
                    this.ButtonFail_Click(null, null);
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



        private void FinalTestMenuItem_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //Before ONLY checked
            if (sender.ToString() == BeforeBurnIn_Menu.Text)
            {
                this.BeforeBurnIn_Menu.Checked = true;
                this.AfterBurnIn_Menu.Checked = false;
                config.AppSettings.Settings["FT_Keyword"].Value = "Before%";   
            }
            //After ONLY Checked
            else if (sender.ToString() == AfterBurnIn_Menu.Text)
            {
                this.BeforeBurnIn_Menu.Checked = false;
                this.AfterBurnIn_Menu.Checked = true;
                config.AppSettings.Settings["FT_Keyword"].Value = "After%";
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        private async void LocationMenuItem_Click(object sender, EventArgs e)
        {

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (sender.ToString() == BothellLocationTag)
            {   
                //Bothell
                this.bothellToolStripMenuItem.Checked = true;
                this.kokomoToolStripMenuItem.Checked = false;
                this.kokomoArchiveToolStripMenuItem.Checked = false;

                config.AppSettings.Settings["Location"].Value = BothellLocationTag;
            }
            else if (sender.ToString() == "Kokomo")
            {   
                //Kokomo
                this.bothellToolStripMenuItem.Checked = false;
                this.kokomoToolStripMenuItem.Checked = true;
                this.kokomoArchiveToolStripMenuItem.Checked = false;

                config.AppSettings.Settings["Location"].Value = KokomoLocationTag;
            }
            else if (sender.ToString() == KokomoArchiveLocationTag)
            {
                //Kokomo Archive
                this.bothellToolStripMenuItem.Checked = false;
                this.kokomoToolStripMenuItem.Checked = false;
                this.kokomoArchiveToolStripMenuItem.Checked = true;

                config.AppSettings.Settings["Location"].Value = KokomoArchiveLocationTag;
            }


            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            await this.BackendApp.Reconnect();
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
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }
    }
}