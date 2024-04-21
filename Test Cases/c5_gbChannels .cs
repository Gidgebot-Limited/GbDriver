using GbDriver.Helpers;
using GbDriver.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GbDriver
{

    [TestClass]
    public class c5_gbChannels
    {
        private IWebDriver? chrome;
        private CSV_Data? csv, csvDUMMYData, csvGbData;
        private Gb_Data? gbData;

        [TestInitialize]
        public void TestInitialize()
        {
            csv = new CSV_Data();
            csvDUMMYData = csv.ReadDummyData();
            csvGbData = csv.ReadGbData();

            chrome = new NewChromeDriver().driver;
            chrome.Manage().Window.Maximize();

            gbData = new Gb_Data();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            csvDUMMYData = csvGbData = csv = null;
            gbData = null;
            if (!(chrome == null))
            {
                chrome.Close();
                chrome.Quit();
            }
            chrome = null;
        }

        //[TestMethod]
        public void t4_unVerified()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            foreach (var userData in csvGbData.Read())
            {
                if (userData.Split(",")[0].Equals("Verified User"))
                {
                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.TcScreenshot(ssDirPath + "DashBoard_Verified.png");
                    gbDashboard.topNav.logout();
                }
                else if (userData.Split(",")[0].Equals("Unverified User"))
                {
                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.TcScreenshot(ssDirPath + "DashBoard_unVerified.png");
                    gbDashboard.topNav.logout();
                }
            }
        }

        //[TestMethod]
        public void t4a_unVerified_Fill()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (csvGbData.Read()[i].Split(",")[0].Equals("Unverified User"))
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.acNewChannel.Click();
                    gbDashboard.TcScreenshot(ssDirPath + "DashBoard_Verified_acNewChannel.png");
                    gbDashboard.acNewChannel.Click();


                    gbDashboard.fillTD();
                    gbDashboard.TcScreenshot(ssDirPath + "DashBoard_Verified_Fill_acNewChannel.png");

                    gbDashboard.topNav.logout();

                }
                else if (csvGbData.Read()[i].Split(",")[0].Equals("Verified User"))
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.acNewChannel.Click();
                    gbDashboard.TcScreenshot(ssDirPath + "DashBoard_Verified_acNewChannel.png");
                    gbDashboard.acNewChannel.Click();


                    gbDashboard.fillTD();
                    gbDashboard.TcScreenshot(ssDirPath + "DashBoard_Verified_Fill_acNewChannel.png");

                    gbDashboard.topNav.logout();
                }
            }
        }

        [TestMethod]
        public void t1_Create()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (
                    csvGbData.Read()[i].Split(",")[0].Equals("Unverified User")
                    ||
                    csvGbData.Read()[i].Split(",")[0].Equals("Verified User")
                    )
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.Pause(TimeSpan.FromSeconds(0.3));
                    gbLogin.btnLogin.Click();
                    gbLogin.Pause(TimeSpan.FromSeconds(0.3));
                    
                    GbDashboard gbDashboard = new GbDashboard(chrome);
      

                    gbDashboard.fillTD();
                    gbDashboard.TcScreenshot(ssDirPath + "Channels_Subcriber_Create_Fill.png");


                    gbDashboard.btnCreate.Click();

                    GbBasePage topnav = new GbBasePage(chrome);
                    topnav.logout();
                }
                if (
                    csvGbData.Read()[i].Split(",")[0].Equals("Media Subscriber")
                    )
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.Pause(TimeSpan.FromSeconds(0.3));
                    gbLogin.btnLogin.Click();
                    gbLogin.Pause(TimeSpan.FromSeconds(0.3));

                    GbDashboard gbDashboard = new GbDashboard(chrome);


                    gbDashboard.fillTD();
                    gbDashboard.TcScreenshot(ssDirPath + "Channels_Subcriber_Create_Fill.png");

                    gbDashboard.openChannelImageRdo(chrome);
                    gbDashboard.rdoCImageUp.Click();
                    gbDashboard.fileCImage.SendKeys(Path.GetFullPath(ssDirPath + "Channels_Subcriber_Create_Fill.png"));
                    gbDashboard.TcScreenshot(ssDirPath + "Channels_Subcriber_Create_rdoCImage.png");

                    //gbDashboard.openItemImageRdo(chrome);
                    //gbDashboard.rdoIImageUp.Click();
                    //gbDashboard.fileIImage.SendKeys(Path.GetFullPath(ssDirPath + "Channels_Subcriber_Create_Fill.png"));
                    //gbDashboard.TcScreenshot(ssDirPath + "Channels_Subcriber_Create_rdoIImage.png");

                    //gbDashboard.openEnclosureRdo(chrome);
                    //gbDashboard.rdoEnclosureUp.Click();
                    //gbDashboard.fileEnclosure.SendKeys(Path.GetFullPath(ssDirPath + "Channels_Subcriber_Create_Fill.png"));
                    //gbDashboard.TcScreenshot(ssDirPath + "Channels_Subcriber_Create_rdoEnclosure.png");


                    // create w 3 uploads
                    gbDashboard.btnCreate.Click();

                    GbBasePage topnav = new GbBasePage(chrome);
                    topnav.logout();
                }

            }
        }
        [TestMethod]
        public void t2_Drop_Each_Channel()
        {
            var ssDirPath = gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/";
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (
                    csvGbData.Read()[i].Split(",")[0].Equals("Unverified User")
                    ||
                    csvGbData.Read()[i].Split(",")[0].Equals("Verified User")
                    ||
                    csvGbData.Read()[i].Split(",")[0].Equals("Media Subscriber")
                    )
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.btnLogin.Click();

                    GbDashboard gbDashboard = new GbDashboard(chrome);
                    gbDashboard.dropEachChannel(chrome);

                    GbBasePage topnav = new GbBasePage(chrome);
                    topnav.logout();
                }
            }
        }
        [TestMethod]
        public void t3_Drop_Each_Upload()
        {
            var ssDirPath = gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/";
            for (int i = 0; i < csvGbData.Read().Count; i++)
            {
                if (csvGbData.Read()[i].Split(",")[0].Equals("Media Subscriber"))
                {
                    var userData = csvGbData.Read()[i];

                    GbLogin gbLogin = new GbLogin(chrome).Login(userData);
                    gbLogin.Pause(TimeSpan.FromSeconds(0));
                    gbLogin.btnLogin.Click();

                    GbUploads gbUploads = new GbUploads(chrome);
                    gbUploads.dropEachUpload(chrome);

                    GbBasePage topnav = new GbBasePage(chrome);
                    topnav.logout();
                }
            }
        }
    }
}