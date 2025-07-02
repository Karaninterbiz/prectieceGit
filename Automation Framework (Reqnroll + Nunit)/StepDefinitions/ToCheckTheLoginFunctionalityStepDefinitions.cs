// --------------------------------------------------------------------------------------------------------------------
//  Author      : Rishabh Vishwakarma
//  File        : ToCheckTheLoginFunctionalityStepDefinitions.cs
//  Description : Defines step definitions for validating login functionality across the DMEScripts platform.
//                Integrates with Selenium WebDriver to automate browser interactions.
//  Purpose     : Maps Gherkin feature steps to executable test logic using SpecFlow, ensuring role-based
//                login scenarios are tested accurately with injected WebDriver instances.
//                This serves as a dedicated step definition class for login-related BDD test scenarios.
// --------------------------------------------------------------------------------------------------------------------


using Automation_Framework_Reqnroll_Nunit.Pages;
using Automation_Framework_Reqnroll_Nunit.Utility;
using AventStack.ExtentReports;
using FluentAssertions;
using OpenQA.Selenium;
using Reqnroll;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Automation_Framework_Reqnroll_Nunit.StepDefinitions
{
    [Binding]
    public class ToCheckTheLoginFunctionalityStepDefinitions
    {
        #region 1. Initialization & Constructor

        private readonly IWebDriver _driver;

        public ToCheckTheLoginFunctionalityStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
        }

        #endregion

        #region 2. Step Definitions 

        [Given("the user is on the login page and check the DME logo is visible")]
        public void GivenTheUserIsOnTheLoginPageAndCheckTheDMELogoIsVisible()
        {
            var isLogoVisible = LoginPage.CheckOnTheDMELogo_FromLoginPage(_driver);
            isLogoVisible.Should().BeTrue("because the DME logo should be visible on the login page");
            var title = LoginPage.CheckTheDMETitle_FromLoginPage(_driver);
            Console.WriteLine(title);
            title.Should().Be("DMEScripts");
        }

        [When("the user validates the placeholder text for email and password fields")]
        public void WhenTheUserValidatesThePlaceholderTextForEmailAndPasswordFields()
        {
            string actualEmailPlaceholder = LoginPage.CheckOnTheEmailPlaceHolder(_driver);
            string actualPasswordPlaceholder = LoginPage.CheckOnThePasswordPlaceHolder(_driver);

            actualEmailPlaceholder.Should().Be("Email Address","because the email input should display the expected placeholder text");

            actualPasswordPlaceholder.Should().Be("Password","because the password input should display the expected placeholder text");
        }
      
        [Given("Login To DMEScripts (.*) enter the email and enter the password (.*)")]
        public void GivenLoginToDMEScriptsEnterTheEmailAndEnterThePassword(string Email, string Passwordd)
        {
            LoginPage.EnterEmailOnLoginPage(_driver, Email);
            LoginPage.EnterPasswordOnLoginPage(_driver, Passwordd);
        }

        [Given("clicks on the Sign In button")]
        public void GivenClicksOnTheSignInButton()
        {
            LoginPage.ClickOnSignInButton_LoginPage(_driver);
        }


        [When("clicks on the Sign In button")]
        public void WhenClicksOnTheSignInButton()
        {
            LoginPage.ClickOnSignInButton_LoginPage(_driver);
        }

        [Then("the user should not see any error messages")]
        public void ThenTheUserShouldNotSeeAnyErrorMessages()
        {
           var errorMessage = LoginPage.CheckTheAllErrorMessages_FromLoginPage(_driver);
            errorMessage.Should().BeNullOrEmpty("because no error should appear on valid login");
        }

        [Then("the user should be successfully redirected to the DME Home page")]
        public void ThenTheUserShouldBeSuccessfullyRedirectedToTheDMEHomePage()
        {
            var IsOrderQueue = MenuBarPage.CheckTheStatusOfOrderQueueHeading_FromMenuBarPage(_driver);
            IsOrderQueue.Should().BeTrue("because the Order Queue heading should be visible on the DME Home page after a successful login or redirect");
        }

        [Then("error messages should be displayed on the Login Page")]
        public void ThenErrorMessagesShouldBeDisplayedOnTheLoginPage()
        {
            var errorMessages = LoginPage.CheckTheAllErrorMessages_FromLoginPage(_driver);
            errorMessages.Should().NotBeNullOrEmpty("because invalid login should show at least one error");
        }

        #endregion


    }
}
