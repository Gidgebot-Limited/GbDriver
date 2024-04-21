using OpenQA.Selenium;
using System.Linq.Expressions;

namespace GbDriver.Pages
{
    public class GbURL
    {
        public string URL { get; set; }
        public GbURL()
        {
            URL = "https://www.gidgebot.com";
        }
    }
    public class GbWelcome : BasePage
    {
        public IWebElement lnkRegister, lnkLogin, lnkDashboard;
        public GbWelcome(IWebDriver driver) : base(driver)
        {
            driver.Url = new GbURL().URL;
            try
            {
                lnkRegister = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/div/h2/a[1]")));
                lnkLogin = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/div/h2/a[2]"));
            }
            catch
            {
                lnkDashboard = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/div/h2/a"));
            }
        }
    }

    public class GbRegister : BasePage
    {
        public IWebElement txtName,
                            txtEmail,
                            txtPassword,
                            txtConfirmPassword,
                            chkTerms,
                            btnRegister;

        public GbRegister(IWebDriver driver) : base(driver)
        {
            driver.Url = new GbURL().URL + "/register";
            txtName = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"name\"]")));
            txtEmail = driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[2]/input"));
            txtPassword = driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[3]/input"));
            txtConfirmPassword = driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[4]/input"));
            chkTerms = driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[5]/label/input"));
            btnRegister = driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[6]/button"));
        }
        public void FillWith(string name, string email, string password)
        {
            txtName.SendKeys(name);
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
            txtConfirmPassword.SendKeys(password);
        }


    }
    public class GbLogin : BasePage
    {


        public IWebElement txtEmail,
                            txtPassword,
                            chkRemember,
                            lnkForgotPass,
                            btnLogin;

        public GbLogin(IWebDriver driver) : base(driver)
        {
            driver.Url = new GbURL().URL + "/login";
            txtEmail = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div[1]/input")));
            txtPassword = driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div[2]/input"));
            chkRemember = driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div[3]/label/input"));
            lnkForgotPass = driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div[4]/a"));
            btnLogin = driver.FindElement(By.XPath("/html/body/div/div[2]/div/form/div[4]/button"));
        }
        public void FillWith(string email, string password)
        {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
        }
        
        private DataSet LoginData(string data)
        {
            DataSet gbLoginData = new DataSet();

                string[] splitUserData = data.Split(',');

                gbLoginData["Name"] = splitUserData[0]; 
                gbLoginData["email"] = splitUserData[1];
                gbLoginData["password"] = splitUserData[2];
                return gbLoginData ;
        }
        public GbLogin Login(string data)
        {
                DataSet gbLoginData = LoginData(data);
                GbLogin gbLogin = new GbLogin(Driver);
  
                gbLogin.FillWith(
                    gbLoginData["email"],
                    gbLoginData["password"]
                );
                
                gbLogin.chkRemember.Click();
                return gbLogin;
        }
        

    }
    public class GbProfile : BasePage
    {
        public IWebElement? txtPassword, txtUpdateName, btnDelete, btnSaveUpdate, btnConfirmDelete;
        public GbBasePage topNav;
        public GbProfile(IWebDriver driver) : base(driver)
        {
            driver.Url = new GbURL().URL + "/profile";
            topNav = new GbBasePage(driver);
            btnDelete = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/main/div/div/div[3]/div/section/button")));
            txtPassword = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[3]/div/section/div/div[2]/form/div[1]/input"));
            txtUpdateName = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[1]/div/section/form[2]/div[1]/input"));
            btnConfirmDelete = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[3]/div/section/div/div[2]/form/div[2]/button[2]"));
            btnSaveUpdate = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[1]/div/section/form[2]/div[3]/button"));
        }
    }
    public class GbUpdateChannel : BasePage
    {
        public GbBasePage topNav;
        public IWebElement btnDelete;
        public GbUpdateChannel(IWebDriver driver) : base(driver)
        {
            topNav = new GbBasePage(driver);
            btnDelete = driver.FindElement(By.XPath("//*[@id=\"channelaccesspropInput\"]/form/button"));
    
                
         

        }
    }
    public class GbUploadEdit : BasePage
    {
        public GbBasePage topNav;
        public IWebElement btnDelete, txtPassword,btnConfirmDelete;
        public GbUploadEdit(IWebDriver driver) : base(driver)
        {
            topNav = new GbBasePage(driver);
            btnDelete = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/main/div/div/div[3]/div/section/button")));
            txtPassword = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            btnConfirmDelete = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[3]/div/section/div/div[2]/form/div[2]/button[2]"));
        }
    }
    public class GbChannelEdit : BasePage
    {
        public GbBasePage topNav;
        public IWebElement  chkImageNext, chkCategoryNext, chkAuthorNext, chkExplicitNext, chkEnclosureNext, 
                            btnCreateNext, btnDelete, btnConfirmDelete,
                            txtTitleNext, txtDescNext, txtPassword,  
                            rdoImageUpNext, rdoItemUpNext,
                            fileImageNext, fileItemNext,
                            acChannelEdit, acCreateNext, acItemProps;
        public GbChannelEdit(IWebDriver driver) : base(driver)
        {
            topNav = new GbBasePage(driver);
            acChannelEdit = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"channelAccordionPlus\"]")));
            btnDelete = driver.FindElement(By.XPath("//*[@id=\"channelDelete\"]/div/div/section/button"));
            txtPassword = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            btnConfirmDelete = driver.FindElement(By.XPath("//*[@id=\"channelDelete\"]/div/div/section/div/div[2]/form/div[2]/button[2]"));

            acCreateNext = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/main/div/div[3]/div/section")));
            txtTitleNext = driver.FindElement(By.XPath("//*[@id=\"itemtitle\"]"));
            txtDescNext = driver.FindElement(By.XPath("//*[@id=\"itemdescription\"]"));

            acItemProps = driver.FindElement(By.XPath("//*[@id=\"acItemProps\"]"));

            chkCategoryNext = driver.FindElement(By.XPath("//*[@id=\"itemcategoryprop\"]"));
            chkAuthorNext = driver.FindElement(By.XPath("//*[@id=\"itemauthorprop\"]"));
            chkExplicitNext = driver.FindElement(By.XPath("//*[@id=\"itemexplicitprop\"]"));
            

            //chkEnclosureNext = WaitScroll( driver.FindElement(By.XPath("//*[@id=\"itemurlprop\"]")));
            chkImageNext = driver.FindElement(By.XPath("//*[@id=\"itemimageprop\"]"));

            btnCreateNext = driver.FindElement(By.XPath("//*[@id=\"btnCreateItem\"]"));

            //rdoImageUpNext = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemImageLocation_upload\"]")));
            //fileImageNext = driver.FindElement(By.XPath("//*[@id=\"itemimage\"]"));


            //rdoItemUpNext = driver.FindElement(By.XPath("//*[@id=\"itemLocation_upload\"]"));
            fileItemNext = driver.FindElement(By.XPath("//*[@id=\"itemfile\"]"));
        }

        public void openItemImageRdo(IWebDriver driver)
        {
            WaitScroll(acCreateNext).Click();
            Pause(TimeSpan.FromSeconds(0.3));


            //ScrollTo(chkItemImage);
            //chkItemImage.Click();
            //Pause(TimeSpan.FromSeconds(0.3));


            //rdoIImageUp = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemImageLocation_upload\"]")));
            //rdoIImageURL = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemImageLocation_url\"]")));

            //ScrollTo(rdoIImageUp);
            //rdoIImageUp.Click();
            //Pause(TimeSpan.FromSeconds(0.3));

            //fileIImage = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemimage\"]")));
            //ScrollTo(rdoIImageURL);
            //rdoIImageURL.Click();
            //Pause(TimeSpan.FromSeconds(0.3));

            //txtIImageURL = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemImageUrl\"]")));

        }
    }
    public class GbUpdateUpload : BasePage
    {
        public GbBasePage topNav;
        public IWebElement btnDelete;
        public GbUpdateUpload(IWebDriver driver) : base(driver)
        {
            topNav = new GbBasePage(driver);
            btnDelete = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/header/div/form[1]/button")));
        }
    }
    public class GbDashboard : BasePage
    {
        public GbBasePage topNav;
        public IWebElement  acNewChannel, acChannelProps, acItemProps, 
                            txtChannelTitle, txtItemTitle, txtItemAuthor,
                            txtChannelDescr, txtItemDescr,
                            chkChannelImage, chkItemImage,
                            chkChannelCategory, chkItemCategory,
                            chkChannelAccess, chkItemAuthor,
                            chkItemExplicit, chkItemURL,
                            rdoCImageUp, rdoCImageURL,
                            rdoIImageUp, rdoIImageURL,
                            rdoEnclosureUp, rdoEnclosureURL,
                            fileCImage, fileIImage, fileEnclosure,
                            txtCImageURL, txtIImageURL, txtItemCategory, txtEnclosureURL,
                            btnCreate;
        public GbDashboard(IWebDriver driver) : base(driver)
        {
            topNav = new GbBasePage(driver);
            acNewChannel = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"acNewChannel\"]"))); //  //*[@id="acNewChannel"]
            acChannelProps = driver.FindElement(By.XPath("//*[@id='acChannelProps']"));
            acItemProps = driver.FindElement(By.XPath("//*[@id='acItemProps']"));//
            
            txtChannelTitle = driver.FindElement(By.XPath("//*[@id='channeltitle']"));
            txtChannelDescr = driver.FindElement(By.XPath("//*[@id='channeldescription']"));

            txtItemTitle = driver.FindElement(By.XPath("//*[@id='itemtitle']"));
            txtItemDescr = driver.FindElement(By.XPath("//*[@id='itemdescription']"));

            chkChannelImage = driver.FindElement(By.XPath("//*[@id=\"channelimageprop\"]"));
            chkChannelCategory= driver.FindElement(By.XPath("//*[@id=\"channelcategoryprop\"]"));
            chkChannelAccess = driver.FindElement(By.XPath("//*[@id=\"channelaccessprop\"]"));

            chkItemImage = driver.FindElement(By.XPath("//*[@id=\"itemimageprop\"]"));
            chkItemCategory = driver.FindElement(By.XPath("//*[@id=\"itemcategoryprop\"]"));
           //chkItemExplicit= driver.FindElement(By.XPath("//*[@id=\"itemexplicitprop\"]"));
            chkItemURL = driver.FindElement(By.XPath("//*[@id=\"urlprop\"]"));




            //rdoIImageUp = driver.FindElement(By.XPath("//*[@id=\"itemImageLocation_upload\"]"));
            //rdoIImageURL = driver.FindElement(By.XPath("//*[@id=\"itemImageLocation_url\"]"));


            //fileIImage = driver.FindElement(By.XPath("//*[@id=\"itemimage\"]"));
            //fileEnclosure= driver.FindElement(By.XPath("//*[@id=\"itemfile\"]"));


            //txtIImageURL = driver.FindElement(By.XPath("//*[@id=\"itemImageUrl\"]"));

            //txtEnclosureURL = driver.FindElement(By.XPath("//*[@id=\"itemurl\"]"));

            txtItemCategory = driver.FindElement(By.XPath("//*[@id=\"itemcategory\"]"));

            txtItemAuthor = driver.FindElement(By.XPath("//*[@id=\"itemauthor\"]"));

            chkItemExplicit = driver.FindElement(By.XPath("//*[@id=\"itemexplicit\"]"));


            btnCreate = driver.FindElement(By.XPath("//*[@id=\"btnCreateChannel\"]"));
        }
        public void dropEachChannel(IWebDriver driver) //
        {
            IWebElement lnkOne = null;
            GbChannelEdit gbChannelEdit;
            do 
            {


                try { lnkOne = WaitScroll(getLnkFirstEdit());
                    lnkOne.Click();
                }
                catch { lnkOne = WaitScroll(getBtnFirstEdit());
                    lnkOne.Click();
                }
              
              
                   
                gbChannelEdit = new GbChannelEdit(driver);
                gbChannelEdit.WaitScroll(gbChannelEdit.acChannelEdit).Click();
                gbChannelEdit.WaitScroll(gbChannelEdit.btnDelete).Click();
                gbChannelEdit.WaitScroll(gbChannelEdit.txtPassword).SendKeys("password");
                gbChannelEdit.WaitScroll(gbChannelEdit.btnConfirmDelete).Click();





            } while (lnkOne == null);
        }
        public IWebElement getBtnFirstEdit() // 
        {
            IWebElement btn = getDriver().FindElement(By.XPath(
             "/html/body/div/main/div/div[1]/div/div/div/a[1]"
             ));
            return btn;
        }

        public IWebElement getLnkFirstEdit() // 
        {
            IWebElement btn = getDriver().FindElement(By.XPath(
         "/html/body/div/main/div/div[1]/div/div/div/a"
             ));
            return btn;
        }
        public void openChannelImageRdo(IWebDriver driver) 
        {
            WaitScroll(acChannelProps).Click();
            WaitScroll(chkChannelImage).Click();
            rdoCImageUp = WaitScroll( driver.FindElement(By.XPath("//*[@id=\"channelImageLocation_upload\"]")));
            rdoCImageURL = WaitScroll(driver.FindElement(By.XPath("//*[@id=\"channelImageLocation_url\"]")));

            WaitScroll(rdoCImageUp).Click();

            fileCImage = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"channelimage\"]")));
            
            WaitScroll(rdoCImageURL).Click();
            
            txtCImageURL = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"channelImageUrl\"]")));
        }

        public void openItemImageRdo(IWebDriver driver)
        {
            ScrollTo(acItemProps);
            acItemProps.Click();
            Pause(TimeSpan.FromSeconds(0.3));


            ScrollTo(chkItemImage);
            chkItemImage.Click();
            Pause(TimeSpan.FromSeconds(0.3));


            rdoIImageUp = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemImageLocation_upload\"]")));
            rdoIImageURL = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemImageLocation_url\"]")));

            ScrollTo(rdoIImageUp);
            rdoIImageUp.Click();
            Pause(TimeSpan.FromSeconds(0.3));

            fileIImage = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemimage\"]")));
            ScrollTo(rdoIImageURL);
            rdoIImageURL.Click();
            Pause(TimeSpan.FromSeconds(0.3));

            txtIImageURL = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"itemImageUrl\"]")));

        }
        public void openEnclosureRdo(IWebDriver driver)
        {
            ScrollTo(chkItemURL);
            chkItemURL.Click();
            Pause(TimeSpan.FromSeconds(0.3));


            rdoEnclosureUp = driver.FindElement(By.XPath("//*[@id=\"itemLocation_upload\"]"));
            rdoEnclosureURL = driver.FindElement(By.XPath("//*[@id=\"itemLocation_url\"]"));
        
            ScrollTo(rdoEnclosureUp);
            rdoEnclosureUp.Click();
            Pause(TimeSpan.FromSeconds(0.3));


            fileEnclosure = driver.FindElement(By.XPath("//*[@id=\"itemfile\"]"));

            ScrollTo(rdoEnclosureURL);
            rdoEnclosureURL.Click();
            Pause(TimeSpan.FromSeconds(0.3));


            txtEnclosureURL = driver.FindElement(By.XPath("//*[@id=\"itemurl\"]"));



        }

        public IWebDriver Driver()
        {
            return Driver();
        }
        public void fillTD()
        {
            var title = "Selenium Testing";
            var descr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nec aliquet quam. Duis consectetur ante vitae justo lacinia vehicula. Sed ac velit " +
                        "vitae ex tincidunt ultricies. Integer sollicitudin, justo sit amet dapibus hendrerit, dolor velit venenatis sapien, at viverra est libero vel lorem. Sed.";

            ScrollTo(acNewChannel);
            WaitForClickable(acNewChannel);
            acNewChannel.Click();
            Pause(TimeSpan.FromSeconds(0.3));

            ScrollTo(txtChannelTitle);
            WaitForClickable(txtChannelTitle);
            txtChannelTitle.SendKeys(title);
            Pause(TimeSpan.FromSeconds(0.3));


            ScrollTo(txtChannelTitle);
            WaitForClickable(txtChannelTitle);
            txtChannelDescr.SendKeys(descr);
            Pause(TimeSpan.FromSeconds(0.3));

            ScrollTo(txtItemTitle);
            WaitForClickable(txtItemTitle);
            txtItemTitle.SendKeys(title);
            Pause(TimeSpan.FromSeconds(0.3));

            ScrollTo(txtItemDescr);
            WaitForClickable(txtItemDescr);
            txtItemDescr.SendKeys(descr);

        }
    }

    public class GbSubscribe : BasePage
    {
        public GbBasePage   topNav;
        public IWebElement  txtNameOnCard,
                            fmeStripeCard,
                            txtCardNumber,
                            txtExp,txtCVC, 
                            txtAddress,
                            txtCity,
                            txtState,
                            txtPostal,
                            btnSubscribe;
        public GbSubscribe(IWebDriver driver) : base(driver)
        {//     
            driver.Url = new GbURL().URL + "/subscribe";
            topNav = new GbBasePage(driver);
            try
            {
                txtNameOnCard = WaitForElementToBeVisible(driver.FindElement(By.XPath("//*[@id=\"card-holder-name\"]")));
                fmeStripeCard = driver.FindElement(By.XPath("//*[@id=\"card-element\"]/div/iframe"));

                driver.SwitchTo().Frame(fmeStripeCard);
                txtCardNumber = driver.FindElement(By.XPath("//*[@id=\"root\"]/form/div/div[2]/span[1]/span[2]/div/div[2]/span/input"));
                txtExp = driver.FindElement(By.XPath("//*[@id=\"root\"]/form/div/div[2]/span[2]/span[1]/span/span/input"));
                txtCVC = driver.FindElement(By.XPath("//*[@id=\"root\"]/form/div/div[2]/span[2]/span[2]/span/span/input"));
                driver.SwitchTo().DefaultContent();

                txtAddress = driver.FindElement(By.XPath("//*[@id=\"address_line1\"]"));
                txtCity = driver.FindElement(By.XPath("//*[@id=\"city\"]"));

                txtState = driver.FindElement(By.XPath("//*[@id=\"state\"]"));
                txtPostal = driver.FindElement(By.XPath("//*[@id=\"postal_code\"]"));
            }
            catch 
            {
                
            }
            btnSubscribe    = driver.FindElement(By.XPath("//*[@id=\"card-button\"]"));           
        }

        public void frmFillCC(string acString)
        {
            var splits = acString.Split(',');

            txtNameOnCard.SendKeys(acString);
            //Driver.SwitchTo().Frame(fmeStripeCard);

            //txtCardNumber.SendKeys(splits[0] ?? "1234432112344321");

            //txtExp.SendKeys(splits[1] ?? "12/25");

            //txtCVC.SendKeys(splits[2] ?? "475");

            //Driver.SwitchTo().DefaultContent();


           //txtAddress.SendKeys(splits[4] ?? "465 CardName Dr.");

            //txtCity.SendKeys(splits[5] ?? "Credin");

           // txtState.SendKeys(splits[6] ?? "IL");

            //txtPostal.SendKeys(splits[7] ?? "60576");

        }
        public void frmFillCC()
        {
            Driver.SwitchTo().Frame(fmeStripeCard); 

            txtCardNumber.SendKeys("1234432112344321");
                                
            txtExp.SendKeys("12/25");                    

            txtCVC .SendKeys("475");
            
            Driver.SwitchTo().DefaultContent();

            txtNameOnCard.SendKeys("Card H. Name");

            txtAddress.SendKeys("465 CardName Dr.");

            txtCity.SendKeys("Credin");

            txtState.SendKeys("IL");

            txtPostal.SendKeys("60576");
                    
        }
    }
    public class GbUploads : BasePage
    {
        public GbBasePage topNav;
        public IWebElement acUploadMedia, btnSubscribe, btnUpload, filesSelect;
        public GbUploads(IWebDriver driver) : base(driver)
        {
            driver.Url = new GbURL().URL + "/uploads";
            topNav = new GbBasePage(driver);   
            acUploadMedia = WaitForElementToBeVisible(driver.FindElement(By.XPath("/html/body/div/main/div/div/div/section")));
            try{ 
                btnSubscribe = driver.FindElement(By.XPath("//*[@id=\"subscription-form\"]/button[2]"));
            }
            catch{ 
                filesSelect = driver.FindElement(By.XPath("//*[@id=\"files\"]")); //
                btnUpload = driver.FindElement(By.XPath("//*[@id=\"fileUploadForm\"]/div[2]/button"));
            }

        }
        public void dropEachUpload(IWebDriver driver) //
        {
            IWebElement lnkOne;
            do
            {
                try
                {
                    lnkOne = getLnkFirstEdit();
                    Pause(TimeSpan.FromSeconds(0.03));
                    lnkOne.Click();
                    Pause(TimeSpan.FromSeconds(0.03));
                    GbUploadEdit gbUploadEdit = new GbUploadEdit(driver);
                    Pause(TimeSpan.FromSeconds(0.03));
                    WaitScroll(gbUploadEdit.btnDelete).Click();
                    Pause(TimeSpan.FromSeconds(0.03));
                    gbUploadEdit.txtPassword.SendKeys("password");
                    Pause(TimeSpan.FromSeconds(0.03));
                    gbUploadEdit.btnConfirmDelete.Click();
                    Pause(TimeSpan.FromSeconds(0.03));
                }
                catch 
                {
                    lnkOne = null;
                }

            } while (lnkOne  != null);
        }
        public IWebElement getBtnFirstEdit() //
        {
            IWebElement btn = getDriver().FindElement(By.XPath(
            "/html/body/div/main/div/div[2]/div/div[1]/a/div/form/button"
             ));
            return btn;
        }

        public IWebElement getLnkFirstEdit() //
        {
            IWebElement btn = getDriver().FindElement(By.XPath(
            "/html/body/div/main/div/div[2]/div/div[1]/a/h1"
             ));
            return btn;
        }

    }
}