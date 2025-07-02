// --------------------------------------------------------------------------------------------------------------------
//  Author      : Rishabh Vishwakarma
//  File        : CommonSteps.cs
//  Description : Utility class providing common reusable methods for test execution, such as retrieving
//                credentials and managing shared test context.
//  Purpose     : 
//     - Injects WebDriver and ScenarioContext using SpecFlow’s DI mechanism.
//     - Exposes static method to fetch role-based credentials from JSON configuration.
//     - Acts as a base utility for role-specific authentication and shared test data needs.
// --------------------------------------------------------------------------------------------------------------------


using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.Utility
{
    public class CommonSteps : BaseClass
    {
        #region 1. Fields and Constructor

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        /// <summary>
        /// Constructor injecting WebDriver and ScenarioContext via SpecFlow's DI container.
        /// </summary>
        public CommonSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        #endregion

        #region 2. Role-Based Credential Retrieval

        /// <summary>
        /// Retrieves a value (such as username or password) from the role-based credential JSON file.
        /// </summary>
        /// <param name="profileName">The key/token in the JSON representing the credential</param>
        /// <returns>Credential value as a string</returns>
        public static string GetCredential(string profileName)
        {
            return GetDataParser().TestData(profileName, "TestData/RoleCredentials.json");
        }

        #endregion

        #region 3. Role-Based ForgotPassword Credential
        public static string GetForgotCredential(string profileName)
        {
            return GetDataParser().TestData(profileName, "TestData/ForgotPassword.json");
        }
        #endregion

    }
}
