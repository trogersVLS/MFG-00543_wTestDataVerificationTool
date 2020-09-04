using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using System.Threading.Tasks;

namespace TestDataVerificationTool
{
    public enum ACTION_TYPE
    {
        Debug,
        Status,
        Error,
        PartNumber, 
        Database
    }
    public class FinalDevice
    {
        public string partnumber { get; set; }
        public int numtests { get; set; }
    }

    public class TestTable
    {
        public string TableName { get; set; }
        public string Keyword { get; set; }
        public string DateTimeCol { get; set; }
        public List<FinalDevice> FinalDevices { get; set; }
    }

    public class Root
    {
        public List<TestTable> TestTables { get; set; }
    }


    public class Part
    {
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string Serial { get; set; }
        
    }

    
    class VerfApp
    {
        private SqlConnection SysproConn;
        private SqlConnection TestDataConn;

        private List<TestTable> TestTables;

        public Part CurrentPart;
        public VerfApp()
        {

            //Initialize TableName Dictionary.
            TestTables = LoadJSON(ConfigurationManager.AppSettings["ConfigPath"]);
            //Initialize database connections
            
        }

        public async Task<bool> Reconnect()
        {
            
            this.SysproConn = DBManager.ConnectToDatabase(ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["SysproDB"]);
            this.TestDataConn = DBManager.ConnectToDatabase(ConfigurationManager.AppSettings["Location"] + ConfigurationManager.AppSettings["TestDataDB"]);

            if (this.SysproConn == null || this.TestDataConn == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool RequiresTestData(string description)
        {
            foreach (TestTable entry in this.TestTables)
            {
                if (description.Contains(entry.Keyword) && !description.Contains("MBM"))
                {

                    return true;
                }
            }
            return false;
        }
        public bool FinalTestNumbersCheck(string partnumber, int passingtests)
        {   
            foreach(TestTable parts in TestTables)
            {
                if(parts.FinalDevices != null)
                {
                    foreach(FinalDevice device in parts.FinalDevices)
                    {
                        if (partnumber.Contains(device.partnumber))
                        {
                            if(passingtests == device.numtests)
                            {
                                return true;

                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            
            return true;
        }

        //Applications primary functions
        public bool GetTestData(string serial, out DataTable testData, out string partnumber, out string description, out string tablename)
        {
            
            tablename = null;
            string datetimecol = null;


            //Need part number in order to get test data.
            if (GetPartNumber(serial, out partnumber, out description))
            {
                foreach (TestTable entry in this.TestTables)
                {   
                    //Ignore MBM's because we do not test them.
                    if (!partnumber.Contains("MBM") && description.Contains(entry.Keyword))
                    {
                        tablename = entry.TableName;
                        datetimecol = entry.DateTimeCol;
                        break;
                    }
           
                }
                if (tablename != null)
                {
                    if (tablename.Contains("Final")) testData = GetFinalTestData(serial, tablename, datetimecol);
                    else testData = GetSubTestData(serial, tablename, datetimecol);
                    if (testData != null)
                        return true;
                    else return false;
                }
                else
                {
                    testData = null;
                    return false;
                }
            }
            else
            {
                testData = null;
                return false;
            }
        }
        public void InsertVerf(bool pass, string OperatorID)
        {
            string Result;
            if (pass) Result = "PASS";
            else Result = "FAIL";

            DBManager.InsertVerification(CurrentPart.Serial, CurrentPart.PartNumber, OperatorID, Result, ref TestDataConn);
        }
        //Applications background functions
        private bool GetPartNumber(string serial, out string partNumber, out string description)
        {
            (partNumber, description) = DBManager.GetPartNumber(serial, ref SysproConn);

            if ((partNumber != null) && (description != null))
            {
                CurrentPart = new Part();
                CurrentPart.PartNumber = partNumber;
                CurrentPart.Serial = serial;

                return true;
            }
            else return false;
        }


        private DataTable GetSubTestData(string serial, string table, string datetimecol)
        {
            DataTable data;

            data = DBManager.GetTestRecords(table, serial, datetimecol, ref TestDataConn);
            return data;
        }

        private DataTable GetFinalTestData(string serial, string table, string datetimecol)
        {
            DataTable data;

            data = DBManager.GetFinalTestRecords(table, serial, datetimecol, ref TestDataConn);
            return data;
        }

        //Helper functions
        private List<TestTable> LoadJSON(string path)
        {   
            string jsonTestTables;
            if (File.Exists(path)) jsonTestTables = File.ReadAllText(path);
            else jsonTestTables = null;
    
            Root tests = (Root)JsonConvert.DeserializeObject<Root>(jsonTestTables);
            if (tests != null) return tests.TestTables;
            else return null;
            
        }

        
        

    }
}
