// --------------------------------------------------------------------------------------------------------------------
//  Author      : Rishabh Vishwakarma
//  File        : CommonStepDefination.cs
//  Description : Contains reusable step definitions for common user interactions in DMEScripts,
//                such as login functionality across different user roles.
//  Purpose     : Maps feature file steps to Selenium WebDriver actions using SpecFlow, enabling
//                behavior-driven testing for core login workflows in the test suite.
//                Supports dynamic role-based login with credential resolution via test utilities.
// --------------------------------------------------------------------------------------------------------------------

using Automation_Framework_Reqnroll_Nunit.Pages;
using Automation_Framework_Reqnroll_Nunit.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.StepDefinitions
{
    [Binding]
    public class CommonStepDefination
    {
        #region 1. Initialization & Constructor

        private readonly IWebDriver _driver;

        /// <summary>
        /// Constructor for the step definition class.
        /// Injects the WebDriver instance via SpecFlow's dependency injection mechanism,
        /// enabling browser interactions for the login functionality scenarios.
        /// </summary>
        /// <param name="driver">The WebDriver instance injected from the test context</param>
        public CommonStepDefination(IWebDriver driver)
        {
            _driver = driver;
        }

        #endregion

        #region 2. Step Definitions
        /// <summary>
        /// Logs into DMEScripts as the specified user role.
        /// Valid roles: supportadmin, providerorganization, supplierorganization
        /// </summary>
        /// <param name="User">The user role to log in as (e.g., SupportAdmin)</param>


        [When("Login To DMEScripts and (.*) enter the email and password (.*)")]
        public void WhenLoginToDMEScriptsAndSupportadminEnterTheEmailAndSuperadminpassword(string User, string Password)
        {
            string userRole = User.ToLower().Trim();
            string passwordRole = Password.ToLower().Trim();
            if (userRole.Contains("supportadmin") && passwordRole.Contains("supportadminpassword"))
            {
                LoginPage.EnterEmailOnLoginPage(_driver, CommonSteps.GetCredential("SupportAdmin"));
                LoginPage.EnterPasswordOnLoginPage(_driver, CommonSteps.GetCredential("SupportAdminPassword"));
            }
            else if (userRole.Contains("providerorganization") && passwordRole.Contains("password"))
            {
                LoginPage.EnterEmailOnLoginPage(_driver, CommonSteps.GetCredential("ProviderOrganization"));
                LoginPage.EnterPasswordOnLoginPage(_driver, CommonSteps.GetCredential("Password"));
            }
            else if (userRole.ToLower().Contains("providerprescriber") && passwordRole.Contains("password"))
            {
                LoginPage.EnterEmailOnLoginPage(_driver, CommonSteps.GetCredential("ProviderPrescriber"));
                LoginPage.EnterPasswordOnLoginPage(_driver, CommonSteps.GetCredential("Password"));
            }
            else if (userRole.ToLower().Contains("providercareteammember") && passwordRole.Contains("password"))
            {
                LoginPage.EnterEmailOnLoginPage(_driver, CommonSteps.GetCredential("ProviderCareTeamMember"));
                LoginPage.EnterPasswordOnLoginPage(_driver, CommonSteps.GetCredential("Password"));
            }
            else if (userRole.Contains("supplierorganization") && passwordRole.Contains("password"))
            {
                LoginPage.EnterEmailOnLoginPage(_driver, CommonSteps.GetCredential("SupplierOrganization"));
                LoginPage.EnterPasswordOnLoginPage(_driver, CommonSteps.GetCredential("Password"));
            }
            else if (userRole.Contains("supplierteammember") && passwordRole.Contains("password"))
            {
                LoginPage.EnterEmailOnLoginPage(_driver, CommonSteps.GetCredential("SupplierTeamMember"));
                LoginPage.EnterPasswordOnLoginPage(_driver, CommonSteps.GetCredential("Password"));
            }
            else if (userRole.Contains("supplierteammemberreadonly") && passwordRole.Contains("password"))
            {
                LoginPage.EnterEmailOnLoginPage(_driver, CommonSteps.GetCredential("SupplierTeamMemberReadOnly"));
                LoginPage.EnterPasswordOnLoginPage(_driver, CommonSteps.GetCredential("Password"));
            }
            else
            {
                throw new ArgumentException($"Invalid User Type: '{User}' is not recognized. Allowed: supportadmin, providerorganization, providerprescriber, providercareteammember, supplierorganization, supplierteammember, supplierteammemberreadonly.");
            }

        }


        #endregion

    }
}
