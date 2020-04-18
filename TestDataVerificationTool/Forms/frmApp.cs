using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;



namespace TestDataVerificationTool
{
    public partial class FrmApp : Form
    {
        

        public FrmApp()
        {
            InitializeComponent();
        }
        private void FrmApp_Load(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            btnFail.Enabled = false;
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            btnFail.BackColor = System.Drawing.Color.Gray;
            operatorID.Text = GlobalSettings.UserID; ;
            lblDescription.Text = "";
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FrmAbout())
            {
                var result = form.ShowDialog();
            }
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is 
            // commited, display an error message.
            if (e.Exception != null)
            {
                //MessageBox.Show(" Data format is invalid and cannot be displayed. ");
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtUnitSN_LostFocus(object sender, EventArgs e)
        {
            if (txtUnitSN.Text != "")
            {
                QueryPNFromDB(txtUnitSN.Text);
                if (GlobalSettings.PN != null)
                {
                    LoadXML(GlobalSettings.PN);
                    QueryFromDB(txtUnitSN.Text);
                }
                

                if (GlobalSettings.ReadOnly == false)
                {
                    btnFail.Enabled = true;
                    btnConfirm.Enabled = true;
                    btnConfirm.BackColor = System.Drawing.Color.Green;
                    btnFail.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                MessageBox.Show("Please ensure the OpID and Serial Number are selected or entered");
            }
            
        }

        public void QueryPNFromDB(string SN)
        {
            StringBuilder errorMessages = new StringBuilder();
            
            try
            {
                rtbStatus.AppendText("\n" + System.DateTime.Now + ": Checking Syspro database for part number");
                GlobalSettings.PN = DBManager.GetPartNumber(SN);
                if(GlobalSettings.PN == null)
                {
                    rtbStatus.AppendText("\n" + System.DateTime.Now + ": Serial number could not be found in Syspro");
                }
                else rtbStatus.AppendText("- Done");

            }
            catch (SqlException ex)
            {
                bool bDBState = true;

                for (int i = 0; i < ex.Errors.Count; i++)
                {

                    if (ex.Errors[i].Number == 53 && ex.Errors.Count == 1)
                    {
                        bDBState = false;
                    }
                    errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                        "Error Number: " + ex.Errors[i].Number + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n\n");
                }

                if (bDBState == false)
                {
                    MessageBox.Show("The SQL Database is not found or is disconnected. Please this record cannot be saved, please contact IT administrator or test engineer.\n");
                    rtbStatus.AppendText(System.DateTime.Now + ": Database is not found \n");

                }
                else
                {
                    MessageBox.Show(errorMessages.ToString());
                }

            }

        }

        public void QueryFromDB(string SN)
        {
            StringBuilder errorMessages = new StringBuilder();

            try
            {
                if (GlobalSettings.Table != "")
                {
                    //Look for existing tests
                    rtbStatus.AppendText("\n" + System.DateTime.Now + ": Checking test database for existing tests");
                    dataGridView1.DataSource = DBManager.GetTestRecords(GlobalSettings.Table, SN, GlobalSettings.ST, GlobalSettings.PN);
                    rtbStatus.AppendText(" - Done");
                }
                else
                {
                    rtbStatus.AppendText("\n" + System.DateTime.Now + ": Records for " + GlobalSettings.PN + " could not be found in any test data table listed in Settings.XML\n");
                }
                if(GlobalSettings.Table == "Production_Test_Final_Test")
                {
                    this.FilterFinalTestRecords(GlobalSettings.PN);
                }
                this.HighlightPassFail(GlobalSettings.Table);
            }

            catch (SqlException ex)
            {
                bool bDBState = true;

                for (int i = 0; i < ex.Errors.Count; i++)
                {

                    if (ex.Errors[i].Number == 53 && ex.Errors.Count == 1)
                    {
                        bDBState = false;
                    }
                    errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                        "Error Number: " + ex.Errors[i].Number + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n\n");
                }

                if (bDBState == false)
                {
                    MessageBox.Show("The SQL Database is not found or is disconnected. Please this record cannot be saved, please contact IT administrator or test engineer.\n");
                    rtbStatus.AppendText(System.DateTime.Now + ": Database is not found \n");

                }
                else
                {
                    MessageBox.Show(errorMessages.ToString());
                }

            }

        }

        private void HighlightPassFail(string tableName)
        {
            string ColumnName;
            if (tableName == "Production_Test_Final_Test") ColumnName = "TestResult";
            else ColumnName = "OverallPassFail";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (object.Equals(row.Cells[dataGridView1.Columns[ColumnName].Index].Value, "PASS"))
                {
                    /*  change color of cell*/
                    row.Cells[dataGridView1.Columns[ColumnName].Index].Style.BackColor = Color.Green;
                    row.Cells[dataGridView1.Columns[ColumnName].Index].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }

                else if (object.Equals(row.Cells[dataGridView1.Columns[ColumnName].Index].Value, "FAIL"))
                {
                    /*  change color of cell*/
                    row.Cells[dataGridView1.Columns[ColumnName].Index].Style.BackColor = Color.Red;
                    row.Cells[dataGridView1.Columns[ColumnName].Index].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
                
            }
        }
        private void FilterFinalTestRecords(string PN)
        {   
            //Assumed that all rows are ordered by time.
            List<string> test_names = new List<string>();
            List<int> duplicate_index = new List<int>();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            { 
                string test = (row.Cells[dataGridView1.Columns["TestName"].Index].Value ?? "").ToString();
                if (test_names.Contains(test))
                {
                    duplicate_index.Add(row.Index);
                }
                else
                {   if (test != "")
                    {
                        test_names.Add(test);
                    }
                }
            }
            DataTable data = (DataTable)dataGridView1.DataSource;
            duplicate_index.Sort();
            duplicate_index.Reverse();
            foreach(int i in duplicate_index)
            {
                data.Rows[i].Delete();
            }
            dataGridView1.DataSource = data;
            UpdateRecordCount(null, null);
            //dataGridView1.Rows.RemoveAt(0);
        }

       


        public void LoadXML(string partnumber)
        {
            if (partnumber.Substring(0, 3) == "PRT")
            {
                GlobalSettings.Table = GetXMLItems(true, partnumber, "Table");
                lblDescription.Text = partnumber + " " + GetXMLItems(true, partnumber, "Description");
                GlobalSettings.ST = GetXMLItems(true, partnumber, "ST");

            }

            GetXMLItems(false, partnumber, "do it");
        }

        private string GetXMLItems(bool part, string strPNSelect, string strTestParam)
         {

            try
            {
                StringBuilder errorMessages = new StringBuilder();

                using (XmlReader reader = XmlReader.Create(ConfigurationManager.AppSettings["ConfigPath"]))
                {
                    string s = "";
                    if (part)
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement())
                            {
                                string attr = reader["pn"];
                                if (attr == strPNSelect)
                                {
                                    if (reader.ReadToDescendant(strTestParam))
                                    {
                                        reader.Read();
                                        s = reader.Value;

                                    }

                                }
                            }
                        }
                        return s;

                    }
                    else
                    {
                        while (reader.Read())
                        {
                            //only detect start elements
                            if (reader.IsStartElement())
                            {
                                //get element name and switch off it
                                switch (reader.Name.ToString())
                                {
                                    case "MFGSpec":
                                        GlobalSettings.MFGSpec = reader.ReadElementContentAsString();
                                        break;
                                    case "SWSpec":
                                        GlobalSettings.SWSpec = reader.ReadElementContentAsString();
                                        break;
                                    case "SWRev":
                                        GlobalSettings.SWRev = reader.ReadElementContentAsString();
                                        break;
                                    case "EventName":
                                        GlobalSettings.EventName = reader.ReadElementContentAsString();
                                        break;
                                    case "DB":
                                        GlobalSettings.DB = reader.ReadElementContentAsString();
                                        break;
                                    case "ReadONly":
                                        GlobalSettings.ReadOnly = reader.ReadElementContentAsBoolean();
                                        break;

                                }
                            }
                        }
                        return s;
                    }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please ask for assistance from a qualified test engineer");
                return null;
            }

        }

        private void RtbStatus_TextChanged(object sender, EventArgs e)
        {   
            //Keeps the caret at the end of the message box.
            rtbStatus.SelectionStart = rtbStatus.Text.Length;
            rtbStatus.ScrollToCaret();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {   
            //Disable any other button functions until function has completed
            btnFail.Enabled = false;
            btnConfirm.Enabled = false;

            rtbStatus.AppendText(System.DateTime.Now + ": Pass Confirmed\n");
            btnConfirm.Enabled = false;
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            btnFail.Enabled = false;
            btnFail.BackColor = System.Drawing.Color.Gray;
            GlobalSettings.Result = "PASS";
            DataUpload();
            rtbStatus.AppendText(System.DateTime.Now + ": Data Uploaded\n");
            dataGridView1.DataSource = null;
            txtUnitSN.Text = "";

            //Re-enable buttons on exit.
            btnFail.Enabled = true;
            btnConfirm.Enabled = true;
        }
        private void ButtonFail_Click(object sender, EventArgs e)
        {
            //Disable any other button functions until function has completed
            btnFail.Enabled = false;
            btnConfirm.Enabled = false;

            rtbStatus.AppendText(System.DateTime.Now + ": Fail Confirmed\n");
            btnFail.BackColor = System.Drawing.Color.Gray;
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            GlobalSettings.Result = "FAIL";
            DataUpload();
            rtbStatus.AppendText(System.DateTime.Now + ": Data Uploaded\n");
            dataGridView1.DataSource = null;
            txtUnitSN.Text = "";

            //Re-enable buttons on exit.
            btnFail.Enabled = true;
            btnConfirm.Enabled = true;
        }

        public void DataUpload()
        {
            //StringBuilder errorMessages = new StringBuilder();
            //string str = "";

            try
            {

                DBManager.InsertVerification(txtUnitSN.Text, GlobalSettings.PN, 
                                             GlobalSettings.EventName, GlobalSettings.UserID, 
                                             GlobalSettings.Result, GlobalSettings.MFGSpec, 
                                             GlobalSettings.SWSpec, GlobalSettings.SWRev);



                //    SqlConnection connRemote = new SqlConnection(@"Data Source = Ventec-SQL" + GlobalSettings.DB + "; " +
                //                                                  "Integrated Security = SSPI; " +
                //                                                  "PersistSecurityInfo = False; " +
                //                                                  "Initial Catalog = Production_Test_Data");

                //    connRemote.Open();

                //    string query = "INSERT INTO dbo.Production_Test_AssemblyVerification (Serial," +
                //                                                "PartNumber," +
                //                                                "EventName," +
                //                                                "StartTime," +
                //                                                "OperatorID," +
                //                                                "ConfirmedResult," +
                //                                                "MFGSpec," +
                //                                                "SWSpec," +
                //                                                "SWRevision)" +
                //                                        "VALUES (@Serial," +
                //                                                "@PartNumber," +
                //                                                "@EventName," +
                //                                                "@StartTime," +
                //                                                "@OperatorID," +
                //                                                "@ConfirmedResult," +
                //                                                "@MFGSpec," +
                //                                                "@SWSpec," +
                //                                                "@SWRevision);";

                //    using (SqlCommand commandRemote = new SqlCommand(query, connRemote))
                //    {
                //        commandRemote.Parameters.Add("@Serial", System.Data.SqlDbType.NVarChar).Value = txtUnitSN.Text;
                //        commandRemote.Parameters.Add("@PartNumber", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.PN;
                //        commandRemote.Parameters.Add("@EventName", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.EventName;
                //        commandRemote.Parameters.Add("@StartTime", System.Data.SqlDbType.DateTime).Value = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");
                //        commandRemote.Parameters.Add("@OperatorID", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.UserID;
                //        commandRemote.Parameters.Add("@ConfirmedResult", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.Result;
                //        commandRemote.Parameters.Add("@MFGSpec", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.MFGSpec;
                //        commandRemote.Parameters.Add("@SWSpec", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.SWSpec;
                //        commandRemote.Parameters.Add("@SWRevision", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.SWRev;

                //        int result = commandRemote.ExecuteNonQuery();


                //        // Check Error
                //        if (result < 0)
                //        {
                //            MessageBox.Show("Error inserting data into Database!");
                //        }

                //    }

                //    connRemote.Close();
                //    return  str;

            }

            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                        "Error Number: " + ex.Errors[i].Number + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n\n");


                }

                MessageBox.Show(errorMessages.ToString());

            }

        }

        private void UpdateRecordCount(object sender, EventArgs e)
        {
            //Data source shows an extra blank row at end, subtract 1 for true count
            int count =  (this.dataGridView1.Rows.Count == 0 ? 0 : this.dataGridView1.Rows.Count - 1);
            this.RecordCount.Text = count.ToString();
            
        }
    }

    public static class GlobalSettings
    {
        public static string Table;
        public static string Description;
        public static string MFGSpec;
        public static string SWSpec;
        public static string SWRev;
        public static string EventName;
        public static string DB;
        public static string ST;
        public static string Result;
        public static bool ReadOnly;
        public static string PN;
        public static string UserName = System.Environment.UserName;
        public static string UserID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    }
}
