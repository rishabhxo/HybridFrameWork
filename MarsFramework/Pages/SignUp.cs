using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class SignUp
    {
       
        private RemoteWebDriver _driver;
        public SignUp(RemoteWebDriver driver) => _driver = driver;

        #region  Initialize Web Elements
        //Finding the Join 
        private IWebElement BtnJoin => _driver.FindElementByXPath("//*[@id='home']/div/div/div[1]/div/button");

        //Identify FirstName Textbox
        private IWebElement TxtBoxFirstName => _driver.FindElementByName("firstName");

        //Identify LastName Textbox
        private IWebElement TxtBoxLastName => _driver.FindElementByName("lastName");

        //Identify Email Textbox
        private IWebElement TxtBoxEmail => _driver.FindElementByName("email");

        //Identify Password Textbox
        private IWebElement TxtBoxPassword => _driver.FindElementByName("password");

        //Identify Confirm Password Textbox
        private IWebElement TxtBoxConfirmPassword => _driver.FindElementByName("confirmPassword");

        //Identify Term and Conditions Checkbox
        private IWebElement ChkBoxTick => _driver.FindElementByName("terms");

        //Identify join button
        private IWebElement BtnJoinSumbit => _driver.FindElementByXPath("//div[@id='submit-btn'][contains(text(),'Join')]");
        #endregion
        #region SignUp 

        internal void Register()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
            //extent Reports
            Base.test = Base.extent.StartTest("SignUp Test");

            //Navigate to the Url
            _driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));
            //Validate URL page
            Assert.That(_driver.Title, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Url")));
            //Validate Joinin Button
            Extension.IsClickable(BtnJoin, _driver, 10);
            //Click on Join button
            BtnJoin.Click();
            //Enter FirstName
            TxtBoxFirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));
            //Validate FirstName Field is empty
            string inputFirstNameBox = TxtBoxFirstName.GetAttribute("Value");
            if (inputFirstNameBox.Length == 0)
            {
                Assert.IsEmpty("TxtBoxFirstName");
            }
            //Enter LastName
            TxtBoxLastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));
            //Validate LastName Field is empty
            string inputLastNameBox = TxtBoxLastName.GetAttribute("Value");
            if (inputLastNameBox.Length == 0)
            {
                Assert.IsEmpty("TxtBoxLastName");
            }

            //Enter Email
            TxtBoxEmail.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));
            //Validate Email Field is empty
            string inputEmailBox = TxtBoxEmail.GetAttribute("Value");
            if (inputEmailBox.Length == 0)
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


            //Enter Password again to confirm
            TxtBoxConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword"));
            //Validate Confirm Password Field is empty
            string inputConfirmPasswordlBox = TxtBoxConfirmPassword.GetAttribute("Value");
            if (inputConfirmPasswordlBox.Length == 0)
            {
                Assert.IsEmpty("TxtBoxConfirmPassword");
            }

            //Validate Checkbox
            if(ChkBoxTick.Selected==false)
            {
                //Click on Checkbox
                ChkBoxTick.Click();

            }

            //Validate Login Button
            Extension.IsClickable(BtnJoinSumbit, _driver, 10);
            //Click on join button to Sign Up
            BtnJoinSumbit.Click();
            // verify if register a new account successfully
            IWebElement actualtext = _driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
            Assert.That(actualtext.Text, Is.EqualTo("Registration successful, Please verify your email!"));

        }
        #endregion
    }
}
