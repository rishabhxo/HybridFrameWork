using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using MarsFramework.Global;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using System.Threading;
using RelevantCodes.ExtentReports;
using System.Collections.Generic;
using static MarsFramework.Global.GlobalDefinitions;
using AutoItX3Lib;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        private RemoteWebDriver _driver;
        public ShareSkill(RemoteWebDriver driver) => _driver = driver;

        #region Initialize Web Elements 

        // ShareSkills button
        IWebElement TbShareSkill => _driver.FindElementByXPath("//a[@class='ui basic green button']");

        // Title
        IWebElement TxtBoxTitle => _driver.FindElementByName("title");

        // Description
        IWebElement TxtBoxDescription => _driver.FindElementByName("description");

        // Select Category
        IWebElement DdlCategory => _driver.FindElementByName("categoryId");


        //Select SubCategory 
        IWebElement DdlSubCategory => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(3) div.twelve.wide.column div.fields div.five.wide.field:nth-child(2) div.fields:nth-child(1) > select.ui.fluid.dropdown");


        //Select Tag Names
        IWebElement TxtBoxTag => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(4) div.twelve.wide.column div.form-wrapper.field div.ReactTags__tags div.ReactTags__selected div.ReactTags__tagInput > input.ReactTags__tagInputField");

        //Select Service Type -Hourly Basis
        IWebElement RdoServiceTypeHourly => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(5) div.twelve.wide.column div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)");

        //Select Service Type -One-off
        IWebElement RdoServiceTypeOnOff => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(5) div.twelve.wide.column div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)");
        //Select Location Type - Onsite

        //Select Location Type - Onsite
        IWebElement RdoLocationTypeOnsite => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(6) div.twelve.wide.column div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)");

        //Select Location Type - Onsite
        IWebElement RdoLocationTypeOnline => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(6) div.twelve.wide.column div.inline.fields div.field:nth-child(2) div.ui.radio.checkbox > input:nth-child(1)");

        //Avilable Days -Start Date
        IWebElement DtpStartDate => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(7) div.twelve.wide.column div.form-wrapper div.fields:nth-child(1) div.five.wide.field:nth-child(2) > input:nth-child(1)");

        //Avilable Days -End Date
        IWebElement DtpEndDate => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(7) div.twelve.wide.column div.form-wrapper div.fields:nth-child(1) div.five.wide.field:nth-child(4) > input:nth-child(1)");

        //Skill Trade - Skill Exchange
        IWebElement RdoSkillExchange => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.twelve.wide.column:nth-child(2) div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)");

        // Skill Exchange - Required Skills
        IWebElement TxtBoxRequiredSkills => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.twelve.wide.column:nth-child(4) div.field div.form-wrapper div.ReactTags__tags div.ReactTags__selected div.ReactTags__tagInput > input.ReactTags__tagInputField");

        //Skill Trade - Credit
        IWebElement RdoCredit => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.twelve.wide.column:nth-child(2) div.inline.fields div.field:nth-child(2) div.ui.radio.checkbox > label:nth-child(2)");


        //Credit - Enter Amount
        private IWebElement TxtBoxCreditAmount => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.ten.wide.column:nth-child(4) div:nth-child(1) div.ui.right.labeled.input > input:nth-child(2)");

        // Status Active 
        private IWebElement RdoStatusActive => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(10) div.twelve.wide.column div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)");

        // Status Hidden 
        IWebElement RdoStatusHidden => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(10) div.twelve.wide.column div.inline.fields div.field:nth-child(2) div.ui.radio.checkbox > label:nth-child(2)");

        // Work Sample 
        IWebElement FilWorkSample => _driver.FindElementByCssSelector("//*[@id='selectFile']");

        // Save Share Skills
        IWebElement BtnSaveShareSkills => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.ui.vertically.padded.right.aligned.grid:nth-child(11) div.sixteen.wide.column > input.ui.teal.button:nth-child(1)");

        // Cancel Share Skills
        IWebElement BtnCancelShareSkills => _driver.FindElementByCssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.ui.vertically.padded.right.aligned.grid:nth-child(11) div.sixteen.wide.column > input.ui.teal.button:nth-child(1)");

        #endregion

        internal void EnterShareSkill()
        {
            #region Navigate to Share Skills Page

            // Wait for Skill Tab 
            _ = Extension.WaitForElementClickable(TbShareSkill, _driver, 60);
            // Click on Share Skills Page
            TbShareSkill.Click();
            //Populate the excel data            
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkills");
			//Validating ShareSkill Button
           
		
            #endregion


            #region Enter Title 

            //Enter the data in Title textbox
            TxtBoxTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "title"));
			//Validate  Field is empty
            string inputTitleBox = TxtBoxTitle.GetAttribute("Value");
			 if(inputTitleBox.Length==0)
            {
                Assert.IsEmpty("TxtBoxTitle");
            }

            #endregion

            #region Enter Description

            //Enter the data in Description textbox
            TxtBoxDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EnterDescription"));
			//Validate  Field is empty
            string inputDescBox = TxtBoxDescription.GetAttribute("Value");
			 if(inputDescBox.Length==0)
            {
                Assert.IsEmpty("TxtBoxDescription");
            }

            #endregion

            #region Category Drop Down

            //Validate Category
            _ = Extension.WaitForElementClickable(DdlCategory, _driver, 10);
			// Click on Category Dropdown
            DdlCategory.Click();

            
            // Select Category from Category Drop Down
            var ddlCategory = new SelectElement(DdlCategory);
            ddlCategory.SelectByText((GlobalDefinitions.ExcelLib.ReadData(2, "category")));
            //Validate Category
            _ = Extension.WaitForElementClickable(DdlSubCategory, _driver, 10);
            // Click on Sub-Category Dropdown
            DdlSubCategory.Click();
            //Select Sub-Category from the Drop Down
            var ddlSubCategory = new SelectElement(DdlSubCategory);
            ddlSubCategory.SelectByText((GlobalDefinitions.ExcelLib.ReadData(2, "subcategory")));
            #endregion

            #region Tags
            // Eneter Tag
            TxtBoxTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "TagName"));
            TxtBoxTag.SendKeys(Keys.Enter);
			//Validate  Field is empty
            string inputTagBox = TxtBoxTag.GetAttribute("Value");
			 if(inputTagBox.Length==0)
            {
                Assert.IsEmpty("TxtBoxTag");
            }
            #endregion

            #region Service Type Selection

            // Service Type Selection

            if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "Hourly basis service")
            {
                RdoServiceTypeHourly.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "One-off service")
            {
                RdoServiceTypeOnOff.Click();
            }
            #endregion

            #region Select Location Type
            // Location Type Selection

            if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectLocationType") == "On-site")
            {
                RdoLocationTypeOnsite.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectLocationType") == "Online")
            {
                RdoLocationTypeOnline.Click();
            }
            #endregion

            #region Select Available Dates from Calendar
            // Select Start Date           
             string sdate = GlobalDefinitions.ExcelLib.ReadData(2, "Start Date");
            DtpStartDate.SendKeys(Keys.Backspace);
            string format = "dd/MM/yyyy";
            string newStartDate = DateTime.Parse(sdate).ToString(format);
            DtpStartDate.SendKeys(newStartDate);
            DtpEndDate.SendKeys(Keys.Backspace);
            // Select End Date
            string edate = GlobalDefinitions.ExcelLib.ReadData(2, "End Date");
            string newEndDate = DateTime.Parse(edate).ToString(format);
            DtpEndDate.SendKeys(newEndDate);
			
            //Availiable Days
            string selectSunMon = Global.GlobalDefinitions.ExcelLib.ReadData(2, "DayOneSel");
            string selectTuWed = Global.GlobalDefinitions.ExcelLib.ReadData(2, "DayTwoSel");
            string selectThuFri = Global.GlobalDefinitions.ExcelLib.ReadData(2, "DayThreeSel");
            //select Sunday or Monday
            if (selectSunMon.Contains("Sun") || selectSunMon.Contains("Mon"))
            {
                if (selectSunMon.Contains("Sun"))
                {
                    var checkSun = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[2]/div[1]/div/input"));
                    checkSun.Click();
                    string[] arrDate = selectSunMon.Split(',');
                    string day = arrDate[0].ToString();
                    string startTimeSun = arrDate[1].ToString();
                    string endTimeSun = arrDate[2].ToString();
                    var enterStartTimeSun = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[2]/div[2]/input"));
                    enterStartTimeSun.Click();
                    enterStartTimeSun.SendKeys(startTimeSun);
                    var enterEndTimeSun = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[2]/div[3]/input"));
                    enterEndTimeSun.Click();
                    enterEndTimeSun.SendKeys(endTimeSun);
                }
                else
                {
                    var checkMon = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[3]/div[1]/div/input"));
                    checkMon.Click();
                    string[] arrDate2 = selectSunMon.Split(',');
                    string day = arrDate2[0].ToString();
                    string startTimeMon = arrDate2[1].ToString();
                    string endTimeMon = arrDate2[2].ToString();
                    var enterStartTimeMon = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[3]/div[2]/input"));
                    enterStartTimeMon.Click();
                    enterStartTimeMon.SendKeys(startTimeMon);
                    var enterEndTimeMon = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[3]/div[3]/input"));
                    enterEndTimeMon.Click();
                    enterEndTimeMon.SendKeys(endTimeMon);
                }
            }

            if (selectTuWed.Contains("Tue") || selectTuWed.Contains("Wed"))
            {
                if (selectTuWed.Contains("Tue"))
                {
                    var checkTue = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[4]/div[1]/div/input"));
                    checkTue.Click();
                    string[] arrDate3 = selectTuWed.Split(',');
                    string day = arrDate3[0].ToString();
                    string startTimeTue = arrDate3[1].ToString();
                    string endTimeTue = arrDate3[2].ToString();
                    var enterStartTimeTue = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[4]/div[2]/input"));
                    enterStartTimeTue.Click();
                    enterStartTimeTue.SendKeys(startTimeTue);
                    var enterEndTimeTue = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[4]/div[3]/input"));
                    enterEndTimeTue.Click();
                    enterEndTimeTue.SendKeys(endTimeTue);

                }
                else
                {
                    var checkWed = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[5]/div[1]/div/input"));
                    checkWed.Click();
                    string[] arrDate4 = selectTuWed.Split(',');
                    string day = arrDate4[0].ToString();
                    string startTimeWed = arrDate4[1].ToString();
                    string endTimeWed = arrDate4[2].ToString();
                    var enterStartTimeWed = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[5]/div[2]/input"));
                    enterStartTimeWed.Click();
                    enterStartTimeWed.SendKeys(startTimeWed);
                    var enterEndTimeWed = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[5]/div[3]/input"));
                    enterEndTimeWed.Click();
                    enterEndTimeWed.SendKeys(endTimeWed);
                }

            }

            if (selectThuFri.Contains("Thu") || selectThuFri.Contains("Fri") || selectThuFri.Contains("Sat"))
            {
                if (selectThuFri.Contains("Thu"))
                {
                    var checkThu = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[6]/div[1]/div/input"));
                    checkThu.Click();
                    string[] arrDate5 = selectTuWed.Split(',');
                    string day = arrDate5[0].ToString();
                    string startTimeThu = arrDate5[1].ToString();
                    string endTimeThu = arrDate5[2].ToString();
                    var enterStartTimeThu = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[6]/div[2]/input"));
                    enterStartTimeThu.Click();
                    enterStartTimeThu.SendKeys(startTimeThu);
                    var enterEndTimeThu = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[6]/div[3]/input"));
                    enterEndTimeThu.Click();
                    enterEndTimeThu.SendKeys(endTimeThu);
                }
                else if (selectThuFri.Contains("Fri"))
                {
                    var checkFri = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[7]/div[1]/div/input"));
                    checkFri.Click();
                    string[] arrDate6 = selectTuWed.Split(',');
                    string day = arrDate6[0].ToString();
                    string startTimeFri = arrDate6[1].ToString();
                    string endTimeFri = arrDate6[2].ToString();
                    var enterStartTimeFri = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[7]/div[2]/input"));
                    enterStartTimeFri.Click();
                    enterStartTimeFri.SendKeys(startTimeFri);
                    var enterEndTimeFri = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[7]/div[3]/input"));
                    enterEndTimeFri.Click();
                    enterEndTimeFri.SendKeys(endTimeFri);
                }
                else if (selectThuFri.Contains("Sat"))
                {
                    var checkSat = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[8]/div[1]/div/input"));
                    checkSat.Click();
                    string[] arrDate7 = selectTuWed.Split(',');
                    string day = arrDate7[0].ToString();
                    string startTimeSat = arrDate7[1].ToString();
                    string endTimeSat = arrDate7[2].ToString();
                    var enterStartTimeSat = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[8]/div[2]/input"));
                    enterStartTimeSat.Click();
                    enterStartTimeSat.SendKeys(startTimeSat);
                    var enterEndTimeSat = _driver.FindElement(By.XPath("//*[@class='ui form']/div[7]/div[2]/div/div[7]/div[3]/input"));
                    enterEndTimeSat.Click();
                    enterEndTimeSat.SendKeys(endTimeSat);
                }

                #endregion


                #region Select Skill Trade
                // Select Skill Trade

                if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectSkillTrade") == "Skill-exchange")
                {

                    RdoSkillExchange.Click();
                    TxtBoxRequiredSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ExchangeSkill"));
                    TxtBoxRequiredSkills.SendKeys(Keys.Enter);
					//Validate  Field is empty
                    string inputRequiredSkillsBox = TxtBoxRequiredSkills.GetAttribute("Value");
			        if(inputRequiredSkillsBox.Length==0)
                     {
                      Assert.IsEmpty("TxtBoxRequiredSkills");
                     }
                }
                else if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectSkillTrade") == "Credit")
                {

                    RdoCredit.Click();
                    Thread.Sleep(1000);
                    TxtBoxCreditAmount.SendKeys(ExcelLib.ReadData(2, "AmountInExchange"));
                    TxtBoxCreditAmount.SendKeys(Keys.Enter);
					//Validate  Field is empty
                    string inputCreditAmountBox = TxtBoxRequiredSkills.GetAttribute("Value");
			        if(inputCreditAmountBox.Length==0)
                     {
                      Assert.IsEmpty("TxtBoxCreditAmount");
                     }
                }
                #endregion

                #region Select User Status
                // Select User Status

                if (GlobalDefinitions.ExcelLib.ReadData(2, "UserStatus") == "Active")
                {
                    RdoStatusActive.Click();
                }
                else if (GlobalDefinitions.ExcelLib.ReadData(2, "UserStatus") == "Hidden")
                {
                    RdoStatusHidden.Click();
                }
                #endregion


                #region Add Work Sample

                // Uploading File path
                 _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")).Click();
                 AutoItX3 autoIt = new AutoItX3();
                 string path = GlobalDefinitions.ExcelLib.ReadData(2, "WorkSample")+"";
                 autoIt.WinActivate("File Upload");
                 autoIt.Send(path);
                 autoIt.Send("{ENTER}");
                #endregion

                #region Save / Cancel Skill
                // Save or Cancel New Skill

                if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SaveOrCancel") == "Save")
                {
                    BtnSaveShareSkills.Click();
                    Thread.Sleep(1000);

                }
                else if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SaveOrCancel") == "Cancel")
                {
                    BtnCancelShareSkills.Click();
                }

                #endregion

            }

        }
       
    }
}








