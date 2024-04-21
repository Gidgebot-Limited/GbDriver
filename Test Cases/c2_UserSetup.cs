using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;
using System;
using GbDriver.Helpers;
using GbDriver.Pages;

namespace GbDriver
{
    // [TestClass]
    public class c2_UserSetup
    {
        private List<string>? testGMXDataList, testGbDataList;
        private CSV_Data? csvGMXData, csvUserData, csvGbData;
        private IWebDriver? chrome;
        
        private static readonly string MailslurpApiKey = "dc460b1ef62b51dedc1308577981a876b7a06f20522bc4c89c027b8deda87736";
        private static Configuration? _mailslurpConfig;
        private InboxDto? _inbox;


        [TestInitialize]
        public void TestInitialize()
        {
            chrome = new NewChromeDriver().driver;
            chrome.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            if(chrome != null){
                chrome.Close();
                chrome.Quit();
            }
        }

        private string ExtractVerificationLink(string emailBody)
        {
            // Use regex to extract the verification link
            // Example regex (adjust as needed):
            var match = Regex.Match(emailBody, @"<a\s+(?:[^>]*?\s+)?href=([""'])(.*?)\1", RegexOptions.IgnoreCase);

            if (match.Success && match.Groups.Count > 2)
            {
                return match.Groups[1].Value;
            }

            // Return null if no match found
            return "";
        }
        //[TestMethod]
        public void t1a_Mailslurp_Gb_Create_Link_Delete()
        {
            Assert.IsNotNull(MailslurpApiKey);
            _mailslurpConfig = new Configuration();
            _mailslurpConfig.ApiKey.Add("x-api-key", MailslurpApiKey);

            var inboxControllerApi = new InboxControllerApi(_mailslurpConfig);
            _inbox = inboxControllerApi.CreateInbox();


            Assert.IsNotNull(_inbox);
            Assert.IsTrue(_inbox.EmailAddress.Contains("@mailslurp.com"));

            Console.WriteLine(_inbox.GetType());
            Console.WriteLine(_inbox.EmailAddress);

            
            if(chrome != null) 
            {
                GbRegister gbRegister = new GbRegister(chrome);

                gbRegister.FillWith(
                    _inbox.Id.ToString(),
                    _inbox.EmailAddress,
                    "password"
                );

                gbRegister.chkTerms.Click();
                gbRegister.btnRegister.Click();

                GbDashboard gbDashboard = new GbDashboard(chrome);

                //verify
                var email = new WaitForControllerApi(_mailslurpConfig).WaitForLatestEmail(_inbox.Id, 600000, true);
                var emails = inboxControllerApi.GetInboxEmailsPaginated(_inbox.Id);
                Console.WriteLine("From " + emails.Size + " emails");
                Console.WriteLine(email);

                //Console.WriteLine(email.Body);
                string verificationLink = ExtractVerificationLink(email.Body);
                Console.WriteLine(verificationLink);

                gbDashboard.topNav.drpUsername.Click();
                
                gbDashboard.topNav.lnkProfile.Click();

                GbProfile gbProfile = new GbProfile(chrome);
                gbProfile.ScrollTo(gbProfile.btnDelete);
                gbProfile.WaitForClickable(gbProfile.btnDelete);
                gbProfile.btnDelete.Click();
                gbProfile.WaitForClickable(gbProfile.txtPassword);
                gbProfile.txtPassword.SendKeys("password");
                gbProfile.WaitForClickable(gbProfile.btnConfirmDelete);
                gbProfile.btnConfirmDelete.Click();

                GbWelcome gbWelcome = new GbWelcome(chrome);

            }
            inboxControllerApi.DeleteInbox(_inbox.Id);
            _inbox = null;



        }
        [TestMethod]
        public void t1_Mailslurp_Gb_Create_Delete()
        {
            Assert.IsNotNull(MailslurpApiKey);
            _mailslurpConfig = new Configuration();
            _mailslurpConfig.ApiKey.Add("x-api-key", MailslurpApiKey);

            var inboxControllerApi = new InboxControllerApi(_mailslurpConfig);
            _inbox = inboxControllerApi.CreateInbox();


            Assert.IsNotNull(_inbox);
            Assert.IsTrue(_inbox.EmailAddress.Contains("@mailslurp.com"));

            Console.WriteLine(_inbox.GetType());
            Console.WriteLine(_inbox.EmailAddress);

            GbRegister gbRegister = new GbRegister(chrome);
            
            gbRegister.FillWith(
                _inbox.Id.ToString(),
                _inbox.EmailAddress,
                "password"
            );

            gbRegister.chkTerms.Click();
            gbRegister.btnRegister.Click();

            GbDashboard gbDashboard = new GbDashboard(chrome);
            gbDashboard.topNav.drpUsername.Click();
            gbDashboard.topNav.lnkProfile.Click();

            GbProfile gbProfile = new GbProfile(chrome);
            gbProfile.ScrollTo(gbProfile.btnDelete);
            gbProfile.WaitForClickable(gbProfile.btnDelete);
            gbProfile.btnDelete.Click();
            gbProfile.WaitForClickable(gbProfile.txtPassword);
            gbProfile.txtPassword.SendKeys("password");
            gbProfile.WaitForClickable(gbProfile.btnConfirmDelete);
            gbProfile.btnConfirmDelete.Click();

            GbWelcome gbWelcome = new GbWelcome(chrome);
            inboxControllerApi.DeleteInbox(_inbox.Id);
            _inbox = null;
        }
    }
}