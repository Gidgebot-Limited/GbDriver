using GbDriver.Helpers;
using GbDriver.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace GbDriver
{
    //[TestClass]
    public class c2a_GoogleUserPages
    {
        private List<string>? testUserDataList;
        private IWebDriver chrome;
        private CSV_Data csvData;

        [TestInitialize]
        public void TestInitialize()
        {
            csvData = new CSV_Data("GMXUserData.csv");
            testUserDataList = csvData.Read();
            chrome = new NewChromeDriver().driver;
            chrome.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            testUserDataList = null;
            chrome.Close();
            chrome.Quit();
        }

        public DataSet dataSetup(string data) 
        {
            DataSet googleRegisterData = new DataSet();
            string[] splitUserData = data.Split(',');
            googleRegisterData["Name"] = splitUserData[0];
            googleRegisterData["Gender"] = splitUserData[1];
            googleRegisterData["FirstName"] = splitUserData[2];
            googleRegisterData["LastName"] = splitUserData[3];
            googleRegisterData["State"] = splitUserData[4];
            googleRegisterData["mmBDay"] = splitUserData[5];
            googleRegisterData["ddBDay"] = splitUserData[6];
            googleRegisterData["yyyyBDay"] = splitUserData[7];
            googleRegisterData["password"] = splitUserData[8];
            googleRegisterData["phone"] = splitUserData[9];
            return googleRegisterData;
        }

        [TestMethod]
        public void t1_Google_Register_Logout()
        {
            foreach (var userData in testUserDataList)
            {
                DataSet gUserData = dataSetup(userData);
                
                Google google = new Google(chrome);
                google.lnkGmail.Click();

                Gmail gmail = new Gmail(chrome);

                gmail.WaitForClickable(gmail.lnkCreate);
                gmail.lnkCreate.Click();

                gmail.WaitForClickable(gmail.lnkPersonal);
                gmail.lnkPersonal.Click();

                DynAccountName dynAccountName = new DynAccountName(chrome);
                dynAccountName.txtFirstName.SendKeys(gUserData["FirstName"]);
                dynAccountName.txtLastName.SendKeys(gUserData["LastName"]);
                dynAccountName.btnNext.Click();
                dynAccountName.Pause(TimeSpan.FromSeconds(4));

                DynAccountBday dynAccountBday = new DynAccountBday(chrome);

                switch (gUserData["mmBDay"])
                {
                    case "08":
                        dynAccountBday.selectMonth.SelectByText("August");
                        break;
                    case "09":
                        dynAccountBday.selectMonth.SelectByText("September");
                        break;
                    default:
                        dynAccountBday.selectMonth.SelectByText("December");
                        break;
                }
                dynAccountBday.txtDay.SendKeys(gUserData["ddBDay"]);
                dynAccountBday.txtYear.SendKeys(gUserData["yyyyBDay"]);

                switch (gUserData["Gender"])
                {
                    case "m":
                    case "male":
                    case "man":
                    case "guy":
                    case "boy":
                    case "dude":
                        dynAccountBday.selectGender.SelectByText("Male");
                        break;
                    case "f":
                    case "female":
                    case "woman":
                    case "gal":
                    case "girl":
                    case "chick":
                        dynAccountBday.selectGender.SelectByText("Female");
                        break;
                    default:
                        dynAccountBday.selectGender.SelectByText("Rather not say");
                        break;
                }
                dynAccountBday.btnNext.Click();
                dynAccountName.Pause(TimeSpan.FromSeconds(4));

                DynAccountChoose dynAccountChoose = new DynAccountChoose(chrome);
                dynAccountChoose.WaitForClickable(dynAccountChoose.chkFirstChoice);
                dynAccountChoose.chkFirstChoice.Click();

                dynAccountChoose.WaitForClickable(dynAccountChoose.btnNext);
                dynAccountChoose.btnNext.Click();

                dynAccountName.Pause(TimeSpan.FromSeconds(4));

                DynAccountPassword dynAccountPassword = new DynAccountPassword(chrome);
                dynAccountPassword.WaitForClickable(dynAccountPassword.txtPassword);
                dynAccountPassword.txtPassword.SendKeys(gUserData["password"]);
                dynAccountPassword.txtConfirm.SendKeys(gUserData["password"]);

                dynAccountPassword.WaitForClickable(dynAccountPassword.btnNext);
                dynAccountPassword.btnNext.Click();

                google.Pause(TimeSpan.FromSeconds(50));


            }
        }
    }
}
