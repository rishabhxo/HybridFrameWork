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
    class Notification
    {
        private RemoteWebDriver driver;
        public Notification(RemoteWebDriver _driver) => driver = _driver;
        #region initialse webelements
        //Click on Notification
        private IWebElement DdlNotification => driver.FindElement(By.XPath("//i[@class='dropdown icon']"));
        //click on Notification item
        private IWebElement DdlItem => driver.FindElement(By.XPath("//div[@class='item']"));

        #endregion
        internal void Notify()
        {
            _ = Extension.WaitForElementClickable(DdlNotification, driver, 60);
            DdlNotification.Click();
            if (DdlItem.Text == "You have no notifications")
            {
                Base.test.Log(LogStatus.Info, "You have no notifications");
            }
            
        }
    }
}
