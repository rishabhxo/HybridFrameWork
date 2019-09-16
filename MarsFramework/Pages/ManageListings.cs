using MarsFramework.Global;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        private readonly RemoteWebDriver _driver;
        public ManageListings(RemoteWebDriver driver) => _driver = driver;
        #region Initialize WebElements

        //Click on Managelisting tab
        private IWebElement TbManangeList => _driver.FindElement(By.XPath("//a[contains(.,'Manage Listings')]"));
        //Get Table Row
        private IWebElement TblTableBody => _driver.FindElement(By.XPath("//div[@id='listing-management-section']//table//tbody"));
        //Click "Yes" For Delete COnfirmation
        private IWebElement BtnRemoveConfirm => _driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
        #endregion

        //check the added skills
        internal bool CheckListAdded(string Title)
        {
            //check if user is able to View "Listing table" upon clicking "Manage Listings
            bool shareSkillExists = false;
            IWebElement tableElement = _driver.FindElement(By.XPath("//*[@class='ui striped table']"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Contains(Title))
                {
                    shareSkillExists = true;
                    break;
                }
            }
            return shareSkillExists;
        }


        //Remove Method       
        public void DeleteService(string Title)
        {
            TbManangeList.Click();
            IWebElement GridNextPageLink = _driver.FindElement(By.XPath("//button[contains(.,'>')]"));
            IList<IWebElement> tableRows = TblTableBody.FindElements(By.TagName("tr"));
            bool loop = true;
            Base.test = Base.extent.StartTest("Delete Service Test");
            while (loop)
            {
                foreach (IWebElement row in tableRows)
                {
                    if (row.Text.Contains(Title))
                    {
                        IWebElement deleteList = _driver.FindElement(By.XPath("//td[text()='" + Title + "']/..//td/i[3]"));
                        //click on remove icon
                        deleteList.Click();
                        //click on "ok" delete alert message
                        BtnRemoveConfirm.Click();
                        Base.test.Log(LogStatus.Pass, "Test Pass,Service deleted Successfully");
                        SaveScreenShotClass.SaveScreenshot(_driver, "ServiceDeleted");
                        loop = false;
                        return;
                    }
                }
                //Click next page
                GridNextPageLink.Click();
            }
			
			ValidateDeletedService(Title);
        }

      //Verifying if the deleted service is present in the list
      public void ValidateDeletedService(string Title)
	  {
		   
		  
            manageListingsLink.Click();
            try
            {
                bool serviceFound = true;
                int i;
                while (serviceFound)
                {
                    IList<IWebElement> listings = delete.FindElements(By.XPath("//tr/td[8]/i[3]"));
                    int listingCount = listings.Count;
                    Console.WriteLine("Number of Listings : " + listingCount);
                    for (i = 0; i < listingCount; i++)
                    {
                        if (listingCount == 0)
                        {
                            string expectedValue = "Title"
                            string afterDeleting = GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(text(),'You do not have any service listings!')]")).Text;
                            if (afterDeleting == expectedValue)
                            {
                                serviceFound = false;
                                Console.WriteLine("Test Passed: Service is deleted successfully");
                            }
                        }
                        else
                        {
                            IList<IWebElement> listingsAfterDeleting = skillPresent.FindElements(By.XPath("//h2[contains(text(),'Manage Listings')]/parent::div/div/table/tbody/tr/td[3]"));
                            int listingsAfterDeletingCount = listingsAfterDeleting.Count;
                            Console.WriteLine("Number of Listings : " + listingsAfterDeletingCount);
                            for (int l = 0; l < listingsAfterDeletingCount; l++)
                            {
                                int j = l + 1;
                                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]/parent::div/div/table/tbody/tr[" + j + "]/td[3]")).Text;
                                Console.WriteLine("Name is : " + Name);
                                if (Name.Contains(ExcelLib.ReadData(2, "Title")))
                                {
                                    serviceFound = true;
                                    Console.WriteLine("Test Failed : Service is not deleted successfully");
                                    break;
                                }
                                else
                                {
                                    serviceFound = false;
                                    Console.WriteLine("Test Passed : Service has been deleted successfully");
                                    break;
                                }
                            }

                        }
                    }
                    serviceFound = true;
                    nextPage.Click();
                    i = 0;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Searched all the pages and skill is not present");
            }

	  }

    }
}

