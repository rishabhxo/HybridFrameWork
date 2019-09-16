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
    class Chat
    {
        private RemoteWebDriver driver;
        public Chat(RemoteWebDriver _driver) => driver = _driver;

        #region initialise web elements
        private IWebElement tbChat => driver.FindElement(By.XPath("//a[contains(.,'Chat')]"));
        #endregion

        internal void Chatting()
        {
            _ = Extension.WaitForElementClickable(tbChat, driver, 60);
            tbChat.Click();
            Base.test.Log(LogStatus.Info, "Chat Test Successful");
        }
    }
}
