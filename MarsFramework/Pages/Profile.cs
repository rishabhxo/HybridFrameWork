using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RelevantCodes.ExtentReports;
using Assert = NUnit.Framework.Assert;

namespace MarsFramework
{
    internal class Profile
    {

        private RemoteWebDriver driver;
        public Profile(RemoteWebDriver _driver) => driver = _driver;

        #region  Initialize Web Elements 

        //Click on Profile button
        private IWebElement tbProfile => driver.FindElement(By.XPath("//section//a[contains(text(),'Profile')]"));
        // Click the dropdown icon of Name
        private IWebElement nameIcon => driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']"));
        //Click on First Name
        private IWebElement txtFirstName => driver.FindElement(By.XPath("//input[@name='firstName']"));
        //Click on Last Name
        private IWebElement txtLastName => driver.FindElement(By.XPath("//input[@name='lastName']"));

        //Click on Save button

        private IWebElement btnSave => driver.FindElement(By.XPath("//button[contains(.,'Save')]"));
        //Click on Availablity
        private IWebElement AvailabilityIcon => driver.FindElement(By.XPath("//span[contains(text(),'Time')]//i[contains(@class,'write icon')]"));

        //Click on Availability type
        private IWebElement AvailabilityType => driver.FindElement(By.Name("availabiltyType"));

        // Finding the write icon of Hours

        private IWebElement HoursIcon => driver.FindElement(By.XPath("//div[@class='item']//strong[contains(text(),'Hours')]//..//..//i[contains(@class,'write icon')]"));

        // Finding the type of Hours

        private IWebElement HoursType => driver.FindElement(By.Name("availabiltyHour"));

        // Finding the write icon of Earn Target

        private IWebElement EarnIcon => driver.FindElement(By.XPath("//span[contains(text(),'month')]//i[contains(@class,'write icon')]"));

        // Finding the type of Earn Target

        private IWebElement EarnType => driver.FindElement(By.Name("availabiltyTarget"));


        // Findting the write icon of Description

        private IWebElement DescriptionWriteIcon => driver.FindElement(By.XPath("//i[contains(@class,'outline write icon')]"));

        // Finding the Description field

        private IWebElement TxtDescriptionField => driver.FindElement(By.Name("value"));

        // Finding the Save button

        private IWebElement btnSaveDescription => driver.FindElement(By.XPath("//button[contains(@type,'button')]"));

        //Add Language Tab 
        private IWebElement TbLanguage => driver.FindElement(By.XPath("//a[contains(.,'Languages')]"));

        //Add Language Tab
        private IWebElement btnAddNewLanguage => driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[11]"));

        //Enter the Language on text box
        private IWebElement txtLangName => driver.FindElement(By.XPath("//input[contains(@name,'name')]"));

        //EChoose Languge Level Box
        private IWebElement DdlLangLevel => driver.FindElement(By.XPath("//select[@name='level']"));


        //Add Language      
        private IWebElement btnAddLang => driver.FindElement(By.XPath("//input[@value='Add']"));

        //Add Skill tab
        private IWebElement tbSkill => driver.FindElement(By.XPath("//a[contains(.,'Skills')]"));
        //Add new skill
        private IWebElement btnAddNewSkill => driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        //Add Skill name
        private IWebElement txtSkillName => driver.FindElement(By.XPath("//input[contains(@name,'name')]"));
        //Select Skill level
        private IWebElement DdlSkillLevel => driver.FindElement(By.XPath("//select[contains(@name,'level')]"));
        //Click on Add 
        private IWebElement btnAddSkill => driver.FindElement(By.XPath("//input[contains(@value,'Add')]"));
        //Click on Education tab 
        private IWebElement tbEducation => driver.FindElement(By.XPath("//a[@class='item'][contains(text(),'Education')]"));
        //Click on Add new for education
        private IWebElement btnAddNewEducation => driver.FindElement(By.XPath(("//div[contains(@class,'active')]//div[contains(@class,'button')][contains(text(),'Add New')]")));
        //Add College/university name 
        private IWebElement txtCollegeName => driver.FindElement(By.Name("instituteName"));
        //select country
        private IWebElement DdlCountry => driver.FindElement(By.Name("country"));
        //select title 
        private IWebElement DdlTitle => driver.FindElement(By.Name("title"));
        //Add Degreee 
        private IWebElement txtDegree => driver.FindElement(By.Name("degree"));
        //select graduation year 
        private IWebElement DdlGraduationYear => driver.FindElement(By.Name("yearOfGraduation"));
        //Add new education button 
        private IWebElement btnAddEducation => driver.FindElement(By.XPath("//input[@type='button'][@value='Add']"));
        //click on certifications tab

        private IWebElement tbCertifications => driver.FindElement(By.XPath("//a[contains(.,'Certifications')]"));
        //click add new for certifcation
        private IWebElement btnAddNewCertifications => driver.FindElement(By.XPath("(//div[@class='ui teal button '])[3]"));
        //Add certificate name 
        private IWebElement txtCertificateName => driver.FindElement(By.Name("certificationName"));
        //Add certificate from 
        private IWebElement txtCertificateFrom => driver.FindElement(By.Name("certificationFrom"));
        //Select year of certification 
        private IWebElement DdlCertificationYear => driver.FindElement(By.Name("certificationYear"));
        //Add certificate 
        private IWebElement btnAddCertification => driver.FindElement(By.XPath("//input[@type='button'][@value='Add']"));

        
        #endregion

        internal void ClickProfile()
        {
            Extension.WaitForElement(driver, By.XPath("//section//a[contains(text(),'Profile')]"), 10);
            //Click on Edit button
            tbProfile.Click();
            Assert.That(tbProfile.Text, Is.EqualTo("Profile"));
            Base.test.Log(LogStatus.Info, "Profile Tab Click Success");
        }
        internal void EditProfile()
        {
           
            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Extent report
            Base.test = Base.extent.StartTest("Edit Profile Test");
            _ = Extension.WaitForElementClickable(nameIcon, driver, 60);
            // Click the arrow icon of Name
            nameIcon.Click();
            // Input the First Name field with valid characters
            txtFirstName.Clear();
            txtFirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            // Input the Last Name field with valid characters
            txtLastName.Clear();
            txtLastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));
            _ = Extension.WaitForElementClickable(btnSave, driver, 60);
            // Click the Save button
            btnSave.Click();
            Base.test.Log(LogStatus.Info, "FirstName,LastName updated");
            // Verify if update the name successfully
            IWebElement FullName = driver.FindElement(By.XPath("//div[@class='title'][contains(text(),'Prabha QA')]"));
            Assert.That(FullName.Text, Is.EqualTo("Prabha QA"));
        }
        
        internal void EditAvailability()
        {

            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Thread.Sleep(500);
            //Extent report
            Base.test = Base.extent.StartTest("Edit Availabilty Test");
            // Click the write icon of Availability
            _ = Extension.WaitForElementClickable(AvailabilityIcon, driver, 60);
            AvailabilityIcon.Click();

            // Select the type of Availability
            AvailabilityType.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Availability"));
            Base.test.Log(LogStatus.Info, "Availability updated");

            // Verify if edit the Availability successfully
            IWebElement Availability = driver.FindElement(By.XPath("//span[contains(text(),'Time')]"));
            Assert.That(Availability.Text, Is.EqualTo("Full Time"));
        }


        internal void EditHours()
        {
            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Extent report
            Base.test = Base.extent.StartTest("Edit Hours Test");

            _ = Extension.WaitForElementClickable(HoursIcon, driver, 60);
            // Click the write icon of Hours
            HoursIcon.Click();

            // Select the type of Hours
            HoursType.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));
            Base.test.Log(LogStatus.Info, "Hours updated");

            // Verify if edit the Hours successfully
            IWebElement Hours = driver.FindElement(By.XPath("//span[contains(text(),'week')]"));
            Assert.That(Hours.Text, Is.EqualTo("More than 30hours a week"));
        }

        internal void EditEarnTarget()
        {
            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Extent report
            Base.test = Base.extent.StartTest("Edit Earn Target Test");

            _ = Extension.WaitForElementClickable(EarnIcon, driver, 60);
            // Click the write icon of Earn Target
            EarnIcon.Click();

            // Select the type of Earn Target
            EarnType.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));
            Base.test.Log(LogStatus.Info, "EarnTarget updated");

            // Verify if edit the Earn Target successfully
            IWebElement EarnTarget = driver.FindElement(By.XPath("//span[contains(text(),'month')]"));
            Assert.That(EarnTarget.Text, Is.EqualTo("More than $1000 per month"));
        }

        internal void EditDescription()
        {
            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Extent report
            Base.test = Base.extent.StartTest("Edit Description Test");
           // _ = Extension.WaitForElementClickable(DescriptionWriteIcon, driver, 60);
            // Click the write icon of Description
            DescriptionWriteIcon.Click();
            // Input the Description field with valid characters
            TxtDescriptionField.Clear();
            TxtDescriptionField.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            _ = Extension.WaitForElementClickable(btnSaveDescription, driver, 60);
            // Click the Save button
            btnSaveDescription.Click();
            Base.test.Log(LogStatus.Info, "Description has been saved successfully");
            _ = Extension.WaitForElement(driver, By.XPath("//div[contains(@class,'ns-type-success')]"), 60);
            // Verify if edit the Description successfully 
            IWebElement Description = driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
            Assert.That(Description.Text, Is.EqualTo("Description has been saved successfully"));
        }

        //Add Language
        internal void AddLanguage()
        {
            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Click on Profile tab 
            tbProfile.Click();
            _ = Extension.WaitForElementClickable(TbLanguage, driver, 60);
            //clock on language tab
            TbLanguage.Click();
            _ = Extension.WaitForElementClickable(btnAddNewLanguage, driver, 60);
            // Click the Add New button
            btnAddNewLanguage.Click();
            // Input the Language name field with valid characers
            txtLangName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LanguagesName"));
            Base.test.Log(LogStatus.Info, "Language Name added");
            // select level
            DdlLangLevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LanguagesLevel"));
            Base.test.Log(LogStatus.Info, "LanguageLevel selected");
            //_ = Extension.WaitForElementClickable(btnAddLang, driver, 60);
            // Click the Add button
            btnAddLang.Click();
             Base.test.Log(LogStatus.Info, "French has been added to your languages");
          //  _ = Extension.WaitForElement(driver, By.XPath("//div[contains(@class,'ns-type-success')]"), 60);
            // Verify if add the new Language successfully 
            IWebElement Language = driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
            Assert.That(Language.Text, Is.EqualTo("French has been added to your languages"));

        }
        internal void Skills()
        {
            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Click on Profile tab 
            tbProfile.Click();
            _ = Extension.WaitForElementClickable(tbSkill, driver, 60);
            //click on skil tab
            tbSkill.Click();
            _ = Extension.WaitForElementClickable(btnAddNewSkill, driver, 60);
            // Click the Add New button
            btnAddNewSkill.Click();
            // Input the name field with valid characers
            txtSkillName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillsName"));
            Base.test.Log(LogStatus.Info, "Skill Name Added");
            // select level
            DdlSkillLevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillsLevel"));
            Base.test.Log(LogStatus.Info, "Skill Level Selected");
            //_ = Extension.WaitForElementClickable(btnAddSkill, driver, 60);
            // Click the Add button
            btnAddSkill.Click();
            Base.test.Log(LogStatus.Info, "C# has been added to your languages");
            //_ = Extension.WaitForElement(driver, By.XPath("//div[contains(@class,'ns-type-success')]"), 60);
            // Verify if add the new Language successfully 
            IWebElement Skills = driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
            Assert.That(Skills.Text, Is.EqualTo("C# has been added to your skills"));

        }
        internal void Education()
        {
            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Click on Profile tab 
            tbProfile.Click();
            _ = Extension.WaitForElementClickable(tbEducation, driver, 60);
            //click on education
            tbEducation.Click();
            _ = Extension.WaitForElementClickable(btnAddNewEducation, driver, 60);
            // Click the Add New button
            btnAddNewEducation.Click();
            // Input the name field with valid characers
            txtCollegeName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "InstituteName"));
            Base.test.Log(LogStatus.Info, "College Name Added");
            //select country
            DdlCountry.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Country"));
            Base.test.Log(LogStatus.Info, "Country Selected");
            //select title
            DdlTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Base.test.Log(LogStatus.Info, "Title Added");
            //input degree
            txtDegree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));
            Base.test.Log(LogStatus.Info, "Degree Added");
            //select graducation year
            DdlGraduationYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "GraduationYear"));
            Base.test.Log(LogStatus.Info, "Graduation year added");
            //_ = Extension.WaitForElementClickable(btnAddEducation, driver, 60);
            // Click the Add button
            btnAddEducation.Click();
            Base.test.Log(LogStatus.Info, "Education has been added to your profile");
            _ = Extension.WaitForElement(driver, By.XPath("//div[contains(@class,'ns-type-success')]"), 60);
            // Verify if add the new Language successfully 
            IWebElement Education = driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
            Assert.That(Education.Text, Is.EqualTo("Education has been added"));

        }
        internal void Certification()
        {
            // Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Click on Profile tab 
            tbProfile.Click();
            _ = Extension.WaitForElementClickable(tbCertifications, driver, 60);
            //click on certifictions tab
            tbCertifications.Click();
           // _ = Extension.WaitForElementClickable(btnAddNewCertifications, driver, 60);
            // Click the Add New button
            btnAddNewCertifications.Click();
            // Input the name field with valid characers
            txtCertificateName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertificationsName"));
            Base.test.Log(LogStatus.Info, "Certification Name Added");
            //input certification from 
            txtCertificateFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertificationsFrom"));
            Base.test.Log(LogStatus.Info, "Certification From Added");
            //select certification year
            DdlCertificationYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertificationsYear"));
            Base.test.Log(LogStatus.Info, "CertificationsYear Added");
            //_ = Extension.WaitForElementClickable(btnAddCertification, driver, 60);
            // Click the Add button
            btnAddCertification.Click();
            Base.test.Log(LogStatus.Info, "ISTQB has been added to your certification Successfully");
            _ = Extension.WaitForElement(driver, By.XPath("//div[contains(@class,'ns-type-success')]"), 60);
            // Verify if add the new Language successfully 
            IWebElement Certification = driver.FindElement(By.XPath("//div[contains(@class,'ns-type-success')]"));
            Assert.That(Certification.Text, Is.EqualTo("ISTQB has been added to your certification"));

        }
    }
}