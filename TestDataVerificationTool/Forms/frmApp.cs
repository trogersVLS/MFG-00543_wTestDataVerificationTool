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

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FrmAbout())
            {
                var result = form.ShowDialog();
                // if (result == DialogResult.OK)
                // {
                //     string val = form.ReturnValue1;   //this is here just to hold the fail screen and let the operator see what failed.
                // }

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
                }
                QueryFromDB(txtUnitSN.Text);

                if (GlobalSettings.ReadOnly == false)
                {
                    button1.Enabled = true;
                    btnConfirm.Enabled = true;
                    btnConfirm.BackColor = System.Drawing.Color.Green;
                    button1.BackColor = System.Drawing.Color.Red;
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
            string query;

            try
            {
                string location = ConfigurationManager.AppSettings["Location"];
                //query from database
                SqlConnectionStringBuilder sqlconn = new SqlConnectionStringBuilder
                {
                    DataSource = ConfigurationManager.AppSettings["db_path"],
                    IntegratedSecurity = true,
                    PersistSecurityInfo = false,
                    InitialCatalog = "SYSPROVLSZ"
                };
                if (location == "Kokomo")
                {
                    sqlconn.UserID = ConfigurationManager.AppSettings["db_user"];
                    sqlconn.Password = ConfigurationManager.AppSettings["db_pass"];
                    sqlconn.IntegratedSecurity = false;
                }
                else
                {
                    //sqlconn.UserID = ConfigurationManager.AppSettings["db_user"];
                    //sqlconn.Password = ConfigurationManager.AppSettings["db_pass"];
                    sqlconn.IntegratedSecurity = true;
                }
                


                // Connect to SQL
                rtbStatus.AppendText("\n" + System.DateTime.Now + ": Getting Part Number from Syspro DB");


                query = "Select distinct StockCode " +
                        "From InvSerialTrn " +
                        "Where Serial = '" + SN + "'";
                

                SqlConnection connection = new SqlConnection(sqlconn.ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = query
                };

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GlobalSettings.PN = Convert.ToString(reader["StockCode"]);
                            rtbStatus.AppendText(" - Done");

                        }

                    }
                    else
                    {
                        rtbStatus.AppendText(System.DateTime.Now + "\n: No Part Numbers were found for this Serial Number in Syspro\n");
                    }

                }

                command.Dispose();
                


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
            string query;

            try
            {
                string location = ConfigurationManager.AppSettings["Location"];
                //query from database
                SqlConnectionStringBuilder sqlconn = new SqlConnectionStringBuilder
                {
                    DataSource = ConfigurationManager.AppSettings["db_path"],
                    IntegratedSecurity = true,
                    PersistSecurityInfo = false,
                    InitialCatalog = "Production_Test_Data"
                };
                if (location == "Kokomo")
                {
                    sqlconn.UserID = ConfigurationManager.AppSettings["db_user"];
                    sqlconn.Password = ConfigurationManager.AppSettings["db_pass"];
                    sqlconn.IntegratedSecurity = false;
                }
                else
                {
                    //sqlconn.UserID = ConfigurationManager.AppSettings["db_user"];
                    //sqlconn.Password = ConfigurationManager.AppSettings["db_pass"];
                    sqlconn.IntegratedSecurity = true;
                }

                // Connect to SQL
                rtbStatus.AppendText("\n" + System.DateTime.Now + ": Checking test database for existing tests");

                query = "Select * " +
                        "From dbo.Production_Test_" + GlobalSettings.Table + " " +
                        "where Serial = '" + SN + "' " +
                        "order by " + GlobalSettings.ST + " desc";

                
                if (GlobalSettings.Table != "")
                {
                    SqlConnection connection2 = new SqlConnection(sqlconn.ConnectionString);

                    SqlCommand sqlCmd = new SqlCommand
                    {
                        Connection = connection2,
                        CommandType = CommandType.Text,
                        CommandText = query
                    };
                    using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd))
                    {
                        DataTable dtRecord = new DataTable();
                        sqlDataAdap.Fill(dtRecord);
                        dataGridView1.DataSource = dtRecord;

                    }
                    rtbStatus.AppendText(" - Done");
                }
                else
                {
                    rtbStatus.AppendText("\n" + System.DateTime.Now + ": Records for " + GlobalSettings.PN + " could not be found in any test data table listed in Settings.XML\n");
                }


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (object.Equals(row.Cells[dataGridView1.Columns["OverallPassFail"].Index].Value, "PASS"))
                    {
                        /*  change color of cell*/
                        row.Cells[dataGridView1.Columns["OverallPassFail"].Index].Style.BackColor = Color.Green;
                        row.Cells[dataGridView1.Columns["OverallPassFail"].Index].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }

                    if (object.Equals(row.Cells[dataGridView1.Columns["OverallPassFail"].Index].Value, "FAIL"))
                    {
                        /*  change color of cell*/
                        row.Cells[dataGridView1.Columns["OverallPassFail"].Index].Style.BackColor = Color.Red;
                        row.Cells[dataGridView1.Columns["OverallPassFail"].Index].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }

                }


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

        private void FrmApp_Load(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            button1.Enabled = false;
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            button1.BackColor = System.Drawing.Color.Gray;
            operatorID.Text = GlobalSettings.UserID;
            //cboOpID.DataSource = GetOperatorIDs();
            //cboOpID.DisplayMember = "operator";
            //cboOpID.SelectedIndex = -1;
            lblDescription.Text = "";
        }

        private DataTable GetOperatorIDs()
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    //Settings Path
                    var s = ConfigurationManager.AppSettings["config_path"];
                    ds.ReadXml(ConfigurationManager.AppSettings["config_path"]);
                    DataTable dt = ds.Tables["operatorID"];
                    return dt;
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Please ask for assistance from a qualified test engineer.");
                Application.Exit();
                return null;
            }
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

                using (XmlReader reader = XmlReader.Create(ConfigurationManager.AppSettings["config_path"]))

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
            rtbStatus.SelectionStart = rtbStatus.Text.Length;
            rtbStatus.ScrollToCaret();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            rtbStatus.AppendText(System.DateTime.Now + ": Pass Confirmed\n");
            btnConfirm.Enabled = false;
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            button1.Enabled = false;
            button1.BackColor = System.Drawing.Color.Gray;
            GlobalSettings.Result = "PASS";
            DataUpload();
            rtbStatus.AppendText(System.DateTime.Now + ": Data Uploaded\n");
            dataGridView1.DataSource = null;
            txtUnitSN.Text = "";
            
            
        }

        public string DataUpload()
        {
            StringBuilder errorMessages = new StringBuilder();
            string str = "";

            try
            {



                SqlConnection connRemote = new SqlConnection(@"Data Source = Ventec-SQL" + GlobalSettings.DB + "; " +
                                                              "Integrated Security = SSPI; " +
                                                              "PersistSecurityInfo = False; " +
                                                              "Initial Catalog = Production_Test_Data");

                connRemote.Open();

                string query = "INSERT INTO dbo.Production_Test_AssemblyVerification (Serial," +
                                                            "PartNumber," +
                                                            "EventName," +
                                                            "StartTime," +
                                                            "OperatorID," +
                                                            "ConfirmedResult," +
                                                            "MFGSpec," +
                                                            "SWSpec," +
                                                            "SWRevision)" +
                                                    "VALUES (@Serial," +
                                                            "@PartNumber," +
                                                            "@EventName," +
                                                            "@StartTime," +
                                                            "@OperatorID," +
                                                            "@ConfirmedResult," +
                                                            "@MFGSpec," +
                                                            "@SWSpec," +
                                                            "@SWRevision);";

                using (SqlCommand commandRemote = new SqlCommand(query, connRemote))
                {
                    commandRemote.Parameters.Add("@Serial", System.Data.SqlDbType.NVarChar).Value = txtUnitSN.Text;
                    commandRemote.Parameters.Add("@PartNumber", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.PN;
                    commandRemote.Parameters.Add("@EventName", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.EventName;
                    commandRemote.Parameters.Add("@StartTime", System.Data.SqlDbType.DateTime).Value = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");
                    commandRemote.Parameters.Add("@OperatorID", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.UserID;
                    commandRemote.Parameters.Add("@ConfirmedResult", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.Result;
                    commandRemote.Parameters.Add("@MFGSpec", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.MFGSpec;
                    commandRemote.Parameters.Add("@SWSpec", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.SWSpec;
                    commandRemote.Parameters.Add("@SWRevision", System.Data.SqlDbType.NVarChar).Value = GlobalSettings.SWRev;

                    int result = commandRemote.ExecuteNonQuery();


                    // Check Error
                    if (result < 0)
                    {
                        MessageBox.Show("Error inserting data into Database!");
                    }

                }

                connRemote.Close();
                return  str;

            }

            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Message: " + ex.Errors[i].Message + "\n" +
                        "Error Number: " + ex.Errors[i].Number + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n\n");


                }

                MessageBox.Show(errorMessages.ToString());
                
                return null;

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            rtbStatus.AppendText(System.DateTime.Now + ": Fail Confirmed\n");
            button1.Enabled = false;
            button1.BackColor = System.Drawing.Color.Gray;
            btnConfirm.Enabled = false;
            btnConfirm.BackColor = System.Drawing.Color.Gray;
            GlobalSettings.Result = "FAIL";
            DataUpload();
            rtbStatus.AppendText(System.DateTime.Now + ": Data Uploaded\n");
            dataGridView1.DataSource = null;
            txtUnitSN.Text = "";

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
