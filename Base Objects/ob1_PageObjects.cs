using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using GbDriver.Pages;

namespace GbDriver
{
    public class DataSet
    {
        private Dictionary<string, string> properties = new Dictionary<string, string>();

        public string this[string propertyName]
        {
            get
            {
                return properties.TryGetValue(propertyName, out var value) ? value : null;
            }
            set
            {
                properties[propertyName] = value;
            }
        }
    }
    public class BasePage
    {
        protected IWebDriver Driver;
        public WebDriverWait Wait;
        public ITakesScreenshot Take;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Take = (ITakesScreenshot)driver; 
        }

        public void Screenshot(string filepath)
        {
            Screenshot screenshot = Take.GetScreenshot();
            screenshot.SaveAsFile(filepath);    
        }
        public void TcScreenshot(string filepath)
        {
            var fpSplits = filepath.Split("/");
            var filename = fpSplits[fpSplits.Length - 1];
            var dirPath = "";
            for(int i = 0;i<fpSplits.Length - 1;i++){
                dirPath += fpSplits[i] + "/";
            } 
            if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

            Screenshot screenshot = Take.GetScreenshot();
            screenshot.SaveAsFile(filepath);    
        }

        protected IWebElement WaitForElementToBeVisible(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementToBeVisible(IWebElement element)
        {
            return Wait.Until(driver =>
            {
                try
                {
                    return element.Displayed ? element : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }
        protected IWebElement WaitForElementToBeClickable(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        protected IWebElement WaitForElementToBeClickable(IWebElement element)
        {
            return Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        protected IWebElement ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }
        public IWebElement ScrollTo(IWebElement element)
        {
            return ScrollIntoView(element);
        }
        public IWebElement WaitScroll(IWebElement element) 
        {
            return WaitForClickable(ScrollTo(element));
        }
        public IWebDriver getDriver()
        {
            return Driver;
        }

        public void Pause(TimeSpan duration)
        {
            Thread.Sleep(duration);
        }
        public IWebElement WaitForClickable(By locator)
        {
            IWebElement green = null;
            while (green == null)
            {
                try
                {
                    green = WaitForElementToBeClickable(locator);
                }
                catch
                {
                    green = null;
                }
            }
            return green;
        }
        public IWebElement WaitForClickable(IWebElement element)
        {
            IWebElement green = null;
            while (green == null)
            {
                try
                {
                    green = WaitForElementToBeClickable(element);
                }
                catch
                {
                    green = null;
                }
            }
            return green;
        }
        public IWebElement WaitFor(By locator)
        {
            IWebElement green = null;
            while (green == null)
            {
                try
                {
                    green = WaitForElementToBeVisible(locator);
                }
                catch
                {
                    green = null;
                }
            }
            return green;

        }
        public IWebElement WaitFor(IWebElement element)
        {
            IWebElement green = null;
            while (green == null)
            {
                try
                {
                    green = WaitForElementToBeVisible(element);
                }
                catch
                {
                    green = null;
                }
            }
            return green;
        }
    }
    
    public class GbBasePage : BasePage
    {
        public IWebElement? e, drpUsername, lnkLogout, lnkProfile, lnkMedia, lnkRSS;
        public GbBasePage(IWebDriver driver) : base(driver)
        {
            lnkRSS = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div[1]/nav/div[1]/div/div[1]/div/a[1]")));
            lnkMedia = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/nav/div[1]/div/div[1]/div/a[2]")));
            drpUsername =  WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/nav/div[1]/div/div[2]/div/div[1]")));
            lnkLogout = driver.FindElement(By.XPath("/html/body/div/nav/div[1]/div/div[2]/div/div[2]/div/form/a"));
            lnkProfile = driver.FindElement(By.XPath("/html/body/div/nav/div[1]/div/div[2]/div/div[2]/div/a[1]"));
            // 
            
        }
        public void WriteAlertAccepted() 
        {
            IAlert alert = Wait.Until(
                ExpectedConditions.AlertIsPresent()
                );
            Console.WriteLine(alert.Text + " Yes.");
            alert.Accept();

        }
        public void logout()
        {
            ScrollIntoView(drpUsername);
            drpUsername.Click();
            WaitForClickable(lnkLogout);
            lnkLogout.Click();
        }
    }
}