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
    class SearchSkill
    {
        private RemoteWebDriver driver;
        public SearchSkill(RemoteWebDriver _driver) => driver = _driver;

        #region initialse the webelements
        //Search input
        private IWebElement txtSearch => driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));
        //Click search icon
        private IWebElement SearchIcon => driver.FindElement(By.XPath("//i[@class='search link icon']"));
        //Input Search category
        private IWebElement tbSearchCategory => driver.FindElement(By.XPath("//a[@class='item category'][contains(text(),'Programming & Tech')]"));
        //Input Search Sub Category
        private IWebElement tbSearchSubCategory => driver.FindElement(By.XPath("//a[@class='item subcategory'][contains(text(),'QA')]"));
        //Click on Onsite
        private IWebElement tbOnsite => driver.FindElement(By.XPath("//button[contains(text(),'Onsite')]"));
        //Click on Online
        private IWebElement tbOnline => driver.FindElement(By.XPath("//button[contains(.,'Online')]"));
        //Click on Showall
        private IWebElement tbShowAll => driver.FindElement(By.XPath("//button[contains(.,'ShowAll')]"));


        #endregion

        internal void SearchByCategoryandSubCategory()
        {
            txtSearch.SendKeys("Test");
            SearchIcon.Click();
            _ = Extension.WaitForElementClickable(tbSearchCategory, driver, 10);
            tbSearchCategory.Click();
            Base.test.Log(LogStatus.Info, "Search by Category Is Successfull");
            _ = Extension.WaitForElementClickable(tbSearchSubCategory, driver, 10);
            tbSearchSubCategory.Click();
            Base.test.Log(LogStatus.Info, "Search by SubCategory Is Successfull");
        }
        internal void SearchByFilter()
        {
            txtSearch.SendKeys("Test");
            SearchIcon.Click();
            _ = Extension.WaitForElementClickable(tbOnline, driver, 10);
            tbOnline.Click();
            Base.test.Log(LogStatus.Info, "Search by Filter Online Successfull");
            _ = Extension.WaitForElementClickable(tbOnsite, driver, 10);
            tbOnsite.Click();
            Base.test.Log(LogStatus.Info, "Search by Filter Onsite  Successfull");
            _ = Extension.WaitForElementClickable(tbShowAll, driver, 10);
            tbShowAll.Click();
            Base.test.Log(LogStatus.Info, "Search by Filter ShowAll Is Successfull");
        }
    }
}
