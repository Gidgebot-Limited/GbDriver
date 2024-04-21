using GbDriver.Helpers;
using GbDriver.Pages;
using OpenQA.Selenium;

namespace GbDriver
{
    [TestClass]
    public class c4_gbMediaStorage
    {
        private IWebDriver? chrome;
        private CSV_Data? csv, csvGbData;
        private Gb_Data? gbData;

        [TestInitialize]
        public void TestInitialize()
        {
            csv = new CSV_Data();
            csvGbData = csv.ReadGbData();

            chrome = new NewChromeDriver().driver;
            chrome.Manage().Window.Maximize();

            gbData = new Gb_Data();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            csvGbData = csv = null;
            gbData = null;
            if (!(chrome == null))
            {
                chrome.Close();
                chrome.Quit();
            }
            chrome = null;
        }



        [TestMethod]
        public void t1_Billing_Enabled()
        {
            var ssDirPath = gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/";
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (csvGbData.Read()[i].Split(",")[0].Equals("Billing Enabled"))
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.topNav.lnkMedia.Click();

                    GbUploads gbUploads = new GbUploads(chrome);
                    gbUploads.acUploadMedia.Click();
                    gbUploads.TcScreenshot(ssDirPath + "UploadsAccordian_yesBill.png");
                    gbUploads.topNav.logout();
                }
            }
        }

        [TestMethod]
        public void t2_Subscribe_Default()
        {
            var ssDirPath = gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/";
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (csvGbData.Read()[i].Split(",")[0].Equals("Default Method"))
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();
                    GbDashboard gbDashboard = new GbDashboard(chrome);

                    gbDashboard.topNav.lnkMedia.Click();

                    GbUploads gbUploads = new GbUploads(chrome);
                    gbUploads.acUploadMedia.Click();
                    gbUploads.TcScreenshot(ssDirPath + "UploadsAccordian_yesDefault.png");
                    gbUploads.btnSubscribe.Click();
                    gbUploads.TcScreenshot(ssDirPath + "Subscribe_yesDefault.png");

                    GbSubscribe gbSubscribe = new GbSubscribe(chrome);
                    gbSubscribe.topNav.logout();
                }
            }
        }

        [TestMethod]
        public void t3_Subscriber()
        {
            var ssDirPath = gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/";
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (csvGbData.Read()[i].Split(",")[0].Equals("Media Subscriber"))
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.topNav.lnkMedia.Click();

                    GbUploads gbUploads = new GbUploads(chrome);
                    gbUploads.acUploadMedia.Click();
                    gbUploads.TcScreenshot(ssDirPath + "UploadsAccordian_yesBill.png");
                    gbUploads.topNav.logout();
                }
            }
        }


    }


    [TestClass]
    public class c4a_gbUploads
    {
        private IWebDriver? chrome;
        private CSV_Data? csv, csvGbData;
        private Gb_Data? gbData;

        [TestInitialize]
        public void TestInitialize()
        {
            csv = new CSV_Data();            
            csvGbData    = csv.ReadGbData();

            chrome = new NewChromeDriver().driver;
            chrome.Manage().Window.Maximize();

            gbData = new Gb_Data();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            csvGbData =  csv =  null;
            gbData = null;
            if (!(chrome == null)) {
                chrome.Close();
                chrome.Quit();
            }
            chrome = null;
        }

        [TestMethod]
        public void t1_unVerified()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            foreach (var userData in csvGbData.Read())
            {
                if (userData.Split(",")[0].Equals("Verified User"))
                {
                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.topNav.lnkMedia.Click();
                    GbUploads gbUploads = new GbUploads(chrome);
                    gbUploads.acUploadMedia.Click();
                    gbUploads.TcScreenshot(ssDirPath + "UploadsAccordian_verified.png");
                    gbUploads.topNav.logout();
                } 
                else if (userData.Split(",")[0].Equals("Unverified User"))
                {
                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);                
                    gbLogin.btnLogin.Click();
                    
                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.topNav.lnkMedia.Click();
                    
                    GbBasePage nextPage = new GbBasePage(chrome);
                    nextPage.TcScreenshot(ssDirPath + "Verify.png");
                    Assert.AreEqual(chrome.Url, "https://www.gidgebot.com/verify-email");
                    nextPage.logout();
                }
            }
        }

        //[TestMethod]
        public void t2_Verified()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            for (int i = 0 ; i < csvGbData.Read().Count; i++)  
            {
                if (csvGbData.Read()[i].Split(",")[0].Equals("Verified User"))
                {
                    var userData = csvGbData.Read()[i]; 

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);                
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.topNav.lnkMedia.Click();
                    GbUploads gbUploads = new GbUploads(chrome);
                    gbUploads.acUploadMedia.Click();
                    gbUploads.TcScreenshot(ssDirPath + "UploadsAccordian_noBill.png");    
                    gbUploads.topNav.logout();               

                }
            }
        }
        [TestMethod]
        public void t2_Create()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (csvGbData.Read()[i].Split(",")[0].Equals("Media Subscriber"))
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.topNav.lnkMedia.Click();

                    GbUploads gbUploads = new GbUploads(chrome);
                    gbUploads.acUploadMedia.Click();
                    gbUploads.TcScreenshot(ssDirPath + "UploadsAccordian.png");
                    
                    gbUploads.filesSelect.SendKeys(Path.GetFullPath(ssDirPath + "UploadsAccordian.png"));
                    gbUploads.btnUpload.Click();

                    GbBasePage topNav = new GbBasePage(chrome);
                    gbUploads.TcScreenshot(ssDirPath + "UploadsAccordian_result.png");
                    topNav.logout();
                }
            }
        }

        [TestMethod]
        public void t3_Delete()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (csvGbData.Read()[i].Split(",")[0].Equals("Media Subscriber"))
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.topNav.lnkMedia.Click();

                    GbUploads gbUploads = new GbUploads(chrome);

                    gbUploads.getLnkFirstEdit().Click();

                    GbUploadEdit gbUploadEdit = new GbUploadEdit(chrome);
                    gbUploads.TcScreenshot(ssDirPath + "Upload_Edit.png");


                    gbUploadEdit.WaitScroll(gbUploadEdit.btnDelete).Click();
                    gbUploads.TcScreenshot(ssDirPath + "Upload_Delete.png");

                    gbUploadEdit.txtPassword.SendKeys("password");

                    gbUploadEdit.btnConfirmDelete.Click();
                    gbUploads.TcScreenshot(ssDirPath + "Upload_Confirm_Delete.png");

                    GbBasePage topNav = new GbBasePage(chrome);
                    topNav.logout();

                }
            }
        }
    }
}