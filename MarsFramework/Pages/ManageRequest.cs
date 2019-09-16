using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ManageRequest
    {
        private RemoteWebDriver driver;
        public ManageRequest(RemoteWebDriver _driver) => driver = _driver;

        #region initiase webelements
        private IWebElement tbManageRequest => driver.FindElement(By.XPath("//div[@class='ui dropdown link item active visible']"));
        private IWebElement tbRecievedRequest=> driver.FindElement(By.XPath("//a[contains(.,'Received Requests')]"));

        private IWebElement tbSentRequest => driver.FindElement(By.XPath("//a[contains(.,'Sent Requests')]"));


        #endregion
     internal void RecievedRequest()
        {

            tbRecievedRequest.Click();
        }
        internal void SentRequest()
        {
            tbSentRequest.Click();
        }
    }
}
