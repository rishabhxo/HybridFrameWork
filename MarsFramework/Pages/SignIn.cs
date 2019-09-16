using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace MarsFramework.Pages
{
    internal class SignIn
    {
        private RemoteWebDriver _driver;
        public SignIn(RemoteWebDriver driver) => _driver = driver;

        #region  Initialize Web Elements 

        //Finding the Sign Link
        private IWebElement TbSignIn => _driver.FindElementByXPath("//*[@id='home']/div/div/div[1]/div/a");

        // Finding the Email Field
        private IWebElement TxtBoxEmail => _driver.FindElementByXPath("//input[@name='email']");

        //Finding the Password Field
        private IWebElement TxtBoxPassword => _driver.FindElementByXPath("//input[@name='password']");

        //Finding the Login Button
        IWebElement BtnLogin => _driver.FindElementByXPath("//button[contains(.,'Login')]");

        #endregion

        internal void LoginSteps()
        {
            //extent Reports
            Base.test = Base.extent.StartTest("SignIn Test");
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "SignIn");
            //Navigate to the Url to docker
            _driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));
            //Validate URL page
            Assert.That(_driver.Title, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Url")));
            //Validate Signin Button
            Extension.IsClickable(TbSignIn, _driver, 10);
            //Click on Sign In tab
            TbSignIn.Click();
            //Enter the data in Username textbox
            TxtBoxEmail.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            //Validate Email Field is empty
            string inputEmailBox = TxtBoxEmail.GetAttribute("Value");
            if(inputEmailBox.Length==0)
            {
                Assert.IsEmpty("TxtBoxEmail");
            }

            //Enter the password 
            TxtBoxPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            //Validate Password Field is empty
            string inputPasswordlBox = TxtBoxPassword.GetAttribute("Value");
            if (inputPasswordlBox.Length == 0)
            {
                Assert.IsEmpty("TxtBoxPassword");
            }

            //Validate Login Button
            Extension.IsClickable(BtnLogin, _driver, 10);
            //Click on Login button
            BtnLogin.Click();  

            if (_driver.WaitForElementDisplayed(By.XPath("//a[contains(text(),'Mars Logo')]"), 1000))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "SignIn Successful");
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "SignIn Failed");
            }

        }
    }
}