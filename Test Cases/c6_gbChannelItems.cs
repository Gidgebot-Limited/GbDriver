using GbDriver.Helpers;
using GbDriver.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GbDriver
{
    [TestClass]
    public class c6_gbChannelItems
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
        public void t1_Dash_Create()
        {
            var ssDirPath = gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/";
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
                    //gbDashboard.acNewChannel.Click();

                    gbDashboard.fillTD();

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

                    gbDashboard.openItemImageRdo(chrome);
                    gbDashboard.rdoIImageUp.Click();
                    gbDashboard.fileIImage.SendKeys(Path.GetFullPath(ssDirPath + "Channels_Subcriber_Create_Fill.png"));
                    gbDashboard.TcScreenshot(ssDirPath + "Channels_Subcriber_Create_rdoIImage.png");

                    gbDashboard.openEnclosureRdo(chrome);
                    gbDashboard.rdoEnclosureUp.Click();
                    gbDashboard.fileEnclosure.SendKeys(Path.GetFullPath(ssDirPath + "Channels_Subcriber_Create_Fill.png"));
                    gbDashboard.TcScreenshot(ssDirPath + "Channels_Subcriber_Create_rdoEnclosure.png");

                    gbDashboard.btnCreate.Click();

                    GbBasePage topnav = new GbBasePage(chrome);
                    topnav.logout();
                }

            }
        }

        [TestMethod]
        public void t2_Create_Next()
        {
            var ssDirPath = gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/";
            int x = 1;
            string title = "Selenium Testing";
            string descr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nec aliquet quam. Duis consectetur ante vitae justo lacinia vehicula. Sed ac velit " +
                            "vitae ex tincidunt ultricies. Integer sollicitudin, justo sit amet dapibus hendrerit, dolor velit venenatis sapien, at viverra est libero vel lorem. Sed.";

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
                    GbChannelEdit gbChannelEdit;
                    gbDashboard.getBtnFirstEdit().Click();
                    for (int j = 0; j < x; j++) 
                    { 
                        gbChannelEdit = new GbChannelEdit(chrome);
                        gbChannelEdit.acCreateNext.Click();

                        gbChannelEdit.WaitScroll(gbChannelEdit.txtTitleNext).SendKeys(title);
                        gbChannelEdit.WaitScroll(gbChannelEdit.txtDescNext).SendKeys(descr); 

                        gbChannelEdit.WaitScroll(gbChannelEdit.btnCreateNext).Click();
                    }



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
                    gbDashboard.getBtnFirstEdit().Click();
                    GbChannelEdit gbChannelEdit = new GbChannelEdit(chrome);
                    for (int j = 0; j < x; j++)
                    {
                        gbChannelEdit.WaitScroll(gbChannelEdit.acCreateNext).Click();


                        gbChannelEdit.WaitScroll(gbChannelEdit.txtTitleNext).SendKeys(title);
                        gbChannelEdit.WaitScroll(gbChannelEdit.txtDescNext).SendKeys(descr);

                        gbChannelEdit.WaitScroll(gbChannelEdit.acItemProps).Click();
                        gbChannelEdit.WaitScroll(gbChannelEdit.chkImageNext).Click();
                        gbChannelEdit.WaitScroll(chrome.FindElement(By.XPath("//*[@id=\"itemImageLocation_upload\"]"))).Click();
                        gbChannelEdit.TcScreenshot(ssDirPath + "Channels_Subcriber_Create_Next.png");
                        gbChannelEdit.WaitScroll(chrome.FindElement(By.XPath("//*[@id=\"itemimage\"]"))).SendKeys(Path.GetFullPath(ssDirPath + "Channels_Subcriber_Create_Next.png"));

                        gbChannelEdit.WaitScroll(gbChannelEdit.btnCreateNext).Click();
                            
                    }


                    GbBasePage topnav = new GbBasePage(chrome);
                    topnav.logout();
                }

            }
        }
        [TestMethod]
        public void t3_Drop_Each_Channel()
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
        public void t4_Drop_Each_Upload()
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