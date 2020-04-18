using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TestDataVerificationTool
{
    public class DBManager
    {
        private static SqlConnection ConnectToDatabase(string Location)
        {
            SqlConnection conn =
                new SqlConnection(ConfigurationManager.ConnectionStrings[Location].ConnectionString);

            return conn;
        }

        public static DataTable GetTestRecords(string TableName, string SerialNum, string OrderBy, string PN)
        {
            if (TableName == "Production_Test_Final_Test") return GetFinalTestRecords(TableName, SerialNum, OrderBy, PN); // Final test 

            SqlConnection conn = ConnectToDatabase(ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["TestDB"]);
            SqlCommand query = new SqlCommand();

            query.Connection = conn;
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM dbo." + TableName + " " +
                                "WHERE Serial = '" + SerialNum + "' " +
                                "ORDER BY " + OrderBy + " desc";

            DataTable Records = new DataTable();
            using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(query))
            {
                sqlDataAdap.Fill(Records);
            }

            return Records;
        }
        public static DataTable GetFinalTestRecords(string TableName, string SerialNum, string OrderBy, string PN)
        {
            string columns = "[TestType]" +
                              ",[Serial]" +
                              ",[NC]" +
                              ",[TestName]" +
                              ",[TestLowLimit]" +
                              ",[TestHighLimit]" +
                              ",[TestValue]" +
                              ",[TestResult]" +
                              ",[OperatorID]" +
                              ",[StationID]" +
                              ",[StartDateTime]" +
                              ",[StopDateTime]" +
                              ",[TestSpecDocument]" +
                              ",[TestSoftwareRevision]" +
                              ",[TestAbortCode]" +
                              ",[OverallPassFail]" +
                              ",[Alarms]" +
                              ",[AlarmDetails]" +
                              ",[PartNumber]" +
                              ",[O2TimerOverride]" +
                              ",[UDI]" +
                              ",[TestLocation]" +
                              ",[MfgStatus]";

            SqlConnection conn = ConnectToDatabase(ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["TestDB"]);
            SqlCommand query = new SqlCommand();

            query.Connection = conn;
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT " + columns + " FROM dbo." + TableName + " " +
                                "WHERE Serial = '" + SerialNum + "' " +
                                "ORDER BY " + OrderBy + " desc";

            DataTable Records = new DataTable();
            using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(query))
            {
                sqlDataAdap.Fill(Records);
            }


            return Records;
        }

        public static string GetPartNumber(string SerialNum)
        {
            string partnumber = null;
            SqlConnection conn = ConnectToDatabase(ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["SysproDB"]);
            SqlCommand query = new SqlCommand();

            query.Connection = conn;
            query.CommandType = CommandType.Text;
            query.CommandText = "Select distinct StockCode " +
                                "From InvSerialTrn " +
                                "Where Serial = '" + SerialNum + "'";

            conn.Open();
            using (var reader = query.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        partnumber = Convert.ToString(reader["StockCode"]);
                    }
                }
                else
                {
                    partnumber = null;
                }
            }
            query.Dispose();

            return partnumber;
        }

        public static void InsertVerification(string SerialNum,
                                                string PartNumber,
                                                string EventName,
                                                string OperatorID,
                                                string Result,
                                                string MFGSpec,
                                                string SWSpec,
                                                string SWRevision)
        {

            SqlConnection conn = ConnectToDatabase(ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["VerificationDB"]);
            SqlCommand query = new SqlCommand();

            query.Connection = conn;
            query.CommandType = CommandType.Text;
            query.CommandText = "INSERT INTO dbo.Production_Test_AssemblyVerification (Serial," +
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

            query.Parameters.Add("@Serial", System.Data.SqlDbType.NVarChar).Value = SerialNum;
            query.Parameters.Add("@PartNumber", System.Data.SqlDbType.NVarChar).Value = PartNumber;
            query.Parameters.Add("@EventName", System.Data.SqlDbType.NVarChar).Value = EventName;
            query.Parameters.Add("@StartTime", System.Data.SqlDbType.DateTime).Value = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");
            query.Parameters.Add("@OperatorID", System.Data.SqlDbType.NVarChar).Value = OperatorID;
            query.Parameters.Add("@ConfirmedResult", System.Data.SqlDbType.NVarChar).Value = Result;
            query.Parameters.Add("@MFGSpec", System.Data.SqlDbType.NVarChar).Value = MFGSpec;
            query.Parameters.Add("@SWSpec", System.Data.SqlDbType.NVarChar).Value = SWSpec;
            query.Parameters.Add("@SWRevision", System.Data.SqlDbType.NVarChar).Value = SWRevision;

            conn.Open();
            try
            {
                int result = query.ExecuteNonQuery();
                // Check Error
                if (result < 0)
                {
                    throw new Exception("Error inserting verification data into database");
                }
            }
            catch(Exception e)
            {
                conn.Close();
                throw e;
            }
            conn.Close();

            

        }
    }
}
