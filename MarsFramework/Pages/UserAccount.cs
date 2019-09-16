using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class UserAccount
    {
        private RemoteWebDriver driver;
        public UserAccount(RemoteWebDriver _driver) => driver = _driver;
        #region intialise webelements
        //Click on profile drop down
        private IWebElement DdlProfile => driver.FindElement(By.XPath("//a[contains(.,'Go to Profile')]"));
        //Click on password change
        private IWebElement DdlPasswordChage => driver.FindElement(By.XPath("//a[contains(.,'Change Password')]"));
        //Click on current password 
        private IWebElement txtCurrentPassword => driver.FindElement(By.XPath("//input[@placeholder='Current Password']"));
        //Click on new password
        private IWebElement txtNewPassword => driver.FindElement(By.XPath("//input[@placeholder='New Password']"));
        //Click on cofirm password 
        private IWebElement txtConfirmPassword => driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']"));
        //Click on save
        private IWebElement btnSave => driver.FindElement(By.XPath("//button[@type='button']"));
        //Click on Account setting
        private IWebElement DdlAccountSetting => driver.FindElement(By.XPath("//a[@href='/Account/Settings']"));
        //Clikc on name ico
        private IWebElement Namewriteicon => driver.FindElement(By.XPath("//*[@id='account-settings-section']/div/div[2]/div[2]/div/div[2]/div/div[1]/div[2]/form/div/div/i"));
        //Input  name
        private IWebElement txtName => driver.FindElement(By.XPath("//input[contains(@id,'Name')]"));
        //Click on save
        private IWebElement btnAcctNameSave => driver.FindElement(By.XPath("//button[contains(.,'Save')]"));
        //Click on password
        private IWebElement PasswordWriteicon => driver.FindElement(By.XPath("//*[@id='account-settings-section']/div/div[2]/div[2]/div/div[2]/div/div[2]/div[2]/form/div/div/i"));
        //input on current password
        private IWebElement txtAcctCurrentPassword => driver.FindElement(By.XPath("//input[@name='oldPassword']"));
        //input new password
        private IWebElement txtAcctNewPassword => driver.FindElement(By.XPath("//input[@name='newPassword']"));
        //input confirm password
        private IWebElement txtAcctConfirmPassword => driver.FindElement(By.XPath("//input[@name='confirmPassword']"));
        //Click on save
        private IWebElement btnAcctPasswordSave => driver.FindElement(By.XPath("//button[contains(.,'Save')]"));
        //Clikc on Deactivate 
        private IWebElement btnDeactivate => driver.FindElement(By.XPath(""));

        #endregion

        internal void GotoProfile()
        {
            //click on profile
            DdlProfile.Click();
            Base.test.Log(LogStatus.Info, "Go to Profile Test Successful");
        }

        //Profile Change Password
        internal void ChangePassword()
        {
            //click on password change tab
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();",DdlPasswordChage);
            //Input Current password 
            txtCurrentPassword.SendKeys("12");
            //Input new password
            txtNewPassword.SendKeys("123");
            //Input confirm password
            txtConfirmPassword.SendKeys("123");
            //check if current and new password are same
            if(txtAcctCurrentPassword==txtAcctNewPassword)
            {
                Base.test.Log(LogStatus.Info, "Current Password and New Passwords should not be same");
            }
            _ = Extension.WaitForElementClickable(btnSave, driver, 60);
            btnSave.Click();
            Base.test.Log(LogStatus.Info, "Changed Password Successfully");

        }

        //Account setting
        internal void AccountSetting()
        {
            //click on account setting
            IJavaScriptExecutor jsname = (IJavaScriptExecutor)driver;
            jsname.ExecuteScript("arguments[0].click();", DdlAccountSetting);
            //click on name write icon
            IJavaScriptExecutor jsnameicon = (IJavaScriptExecutor)driver;
            jsnameicon.ExecuteScript("arguments[0].click();", Namewriteicon);
            //input name
            txtName.Clear();
            IJavaScriptExecutor jstxtname = (IJavaScriptExecutor)driver;
           jstxtname.ExecuteScript("arguments[0].value='Prabhavathi';", txtName);
           // txtName.SendKeys("Prabhavathi");   
            if (btnAcctNameSave.Displayed)
            {
                _ = Extension.WaitForElementClickable(btnAcctNameSave, driver, 60);
                //save account name
                IJavaScriptExecutor jsnamesave = (IJavaScriptExecutor)driver;
                jsnameicon.ExecuteScript("arguments[0].click();", btnAcctNameSave);
              
            }
            //click on passwrod write icon
            _ = Extension.WaitForElementClickable(PasswordWriteicon, driver, 60);
            IJavaScriptExecutor jspasswordicon = (IJavaScriptExecutor)driver;
           jspasswordicon.ExecuteScript("arguments[0].click();", PasswordWriteicon);
            //input old password
            IJavaScriptExecutor jsoldpassword = (IJavaScriptExecutor)driver;
            jspasswordicon.ExecuteScript("arguments[0].value='1223'; txtAcctCurrentPassword");
            
            //input new password
            IJavaScriptExecutor jsnewpassword = (IJavaScriptExecutor)driver;
            jspasswordicon.ExecuteScript("arguments[0].value='12236';", txtAcctNewPassword);
            //input confirm password
            IJavaScriptExecutor jsconfirmpassword = (IJavaScriptExecutor)driver;
            jspasswordicon.ExecuteScript("arguments[0].value='12236';", txtAcctConfirmPassword);
            _ = Extension.WaitForElementClickable(btnSave, driver, 60);
            btnAcctPasswordSave.Click();
            Base.test.Log(LogStatus.Info, "Account Setting Password Changed Successfully");
        }
        //Deactivate account
        internal void Deactivate()
        {
            btnDeactivate.Click();
            Base.test.Log(LogStatus.Info, "Account Deactivated Successfully");
        }
    }
}
