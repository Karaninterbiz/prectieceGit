// --------------------------------------------------------------------------------------------------------------------
//  Author      : Rishabh Vishwakarma
//  File        : ExtentReport.cs
//  Description : Handles setup, logging, and teardown of ExtentReports for the BDD automation framework.
//  Purpose     : 
//     - Initializes the ExtentReports engine and attaches SparkReporter for HTML report generation.
//     - Manages thread-safe logging for Feature and Scenario nodes.
//     - Captures and embeds screenshots (as Base64) for visual traceability of test steps.
//     - Provides step-wise logging for Given, When, Then, And steps with pass/fail status.
//     - Finalizes and renames the test report with a timestamp after execution.
// --------------------------------------------------------------------------------------------------------------------


using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Automation_Framework_Reqnroll_Nunit.Utility
{
    public class ExtentReport : BaseClass
    {
        #region 1. Static Fields and Paths

        // Main report instance (shared across the test run)
        public static ExtentReports ExtentReportsInstance;

        // Thread-safe report nodes for parallel test execution
        [ThreadStatic]
        public static ExtentTest FeatureNode;

        [ThreadStatic]
        public static ExtentTest ScenarioNode;

        // Dynamic directory setup
        public static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string TestResultsPath = BaseDirectory.Replace("bin\\Debug\\net8.0", "TestResults");
        public static string ScreenshotsPath = BaseDirectory.Replace("bin\\Debug\\net8.0", "Screenshots");

        #endregion

        #region 2. Initialize Extent Report

        /// <summary>
        /// Initializes the ExtentReports engine, attaches the Spark (HTML) reporter,
        /// configures metadata, and sets up necessary directories.
        /// </summary>
        public static void InitializeReport()
        {
            if (!Directory.Exists(TestResultsPath))
                Directory.CreateDirectory(TestResultsPath);

            // Clean old screenshots if present
            if (Directory.Exists(ScreenshotsPath))
            {
                Directory.Delete(ScreenshotsPath, recursive: true);
            }

            Directory.CreateDirectory(ScreenshotsPath);

            // Configure Spark reporter (HTML)
            var reportFile = Path.Combine(TestResultsPath, "index.html");
            var sparkReporter = new ExtentSparkReporter(reportFile);
            sparkReporter.Config.DocumentTitle = "Automation Test Report";
            sparkReporter.Config.ReportName = "DME Test Suit";
            sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

            // Attach reporter and set system info
            ExtentReportsInstance = new ExtentReports();
            ExtentReportsInstance.AttachReporter(sparkReporter);
            ExtentReportsInstance.AddSystemInfo("Application", "DMEScripts");
            ExtentReportsInstance.AddSystemInfo("Browser", "Chrome");
            ExtentReportsInstance.AddSystemInfo("Environment", "Test_Server");
            ExtentReportsInstance.AddSystemInfo("OS", "Windows");
            ExtentReportsInstance.AddSystemInfo("SDET", "Rahul Mansarowar");
        }

        #endregion

        #region 3. Finalize Extent Report

        /// <summary>
        /// Flushes the report and renames the output HTML file with a timestamp.
        /// </summary>
        public static void FinalizeReport()
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string reportFileName = $"ExtentReport_{timestamp}.html";

            ExtentReportsInstance.Flush();

            string defaultReportFile = Path.Combine(TestResultsPath, "index.html");
            string renamedReportFile = Path.Combine(TestResultsPath, reportFileName);

            File.Move(defaultReportFile, renamedReportFile);
        }

        #endregion

        #region 4. Screenshot Capture

        /// <summary>
        /// Captures a screenshot from the provided WebDriver instance,
        /// returns it as an embeddable media entity for ExtentReports.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance</param>
        /// <param name="screenshotName">Label to display under the screenshot</param>
        /// <returns>A media entity with the captured screenshot</returns>
        public dynamic CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            // Optional: zoom out to capture more visible area
            executor.ExecuteScript("document.body.style.zoom = '0.9'");

            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            var base64Screenshot = screenshotDriver.GetScreenshot().AsBase64EncodedString;

            executor.ExecuteScript("document.body.style.zoom = '1.0'");

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot, screenshotName).Build();
        }

        #endregion

        #region 5. Log Step to ExtentReport
        /// <summary>
        /// Logs the result of a step into the ExtentReport under the current scenario node.
        /// Categorizes the step type (Given, When, Then, And) and logs it as passed or failed based on the outcome.
        /// </summary>
        /// <param name="stepType">The Gherkin keyword of the step (e.g., Given, When, Then, And)</param>
        /// <param name="stepName">The name/text of the step as written in the feature file</param>
        /// <param name="isPassed">Boolean flag indicating if the step passed or failed</param>
        /// <param name="message">The message to log—step name on pass, error message on failure</param>
        /// <param name="media">Screenshot or media entity to attach to the report step</param>
        public void LogStep(string stepType, string stepName, bool isPassed, string message, dynamic media)
        {
            switch (stepType)
            {
                case "Given":
                    if (isPassed)
                        ScenarioNode.CreateNode<Given>(stepName).Pass(message, media);
                    else
                        ScenarioNode.CreateNode<Given>(stepName).Fail(message, media);
                    break;

                case "When":
                    if (isPassed)
                        ScenarioNode.CreateNode<When>(stepName).Pass(message, media);
                    else
                        ScenarioNode.CreateNode<When>(stepName).Fail(message, media);
                    break;

                case "Then":
                    if (isPassed)
                        ScenarioNode.CreateNode<Then>(stepName).Pass(message, media);
                    else
                        ScenarioNode.CreateNode<Then>(stepName).Fail(message, media);
                    break;

                case "And":
                    if (isPassed)
                        ScenarioNode.CreateNode<And>(stepName).Pass(message, media);
                    else
                        ScenarioNode.CreateNode<And>(stepName).Fail(message, media);
                    break;
            }
        }
        #endregion
    }
}
   