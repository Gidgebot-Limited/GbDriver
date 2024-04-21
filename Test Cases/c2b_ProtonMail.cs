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
    public class c2b_ProtonMail
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
            DataSet protonRegisterData = new DataSet();
            string[] splitUserData = data.Split(',');
            protonRegisterData["Name"] = splitUserData[0];
            protonRegisterData["Gender"] = splitUserData[1];
            protonRegisterData["FirstName"] = splitUserData[2];
            protonRegisterData["LastName"] = splitUserData[3];
            protonRegisterData["State"] = splitUserData[4];
            protonRegisterData["mmBDay"] = splitUserData[5];
            protonRegisterData["ddBDay"] = splitUserData[6];
            protonRegisterData["yyyyBDay"] = splitUserData[7];
            protonRegisterData["password"] = splitUserData[8];
            protonRegisterData["phone"] = splitUserData[9];
            return protonRegisterData;
        }

        [TestMethod]
        public void t1_proton_Register_Logout()
        {
            foreach (var userData in testUserDataList)
            {
                DataSet pUserData = dataSetup(userData);
                 
                ProtonCreateFree protonFree = new ProtonCreateFree(chrome);
                protonFree.Pause(TimeSpan.FromSeconds(4));

                var inputs = chrome.FindElements(By.TagName("input"));
                foreach (var input in inputs)
                {
                    var js = (IJavaScriptExecutor)chrome;
                    js.ExecuteScript("arguments[0].style.display='block';", input);
                    js.ExecuteScript("arguments[0].removeAttribute('disabled');", input);

                    IWebElement holdChild = input;
                    while (!input.Displayed) 
                    {
                        // Print the parent information
                        IWebElement parentElement = (IWebElement)((IJavaScriptExecutor)chrome).ExecuteScript("return arguments[0].parentNode;", input);

                        if (holdChild != null)
                        {
                            js.ExecuteScript("arguments[0].style.display='block';", holdChild);

                            Console.WriteLine("Child  Id: " + holdChild.GetAttribute("id"));
                            Console.WriteLine("Child  Enabled: " + holdChild.Enabled);
                            Console.WriteLine("Child  Displayed: " + holdChild.Displayed);
                        }
                        if (input != null)
                        {
                            js.ExecuteScript("arguments[0].style.display='block';", input);

                            Console.WriteLine("input Id: " + input.GetAttribute("id"));
                            Console.WriteLine("input Enabled: " + input.Enabled);
                            Console.WriteLine("input Displayed: " + input.Displayed);
                        }
                        if (parentElement != null)
                        {
                            js.ExecuteScript("arguments[0].style.display='block';", parentElement);

                            Console.WriteLine("Parent Id: " + parentElement.GetAttribute("id"));
                            Console.WriteLine("Parent Enabled: " + parentElement.Enabled);
                            Console.WriteLine("Parent Displayed: " + parentElement.Displayed);
                        }
                        holdChild = parentElement;

                    }


                    Console.WriteLine("Id: " + input.GetAttribute("id"));
                    Console.WriteLine("Enabled: " + input.Enabled);
                    Console.WriteLine("Displayed: " + input.Displayed);

                    
                    
                    
                    
                    
                    Console.WriteLine(input.ToString());
                    Console.WriteLine("");

                }
            }
        }
    }
}