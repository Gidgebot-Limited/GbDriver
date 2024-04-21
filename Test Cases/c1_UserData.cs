using System.Collections.Generic;
using CsvHelper;
using System.Globalization;
using System.IO;
using OpenQA.Selenium;
using GbDriver.Helpers;

namespace GbDriver
{
    [TestClass]
    public class c1_UserData
    {
        private CSV_Data? csv, csvDUMMYData, csvGbData;

        [TestInitialize]
        public void TestInitialize()
        {
            csv = new CSV_Data();            
            csvDUMMYData = csv.ReadDummyData();
            csvGbData    = csv.ReadGbData();
        }
      
        [TestCleanup]
        public void TestCleanup()
        {
            csvDUMMYData = csvGbData =  csv = null;
        }

        [TestMethod]
        public void t1_Data_Exists()
        {
            Assert.IsNotNull(csvGbData.Read());
            Assert.IsNotNull(csvDUMMYData.Read());
        }

        [TestMethod]
        public void t2_Read_Data()
        {
            Assert.IsTrue(csvGbData.Read().Count > 0, "No data was read.");
            foreach (var userData in csvGbData.Read())
            {
                string name, email, password;
                string[] splits = userData.Split(',');
                name = splits[0];
                email = splits[1];
                password = splits[2];
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Password: " + password);
                Assert.IsNotNull(name);
                Assert.IsNotNull(email);
                Assert.IsNotNull(password);
            }
            Assert.IsTrue(csvDUMMYData.Read().Count > 0, "No data was read.");
            foreach (var userData in csvDUMMYData.Read())
            {
                string name, email, password;
                string[] splits = userData.Split(',');
                name = splits[0];
                email = splits[1];
                password = splits[2];
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Password: " + password);
                Assert.IsNotNull(name);
                Assert.IsNotNull(email);
                Assert.IsNotNull(password);
            }
        }
    }
}