using GbDriver.Helpers;
using GbDriver.Pages;
using OpenQA.Selenium;

namespace GbDriver
{
    [TestClass]
    public class c3_UserFeatures
    {
        private IWebDriver chrome;
        private CSV_Data? csv, csvDUMMYData, csvGbData;

        private Gb_Data? gbData;

        [TestInitialize]
        public void TestInitialize()
        {
            csv = new CSV_Data();            
            csvDUMMYData = csv.ReadDummyData();
            csvGbData    = csv.ReadGbData();

            chrome = new NewChromeDriver().driver;
            chrome.Manage().Window.Maximize();

            gbData = new Gb_Data();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            csvDUMMYData = csvGbData =  csv =  null;
            gbData = null;
            if (!(chrome == null)) {
                chrome.Close();
                chrome.Quit();
            }
            chrome = null;

        }

        [TestMethod]
        public void t1_Register_Logout()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            foreach (var userData in csvDUMMYData.Read())
            {
                DataSet gbRegisterData = new DataSet();

                string[] splitUserData = userData.Split(',');

                gbRegisterData["Name"] = splitUserData[0];
                gbRegisterData["Email"] = splitUserData[1];
                gbRegisterData["password"] = splitUserData[2];

                GbWelcome gbWelcome= new GbWelcome(chrome);
                gbWelcome.lnkRegister.Click();

                GbRegister gbRegister = new GbRegister(chrome);
                gbRegister.TcScreenshot(ssDirPath + "Register.png");
                gbRegister.FillWith(
                    gbRegisterData["Name"],
                    gbRegisterData["Email"] ,
                    gbRegisterData["password"]
                );

                gbRegister.chkTerms.Click();
                gbRegister.btnRegister.Click();
                gbRegister.Pause(TimeSpan.FromSeconds(0.3));
                GbDashboard exitDashboard = new GbDashboard(chrome);
                exitDashboard.topNav.logout();
            }
        }

        //[TestMethod]
        public void t3a_Login_logout()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            foreach (var userData in csvDUMMYData.Read())
            {
                GbLogin gbLogin = new GbLogin(chrome).Login(userData);     
                gbLogin.TcScreenshot(ssDirPath + "Login.png");         
                gbLogin.btnLogin.Click();

                gbLogin.Pause(TimeSpan.FromSeconds(20));
                
                GbDashboard exitDashboard = new GbDashboard(chrome);
                exitDashboard.topNav.logout();
            }
        }
        
        [TestMethod]
        public void t2_Login_Update_logout()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            foreach (var userData in csvDUMMYData.Read())
            {
                GbLogin gbLogin = new GbLogin(chrome).Login(userData);                
                gbLogin.btnLogin.Click();

                GbDashboard gbDashboard = new GbDashboard(chrome);
                gbDashboard.topNav.drpUsername.Click();
                gbDashboard.topNav.lnkProfile.Click();
                
                GbProfile gbProfile = new GbProfile(chrome);
                gbProfile.TcScreenshot(ssDirPath + "Profile.png");
                gbProfile.txtUpdateName.SendKeys("`");
                gbProfile.btnSaveUpdate.Click();

                gbProfile = new GbProfile(chrome);
                Assert.IsTrue(gbProfile.topNav.drpUsername.Text.Contains("`"));
                gbProfile.TcScreenshot(ssDirPath + "Profile_backtick.png");
                gbProfile.topNav.logout();
            }
        }

        [TestMethod]
        public void t3_Login_Delete()
        {
            var ssDirPath =  gbData.getScreenshotDirectory() + "/" + gbData.GetCallingClass() + "/" + gbData.getCallingMethod() + "/" ;
            foreach (var userData in csvDUMMYData.Read())
            {
                GbLogin gbLogin = new GbLogin(chrome).Login(userData);                
                gbLogin.btnLogin.Click();

                GbDashboard gbDashboard = new GbDashboard(chrome);
                Assert.IsTrue(gbDashboard.topNav.drpUsername.Text.Contains( userData.Split(",")[0] ));
                
                gbDashboard.topNav.drpUsername.Click();
                gbDashboard.WaitForClickable(gbDashboard.topNav.lnkProfile).Click();

                GbProfile gbProfile = new GbProfile(chrome);
                gbProfile.ScrollTo(gbProfile.btnDelete);
                gbProfile.WaitForClickable(gbProfile.btnDelete);
                gbProfile.TcScreenshot(ssDirPath + "ProfileBtnDelete.png");

                gbProfile.btnDelete.Click();
                gbProfile.WaitForClickable(gbProfile.txtPassword);
                gbProfile.txtPassword.SendKeys(userData.Split(",")[2]);
                gbProfile.WaitForClickable(gbProfile.btnConfirmDelete);
                
                gbProfile.TcScreenshot(ssDirPath + "ProfilePWDelete.png");
                gbProfile.btnConfirmDelete.Click();
                gbProfile.TcScreenshot(ssDirPath + "ProfilePWDeleteResult.png");
            }
        }
    }
}