using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;

namespace TestDataVerificationTool
{
    public class DBManager
    {

        //const string DeviceDataQuery = @"SELECT
        //                         [Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestType]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[Serial]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[NC]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestName]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestResult]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[MfgStatus]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[StationID]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[OperatorID]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestLocation]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestLowLimit]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestHighLimit]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestValue]                              
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[StartDateTime]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestSpecDocument]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestSoftwareRevision]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestAbortCode]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[PartNumber]
        //                        ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[O2TimerOverride]
                                
        //                        FROM
        //                            (SELECT [Serial], [TestName], [MfgStatus], MAX([StartDateTime]) AS last_tested
        //                            FROM [Production_Test_Data].[dbo].[Production_Test_Final_Test]
        //                            WHERE ([Serial] LIKE @Serial) AND ([MfgStatus] LIKE @FT_Keyword)
        //                            GROUP BY [Serial], [TestName], [MfgStatus]) AS latest_tests
        //                        INNER JOIN
        //                        [Production_Test_Data].[dbo].[Production_Test_Final_Test]
        //                        ON
        //                        [Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestName] = latest_tests.[TestName] AND
        //                        [Production_Test_Data].[dbo].[Production_Test_Final_Test].[StartDateTime] = latest_tests.last_tested
        //                        [Production_Test_Data].[dbo].[Production_Test_Final_Test].[Serial] = latest_tests.[Serial]
        //                        ORDER BY[StartDateTime] DESC";

        const string DeviceDataQuery = @"SELECT
                             [Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestType]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[Serial]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[NC]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestName]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestResult]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[MfgStatus]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[StationID]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[OperatorID]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestLocation]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestLowLimit]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestHighLimit]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestValue]                              
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[StartDateTime]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestSpecDocument]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestSoftwareRevision]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestAbortCode]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[PartNumber]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[O2TimerOverride]
                            ,[Production_Test_Data].[dbo].[Production_Test_Final_Test].[OverallPassFail]

                                    FROM
                            (SELECT[Serial], [TestName], [MfgStatus], MAX([StartDateTime]) AS last_tested
                            FROM [Production_Test_Data].[dbo].[Production_Test_Final_Test]
                                WHERE ([Serial] LIKE @Serial) AND ([MfgStatus] LIKE @FT_Keyword)
                                AND NOT([TestName] LIKE 'UUT%Temperature')
                                AND NOT([TestName] LIKE 'Oxygen 3%Oxygen Concentration')
                                AND NOT([TestName] LIKE 'Oxygen 3%Time From Timer')
                                AND NOT([TestName] LIKE 'Oxygen 1%Alarm%')
                                AND NOT([TestName] LIKE 'Oxygen 3%Alarm%')

                                GROUP BY[Serial], [TestName], [MfgStatus]) AS latest_tests
                            INNER JOIN
                            [Production_Test_Data].[dbo].[Production_Test_Final_Test]
                                    ON
                            [Production_Test_Data].[dbo].[Production_Test_Final_Test].[TestName] = latest_tests.[TestName] AND
                            [Production_Test_Data].[dbo].[Production_Test_Final_Test].[StartDateTime] = latest_tests.last_tested AND
                            [Production_Test_Data].[dbo].[Production_Test_Final_Test].[Serial] = latest_tests.[Serial]
                            ORDER BY[StartDateTime] DESC";
        const string SubAssemblyDataQuery = @"SELECT * FROM dbo.{0} WHERE Serial LIKE @Serial ORDER BY [{1}] DESC";
        const string PartNumberQuery = @"SELECT DISTINCT [StockCode], [SerialDescription] FROM [InvSerialHead] WHERE [Serial] = @Serial";

        const string SerialParam = "@Serial";
        const string DateTimeParam = "@DateTimeCol";
        const string FTKeywordParam = "@FT_Keyword";
        


        public static SqlConnection ConnectToDatabase(string Location)
        {
            SqlConnection conn =
                new SqlConnection(ConfigurationManager.ConnectionStrings[Location].ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("An exception has occurred while connecting to the <{0}> database:\n{1}", e.Message, Location));
                //throw e;
            }


            return conn;
        }

        public static DataTable GetTestRecords(string TableName, string SerialNum, string OrderBy, ref SqlConnection conn)
        {
            SqlCommand query = new SqlCommand();

            query.Connection = conn;
            query.CommandType = CommandType.Text;
            query.CommandText = string.Format(SubAssemblyDataQuery, TableName, OrderBy);
            query.Parameters.AddWithValue(SerialParam, SerialNum);
            //query.Parameters/*.*/AddWithValue(DateTimeParam, OrderBy);

            DataTable Records = new DataTable();
            try
            {
                using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(query))
                {
                    sqlDataAdap.Fill(Records);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("An exception has occurred while retrieving test records:\n{0}", e.Message));
                throw e;
            }

            return Records;
        }

        public static DataTable GetFinalTestRecords(string TableName, string SerialNum, string OrderBy, ref SqlConnection conn)
        {
            string FT_Keyword = ConfigurationManager.AppSettings["FT_Keyword"];

            SqlCommand query = new SqlCommand();

            query.Connection = conn;
            query.CommandType = CommandType.Text;
            query.CommandText = DeviceDataQuery;
            query.Parameters.AddWithValue(SerialParam, SerialNum);
            query.Parameters.AddWithValue(FTKeywordParam, FT_Keyword);
            query.Parameters.AddWithValue(DateTimeParam, OrderBy);

            DataTable Records = new DataTable();
            try
            {


                //Testing shit
                //query.CommandText = "waitfor delay '00:00:05'"; //This line added to force the exception
                using (SqlDataAdapter sqlDataAdap = new SqlDataAdapter(query))
                {
                    //sqlDataAdap.SelectCommand.CommandTimeout = 1; //This line added to force exception
                    sqlDataAdap.Fill(Records); //This line threw the exception
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("An exception has occurred while retrieving test records:\n{0}", e.Message));
                throw e;
            }

            return Records;
        }

        public static (string, string) GetPartNumber(string SerialNum, ref SqlConnection conn)
        {
            string partnumber = null;
            string description = null;
            
            SqlCommand query = new SqlCommand();

            query.Connection = conn;
            query.CommandType = CommandType.Text;
            query.CommandText = PartNumberQuery;
            query.Parameters.AddWithValue(SerialParam, SerialNum);
            try
            {
                using (var reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            partnumber = Convert.ToString(reader["StockCode"]);
                            description = Convert.ToString(reader["SerialDescription"]);
                        }
                    }
                }
                query.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("An exception has occurred while retrieving the part number:\n{0}", e.Message));
                throw e;
            }

            return (partnumber, description);
        }

        public static void InsertVerification(string SerialNum, string PartNumber, string OperatorID, string Result, ref SqlConnection conn)                                  
        {
            if (!MassageConnection(ref conn))
            {
                return;
            }
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
            query.Parameters.Add("@EventName", System.Data.SqlDbType.NVarChar).Value = "TestDataVerification";
            query.Parameters.Add("@StartTime", System.Data.SqlDbType.DateTime).Value = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");
            query.Parameters.Add("@OperatorID", System.Data.SqlDbType.NVarChar).Value = OperatorID;
            query.Parameters.Add("@ConfirmedResult", System.Data.SqlDbType.NVarChar).Value = Result;
            query.Parameters.Add("@MFGSpec", System.Data.SqlDbType.NVarChar).Value = ConfigurationManager.AppSettings["MFGSpec"];
            query.Parameters.Add("@SWSpec", System.Data.SqlDbType.NVarChar).Value = ConfigurationManager.AppSettings["SWSpec"];
            query.Parameters.Add("@SWRevision", System.Data.SqlDbType.NVarChar).Value = ConfigurationManager.AppSettings["Revision"];

            try
            {
                int result = query.ExecuteNonQuery();
                // Check Error
                if (result < 0)
                {
                    throw new Exception("Error inserting verification data into database");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        private static bool MassageConnection(ref SqlConnection conn)
        {
            SqlCommand query = new SqlCommand("SELECT 1", conn);
            try
            {
                var ret = (int)query.ExecuteScalar();

                if (ret == 1) return true;
                else return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        
        }
    }
}