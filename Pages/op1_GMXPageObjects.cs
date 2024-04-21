using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace GbDriver.Pages
{

    public class MailLogin : BasePage
    {

        public string url = "https://www.gmx.com/";
        public IWebElement? drpLogin,
                            txtEmail,
                            txtPassword,
                            btnLogin;


        public MailLogin(IWebDriver driver) : base(driver)
        {
            driver.Url = url;
            drpLogin = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
            txtEmail = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div/div[2]/form/div[1]/input"));
            txtPassword = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div/div[2]/form/div[2]/input"));
            btnLogin = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div/div[2]/form/button"));
        }

    }
    public class GMXModal : BasePage
    {

        public string url = "https://www.gmx.com/consentpage";
        public IWebElement? modalFrame;
        public GMXModal(IWebDriver driver) : base(driver)
        {
            driver.Url = url;

        }

    }
    public class GMXWelcome : BasePage
    {
        public string url = "https://www.gmx.com/";
        public IWebElement? btnLogin,
                            btnSubmit,

                            txtEmail,
                            txtPassword;
        public GMXWelcome(IWebDriver driver) : base(driver)
        {
            driver.Url = url;
        }
    }

    public class MailSignUp : BasePage
    {
        public string url = "https://signup.mail.com/";
        public SelectElement selectState;
        public IWebElement btnAccept,
                           txtEmail,
                           txtFirstName,
                           txtLastName,
                           txtMM,
                           txtDD,
                           txtYYYY,
                           txtPassword,
                           txtConfirmPassword,
                           txtPhone,
                           chkMale,
                           chkFemale,
                           chkOther,
                           chkCaptcha,
                           stateSelectElement,
                           hidelink;

        public MailSignUp(IWebDriver driver) : base(driver)
        {
            driver.Url = url;
            txtEmail = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[1]/onereg-alias/fieldset/onereg-progress-meter/div[2]/div[2]/div/pos-input[1]/input"));
            chkMale = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/div/div/onereg-radio-wrapper[2]/pos-input-radio/label/i/span"));
            chkFemale = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/div/div/onereg-radio-wrapper[1]/pos-input-radio/label/i/span"));
            chkOther = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/div/div/onereg-radio-wrapper[3]/pos-input-radio/label/i/span"));
            txtFirstName = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[1]/div/div[2]/pos-input/input"));
            txtLastName = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[2]/div/div[2]/pos-input/input"));
            //
            stateSelectElement = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/fieldset/onereg-form-row[2]/div/div/pos-input/select"));
            selectState = new SelectElement(stateSelectElement);
            txtMM = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[3]/div/div/div/onereg-dob-wrapper/pos-input-dob/pos-input[1]/input"));
            txtDD = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[3]/div/div/div/onereg-dob-wrapper/pos-input-dob/pos-input[2]/input"));
            txtYYYY = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[3]/div/div/div/onereg-dob-wrapper/pos-input-dob/pos-input[3]/input"));
            txtPassword = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[4]/onereg-password/fieldset/onereg-progress-meter/onereg-form-row[1]/div/div/pos-input/input"));
            txtConfirmPassword = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[4]/onereg-password/fieldset/onereg-progress-meter/onereg-form-row[2]/div/div/pos-input/input"));
            txtPhone = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[5]/onereg-password-recovery/fieldset/onereg-progress-meter/onereg-form-row[1]/div/div/div/pos-input[2]/input"));
            chkCaptcha = driver.FindElement(By.XPath("//iframe[@title='reCAPTCHA']"));
            btnAccept = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[6]/onereg-terms-and-conditions/onereg-progress-meter/fieldset/div[3]/div/button"));
            //hidelink = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[6]/onereg-terms-and-conditions/onereg-progress-meter/fieldset/div[2]/span[1]/a[2]"));
        }


        // Example usage
        public void FillToCaptcha(string email, string gender, string firstName, string lastName, string state, string mm, string dd, string yyyy, string password, string phone)
        {
            ScrollTo(txtEmail);
            txtEmail.SendKeys(email);

            ScrollTo(chkOther);
            switch (gender.ToLower())
            {
                case "m":
                case "male":
                case "man":
                case "guy":
                case "boy":
                case "dude":
                    chkMale.Click();
                    break;
                case "f":
                case "female":
                case "woman":
                case "gal":
                case "girl":
                case "chick":
                    chkFemale.Click();
                    break;
                default:
                    chkOther.Click();
                    break;
            }

            ScrollTo(txtFirstName);
            txtFirstName.SendKeys(firstName);

            ScrollTo(txtLastName);
            txtLastName.SendKeys(lastName);

            ScrollTo(stateSelectElement);
            selectState.SelectByText(state);

            ScrollTo(txtMM);
            txtMM.SendKeys(mm);
            txtDD.SendKeys(dd);
            txtYYYY.SendKeys(yyyy);

            ScrollTo(txtPassword);
            txtPassword.SendKeys(password);

            ScrollTo(txtConfirmPassword);
            txtConfirmPassword.SendKeys(password);

            ScrollTo(txtPhone);
            txtPhone.SendKeys(phone);

            ScrollTo(chkCaptcha);
            chkCaptcha.Click();
        }
    }
    public class GMXSignUp : BasePage
    {
        public string url = "https://signup.gmx.com/";
        public SelectElement selectState;
        public IWebElement btnAccept,
                           txtEmail,
                           txtFirstName,
                           txtLastName,
                           txtMM,
                           txtDD,
                           txtYYYY,
                           txtPassword,
                           txtConfirmPassword,
                           txtPhone,
                           chkMale,
                           chkFemale,
                           chkOther,
                           chkCaptcha,
                           stateSelectElement,
                           hidelink;

        public GMXSignUp(IWebDriver driver) : base(driver)
        {
            driver.Url = url;
            txtEmail = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[1]/onereg-alias/fieldset/onereg-progress-meter/div[2]/div[2]/div/pos-input[1]/input"));
            chkMale = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/div/div/onereg-radio-wrapper[2]/pos-input-radio/label/i/span"));
            chkFemale = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/div/div/onereg-radio-wrapper[1]/pos-input-radio/label/i/span"));
            chkOther = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/div/div/onereg-radio-wrapper[3]/pos-input-radio/label/i/span"));
            txtFirstName = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[1]/div/div[2]/pos-input/input"));
            txtLastName = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[2]/div/div[2]/pos-input/input"));
            //
            stateSelectElement = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/fieldset/onereg-form-row[2]/div/div/pos-input/select"));
            selectState = new SelectElement(stateSelectElement);
            txtMM = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[3]/div/div/div/onereg-dob-wrapper/pos-input-dob/pos-input[1]/input"));
            txtDD = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[3]/div/div/div/onereg-dob-wrapper/pos-input-dob/pos-input[2]/input"));
            txtYYYY = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[3]/onereg-progress-meter/onereg-personal-info/fieldset/onereg-form-row[3]/div/div/div/onereg-dob-wrapper/pos-input-dob/pos-input[3]/input"));
            txtPassword = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[4]/onereg-password/fieldset/onereg-progress-meter/onereg-form-row[1]/div/div/pos-input/input"));
            txtConfirmPassword = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[4]/onereg-password/fieldset/onereg-progress-meter/onereg-form-row[2]/div/div/pos-input/input"));
            txtPhone = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[5]/onereg-password-recovery/fieldset/onereg-progress-meter/onereg-form-row[1]/div/div/div/pos-input[2]/input"));
            chkCaptcha = driver.FindElement(By.XPath("//iframe[@title='reCAPTCHA']"));
            btnAccept = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[6]/onereg-terms-and-conditions/onereg-progress-meter/fieldset/div[3]/div/button"));
            hidelink = driver.FindElement(By.XPath("/html/body/onereg-app/div/onereg-form/div/div/form/section/section[6]/onereg-terms-and-conditions/onereg-progress-meter/fieldset/div[2]/span[1]/a[2]"));
        }


        // Example usage
        public void FillToCaptcha(string email, string gender, string firstName, string lastName, string state, string mm, string dd, string yyyy, string password, string phone)
        {
            ScrollTo(txtEmail);
            txtEmail.SendKeys(email);

            ScrollTo(chkOther);
            switch (gender.ToLower())
            {
                case "m":
                case "male":
                case "man":
                case "guy":
                case "boy":
                case "dude":
                    chkMale.Click();
                    break;
                case "f":
                case "female":
                case "woman":
                case "gal":
                case "girl":
                case "chick":
                    chkFemale.Click();
                    break;
                default:
                    chkOther.Click();
                    break;
            }

            ScrollTo(txtFirstName);
            txtFirstName.SendKeys(firstName);

            ScrollTo(txtLastName);
            txtLastName.SendKeys(lastName);

            ScrollTo(stateSelectElement);
            selectState.SelectByText(state);

            ScrollTo(txtMM);
            txtMM.SendKeys(mm);
            txtDD.SendKeys(dd);
            txtYYYY.SendKeys(yyyy);

            ScrollTo(txtPassword);
            txtPassword.SendKeys(password);

            ScrollTo(txtConfirmPassword);
            txtConfirmPassword.SendKeys(password);

            ScrollTo(txtPhone);
            txtPhone.SendKeys(phone);

            ScrollTo(chkCaptcha);
            chkCaptcha.Click();
        }
    }




}
