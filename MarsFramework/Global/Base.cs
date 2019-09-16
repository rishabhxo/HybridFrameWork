using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using RelevantCodes.ExtentReports;
using System;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
    public enum BrowserType
    {
        Firefox,
        Chrome
    }

    [TestFixture]
    public class Base
    {

        private BrowserType _BrowserType;
        public RemoteWebDriver _driver;
        public Base(BrowserType browser)
        {
            _BrowserType = browser;
        }

        #region To access Path from resource file

         public static int Browser = Int32.Parse(MarsResource.Browser);
         public static String ExcelPath = MarsResource.ExcelPath;
         public static string ScreenshotPath = MarsResource.ScreenShotPath;
         public static string ReportPath = MarsResource.ReportPath;
         public static string ReportXMLPath = MarsResource.ReportPath;
        
        
        #endregion


        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
  
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
            ChooseBrowser(_BrowserType);
            void ChooseBrowser(BrowserType browserType)
            {
                if (browserType == BrowserType.Firefox)
                {
                    _driver = new FirefoxDriver();
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                   
                }
                else if (browserType == BrowserType.Chrome)
                {
                    try
                    { 
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                    }
                    catch(TimeoutException e)
                    {
                        
                        Console.WriteLine(e.Message);

                    }

                }

            }

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(ReportXMLPath);

            #endregion

          //  bool IsLogin = true;

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn(_driver);
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp(_driver);
                obj.Register();
            }

        }


        [TearDown]
        public void TearDown()
        {
              // Screenshot
              string img = SaveScreenShotClass.SaveScreenshot(_driver, "Report");
            // Thread.Sleep(1000);
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));
              // end test. (Reports)
              extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
              // Close the driver            
              _driver.Close();
              _driver.Quit();
              
           }
        #endregion

    }
}