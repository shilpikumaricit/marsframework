using AventStack.ExtentReports;
using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        protected ManageListings manageListing;
        protected ExtentReports extent;
        
        [OneTimeSetUp]
        public void Inititalize()
        {
            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    GlobalDefinitions.driver.Navigate().GoToUrl(MarsResource.url);
                    break;
            }

            #region Initialise Reports

            //extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
           // extent.LoadConfig(MarsResource.ReportXMLPath);

            #endregion

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

            // Create manage Listing Object
            manageListing = new ManageListings();

            // Creating extent report for the tests
            extent = ExtendReportManager.getInstance();

        }

        [TearDown]
        public void TakeScreenshot()
        {
            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            extent.Flush();
            GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }
        #endregion

    }
}