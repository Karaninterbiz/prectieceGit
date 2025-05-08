/*using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Demo_Framework.Utilities
{
    [TestFixture]
    [Parallelizable]
    public class BaseClass
    {

        public static ThreadLocal<IWebDriver> threadDriver = new();
        public static IWebDriver driver => threadDriver.Value;
        public static ChromeOptions option;
        protected static ExtentReports extent;
        protected static ExtentSparkReporter sparkReporter;
        protected ThreadLocal<ExtentTest> test = new();

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            if (extent == null)
            {
                string folderPath = "C:\\Users\\ibz\\Documents\\Nunit_Automation\\Nunit_Automation\\Reports\\";
                string currentTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string reportFileName = Path.Combine(folderPath, $"TestReport_{currentTime}.html");
                sparkReporter = new ExtentSparkReporter(reportFileName);
                sparkReporter.Config.ReportName = "Automation Testing Report";
                sparkReporter.Config.DocumentTitle = "Automation Testing";
                sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;
                extent = new ExtentReports();
                extent.AttachReporter(sparkReporter);
                extent.AddSystemInfo("Application", "Practice");
            }

        }
        [SetUp]
        public void Setup()
        {

            option = new ChromeOptions();
            option.AddArgument("--incognito");
            *//*option.AddArgument("--headless");*//*
            threadDriver.Value = new ChromeDriver(option);
            test.Value = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void TearDown()
        {
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {


                var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.Value.Fail("Test Failed : " + errorMessage).AddScreenCaptureFromBase64String(screenshot, "Failure Screenshot");
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                //test.Value.Pass("Test Passed");
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.Value.Pass("Test Passed : " + errorMessage).AddScreenCaptureFromBase64String(screenshot, "Passed Screenshot");
            }
            if (driver != null)
            {
                driver.Quit();
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.Flush();
        }
        
    }
}

*/