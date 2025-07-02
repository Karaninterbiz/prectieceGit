// --------------------------------------------------------------------------------------------------------------------
//  Author      : Rishabh Vishwakarma
//  File        : Hooks.cs
//  Description : Defines SpecFlow hooks for managing the test lifecycle including setup, teardown,
//                WebDriver initialization, and ExtentReport logging.
//  Purpose     : 
//     - Initializes ExtentReports before test execution.
//     - Handles browser launch and registration before each scenario.
//     - Captures screenshots and logs step status (Pass/Fail) in ExtentReports.
//     - Ensures clean browser teardown and report finalization after tests.
// --------------------------------------------------------------------------------------------------------------------


using Automation_Framework_Reqnroll_Nunit.Utility;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using Reqnroll.BoDi;

namespace Automation_Framework_Reqnroll_Nunit.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        #region 1. Fields and Constructor

        // Holds the path to the JSON file containing login credentials
        public static string LoginCredintial_Path;

        // Holds the URL of the application under test, read from JSON at runtime
        public static string TestUrl;

        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _container;

        /// <summary>
        /// Constructor injecting ScenarioContext and DI container for WebDriver registration.
        /// </summary>
        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }

        #endregion

        #region 2. Before Test Run

        /// <summary>
        /// Called once before the entire test suite starts.
        /// Initializes ExtentReports and loads application URL from JSON file.
        /// </summary>
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            InitializeReport();
            Console.WriteLine(">> [BeforeTestRun] Report initialized");

            try
            {
                // Read the target application URL from test data
                TestUrl = GetDataParser().TestData("Test_Url", "TestData/TestUrl.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Hooks ERROR - TestData] {ex.Message}");
                throw;
            }
        }

        #endregion

        #region 3. Before Feature

        /// <summary>
        /// Called before each feature. Creates a feature-level node in ExtentReports.
        /// </summary>
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            FeatureNode = ExtentReportsInstance.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        #endregion

        #region 4. Before Scenario

        /// <summary>
        /// Called before each scenario. Launches the browser and initializes scenario-level reporting.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                var baseInstance = new BaseClass();
                var driver = baseInstance.BrowserLaunch(TestUrl,"chrome");

                // Register the driver in the SpecFlow DI container
                _container.RegisterInstanceAs(driver);

                // Create scenario node in the report
                ScenarioNode = FeatureNode.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
                _scenarioContext["scenario"] = ScenarioNode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Hooks ERROR - Browser Launch] {ex.Message}");
                throw;
            }
        }

        #endregion

        #region 5. After Step

        /// <summary>
        /// Executed after each test step. Captures the step result (pass/fail), logs it to the ExtentReport,
        /// and attaches a screenshot for visual traceability.
        /// </summary>
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine(">> [AfterStep] Logging step result...");

            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
            string filename = $"Screenshot_{stepType}_{timestamp}.png";

            var driver = _container.Resolve<IWebDriver>();
            var media = CaptureScreenshot(driver, filename);

            if (scenarioContext.TestError == null)
            {
                // Step passed
                LogStep(stepType, stepName, true, stepName, media);
            }
            else
            {
                // Step failed
                LogStep(stepType, stepName, false, scenarioContext.TestError.Message, media);
            }
        }

        #endregion

        #region 6. After Scenario

        /// <summary>
        /// Executed after each scenario. Ensures the WebDriver instance is safely closed to prevent resource leakage.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                var driver = _container.Resolve<IWebDriver>();
                driver?.Quit();
                Console.WriteLine(">> [AfterScenario] Browser closed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AfterScenario ERROR] Failed to close browser: {ex.Message}");
            }
        }

        #endregion

        #region 7. After Test Run

        /// <summary>
        /// Called once after all scenarios have finished. Flushes the ExtentReport.
        /// </summary>
        [AfterTestRun]
        public static void AfterTestRun()
        {
            FinalizeReport();
            Console.WriteLine(">> [AfterTestRun] Report finalized");
        }

        #endregion
    }
}
