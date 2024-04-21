using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace GbDriver.Pages
{
    public class MailSlurpPg : BasePage
    {
        public IWebElement txtUsername, txtPassword;
        public MailSlurpPg(IWebDriver driver) : base(driver)
        {
            driver.Url = "https://playground.mailslurp.com";
            txtUsername = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/form/div[1]/div[1]/input"));
            txtPassword = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/form/div[1]/div[2]/input"));
        }
    }
}
