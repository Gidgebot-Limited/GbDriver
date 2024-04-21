using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace GbDriver.Pages
{

    public class Google : BasePage
    {
        public IWebElement lnkGmail;
        public Google(IWebDriver driver) : base(driver)
        {
            driver.Url = "https://www.google.com";
            lnkGmail = driver.FindElement(By.XPath("//*[@id=\"gb\"]/div/div[1]/div/div[1]/a"));
        }
    }
    public class Gmail : BasePage
    {
        public IWebElement lnkCreate, lnkPersonal;
        public Gmail(IWebDriver driver) : base(driver)
        {
            driver.Url = "https://mail.google.com";
            lnkCreate = driver.FindElement(By.XPath("/html/body/header/div/div/div/details/summary/div[1]"));
            lnkPersonal = driver.FindElement(By.XPath("/html/body/header/div/div/div/details/div/a[1]"));
        }
    }
    //
    public class DynAccountName : BasePage
    {
        //SelectElement selectMonth;
        public IWebElement? monthSelectElement, txtFirstName, txtLastName, btnNext;
        public DynAccountName(IWebDriver driver) : base(driver)
        {
            txtFirstName = driver.FindElement(By.XPath("//*[@id=\"firstName\"]"));
            txtLastName = driver.FindElement(By.XPath("//*[@id=\"lastName\"]"));
            btnNext = driver.FindElement(By.XPath("//*[@id=\"collectNameNext\"]/div/button")); //
            //monthSelectElement = driver.FindElement(By.XPath("//*[@id=\"month\"]"));
            //selectMonth = new SelectElement(monthSelectElement);

        }
    }
    public class DynAccountBday : BasePage
    {
        public SelectElement? selectMonth, selectGender;
        public IWebElement? monthSelectElement, genderSelectElement, txtDay, txtYear, btnNext;
        public DynAccountBday(IWebDriver driver) : base(driver)
        {
            //btnNext = driver.FindElement(By.XPath("//*[@id=\"collectNameNext\"]/div/button")); //
            monthSelectElement = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"month\"]"))); //
            selectMonth = new SelectElement(monthSelectElement);

            ////*[@id="day"]
            txtDay = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"day\"]"))); //
            txtYear = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"year\"]"))); //

            ////*[@id="gender"]
            genderSelectElement = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/c-wiz/div[2]/div[2]/div/div[1]/div/form/span/section/div/div/div[2]/div[1]/div/div[2]/select"))); //
            selectGender = new SelectElement(genderSelectElement);

            btnNext = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"birthdaygenderNext\"]/div/button")));


        }
    }

    public class DynAccountChoose : BasePage
    {
        public IWebElement? chkFirstChoice, btnNext;
        public DynAccountChoose(IWebDriver driver) : base(driver)
        {
            chkFirstChoice = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"view_container\"]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div[1]/div/span/div[1]/div/div[1]/div")));
            btnNext = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"next\"]/div/button")));

        }
    }

    public class DynAccountPassword : BasePage
    {
        public IWebElement? txtPassword, txtConfirm, btnNext;
        public DynAccountPassword(IWebDriver driver) : base(driver)
        {
            txtPassword = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"passwd\"]/div[1]/div/div[1]/input")));

            txtConfirm = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"confirm-passwd\"]/div[1]/div/div[1]/input")));
            btnNext = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"createpasswordNext\"]/div/button")));

        }
    }
}