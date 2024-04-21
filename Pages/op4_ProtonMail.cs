using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace GbDriver.Pages
{

    public class Proton : BasePage
    {
        public IWebElement lnkGmail;
        public Proton(IWebDriver driver) : base(driver)
        {
            driver.Url = "https://proton.me/";
            //lnkGmail = driver.FindElement(By.XPath("//*[@id=\"gb\"]/div/div[1]/div/div[1]/a"));
        }
    }

    public class ProtonCreateFree : BasePage
    {
        public IWebElement? txtUsername, txtPassword;
        public ProtonCreateFree(IWebDriver driver) : base(driver)
        {
            driver.Url = "https://account.proton.me/mail/signup?plan=free&billing=12&minimumCycle=12&currency=USD&ref=prctbl";
        }
    }
}
