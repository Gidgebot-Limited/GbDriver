using GbDriver.Helpers;
using GbDriver.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace GbDriver.Steps
{
    [Binding]
    public sealed class gHerkin
    {
        private readonly ScenarioContext _scenarioContext;

        public gHerkin(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            IWebDriver? chrome;
            chrome = new NewChromeDriver().driver;
            chrome.Manage().Window.Maximize();
            _scenarioContext["ChromeDriver"] = chrome;
        }

        [Given("Driver is instantiated")]
        public void GivenDriverIsInstantiated()
        {
            Assert.IsTrue(_scenarioContext["ChromeDriver"] is IWebDriver, "'chrome' is not an instance of IWebDriver");
        }

        [When(@"(.*) page object model is instantiated")]
        public void WhenBasePageIsInstantiatedWithPageObject(string pageObjectName)
        {
            var chrome = _scenarioContext["ChromeDriver"] as IWebDriver;
            BasePage basePage;

            // Instantiate the page object based on the provided pageObjectName
            switch (pageObjectName.ToLower())
            {
                case "google":
                    basePage = new Google(chrome);
                    break;
                // Add cases for other page objects as needed
                default:
                    throw new ArgumentException($"Unknown page object name: {pageObjectName}");
            }

            _scenarioContext["POM"] = basePage;
        }

        [Then(@"Driver URL will be set to (.*)")]
        public void ThenDriverURLWillBeSetToGooglePOMAddress(string expectedUrl)
        {
            var basePage = _scenarioContext["POM"] as BasePage;
            var chromeDriver = _scenarioContext["ChromeDriver"] as IWebDriver;

            Assert.IsNotNull(basePage, "BasePage instance is null");
            Assert.IsNotNull(chromeDriver, "ChromeDriver instance is null");

            var actualUrl = chromeDriver.Url;
            var expectedBasePageUrl = basePage.getDriver().Url;

            Assert.AreEqual(expectedUrl, expectedBasePageUrl, $"The expected URL '{expectedUrl}' does not match the BasePage's URL '{expectedBasePageUrl}'.");
            Assert.AreEqual(expectedUrl, actualUrl, $"The ChromeDriver's URL '{actualUrl}' does not match the expected URL '{expectedUrl}'.");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext["ChromeDriver"] is IWebDriver chrome)
            {
                if (!(chrome == null))
                {
                    chrome.Close();
                    chrome.Quit();
                }
                chrome = null;
                _scenarioContext.Remove("ChromeDriver");
                _scenarioContext.Remove("POM");
            }
        }
    }
}
