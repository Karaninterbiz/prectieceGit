using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Demo_Framework.Hooks_BDD
{
    [Binding]
    public class Hooks
    {
        protected static ThreadLocal<IWebDriver> _driver = new();
        protected static ThreadLocal<ExtentTest> _test = new();
        protected static ExtentReports? _extent;
        protected static ExtentSparkReporter? _reporter;
        ChromeOptions option = new ChromeOptions();

        // Before Test Run (Initialize Extent Report)
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string _folderLocation = "C:\\Users\\ibz\\Documents\\NUnit_Demo_Framework\\NUnit_Demo_Framework\\Reports\\";
            string _currentTime = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string _reporterFile = Path.Combine(_folderLocation, $"ExtentReport_{_currentTime}.html");
            _reporter = new ExtentSparkReporter(_reporterFile);
            _reporter.Config.ReportName = "Test Report";
            _reporter.Config.DocumentTitle = "Automation Testing";
            _extent = new ExtentReports();
            _extent.AttachReporter(_reporter);
            _extent.AddSystemInfo("Application", "Practice");

        }
        // After Test Run (Finalize Extent Report)
        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent?.Flush();

        }

        [BeforeScenario]
        public void beforeScenario()
        {
            if (_driver.Value == null)
            {
                option.AddArgument("--incognito");
                //    option.AddArgument("--headless");
                _driver.Value = new ChromeDriver(option);
                _driver.Value.Manage().Window.Maximize();
                _test.Value = _extent.CreateTest("Testing");
            }
        }



        [AfterStep]
        public void AfterStep()
        {

            if (_driver.Value != null && _test.Value != null)
            {
                var _stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                var _stepText = ScenarioStepContext.Current.StepInfo.Text;
                string screenshotBase64 = ((ITakesScreenshot)_driver.Value).GetScreenshot().AsBase64EncodedString;



                switch (_stepType)
                {
                    case "Given":
                        _test.Value.Log(Status.Pass, $"<b>Given:</b> {_stepText}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64, "Screenshot").Build());
                        break;

                    case "When":
                        _test.Value.Log(Status.Pass, $"<b>When:</b> {_stepText}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64, "Screenshot").Build());
                        break;

                    case "Then":
                        _test.Value.Log(Status.Pass, $"<b>Then:</b> {_stepText}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64, "Screenshot").Build());
                        break;

                    case "And":
                        _test.Value.Log(Status.Pass, $"<b>And:</b> {_stepText}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64, "Screenshot").Build());
                        break;

                    default:
                        _test.Value.Log(Status.Pass, $"<b>Step:</b> {_stepText}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64, "Screenshot").Build());
                        break;
                }
                var _errorMessage = TestContext.CurrentContext.Result.Message;
                var _status = TestContext.CurrentContext.Result.Outcome.Status;
                if (_status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                    _test.Value.Log(Status.Fail, $"Step Failed: {_errorMessage}");
                    var _screenshot = ((ITakesScreenshot)_driver.Value).GetScreenshot().AsBase64EncodedString;
                    _test.Value.Fail("Test Failed : " + _errorMessage).AddScreenCaptureFromBase64String(_screenshot, "Failure Screenshot");
                }
                else if (_status == NUnit.Framework.Interfaces.TestStatus.Passed)
                {
                    _test.Value.Log(Status.Info, $"Step Passed");
                    var _screenshot = ((ITakesScreenshot)_driver.Value).GetScreenshot().AsBase64EncodedString;
                    _test.Value.Pass("Test Passed : " + _errorMessage).AddScreenCaptureFromBase64String(_screenshot, "Passes Screenshot");

                }

            }


           /* if (scenarioContext.TestError == null)

            {

                switch (stepType)

                {

                    case "Given": _Scenario.CreateNode<Given>(stepName).Pass("Screenshot : " + MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); break;

                    case "When": _Scenario.CreateNode<When>(stepName).Pass("Screenshot : " + MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); break;

                    case "Then": _Scenario.CreateNode<Then>(stepName).Pass("Screenshot : " + MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); break;

                    case "And": _Scenario.CreateNode<And>(stepName).Pass("Screenshot : " + MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); break;

                }

            }

            else

            {

                switch (stepType)

                {

                    case "Given": _Scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); break;

                    case "When": _Scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); break;

                    case "Then": _Scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); break;

                    case "And": _Scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); break;

                }
*/


        }

            [AfterScenario]
        public static void AfterScenario()
        {

            if (_driver.Value != null)
            {
                try
                {
                    _driver.Value.Quit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Driver already disposed: " + ex.Message);
                }
                finally
                {
                    _driver.Value = null;
                }
            }
        }


    }
}
