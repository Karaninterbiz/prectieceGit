using Automation_Framework_Reqnroll_Nunit.Pages;
using Automation_Framework_Reqnroll_Nunit.Utility;
using FluentAssertions;
using OpenQA.Selenium;
using Reqnroll;
using System;

namespace Automation_Framework_Reqnroll_Nunit.StepDefinitions
{
    [Binding]
    public class ForgotPasswordInvalidDataFunctionalityStepDefinitions
    {
        #region 1. Initialization & Constructor

        private readonly IWebDriver _driver;

        public ForgotPasswordInvalidDataFunctionalityStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion

        #region TC 02. Blank Email
        [When("the user leaves the email field blank (.*)")]
        public void WhenTheUserLeavesTheEmailFieldBlank(string Email)
        {
            string userRole = Email.ToLower().Trim();
            var cancelButton = ForgotPasswordPage.CancelButton_fromForgotPasswordPage(_driver);
            cancelButton.Displayed.Should().BeTrue();
            cancelButton.Enabled.Should().BeTrue();
            cancelButton.Text.Should().Be("CANCEL");
            var emailMeta = ForgotPasswordPage.CheckTheStatusOfEmailFieldMeta_ForgotPasswordPage(_driver);
            emailMeta["Label"].Should().Be("Email Address");
            emailMeta["Placeholder"].Should().Be("Email Address");
            if (userRole.Contains("emptyemail"))
            {
                ForgotPasswordPage.EnterEmailOnForgotPasswordPage(_driver, CommonSteps.GetForgotCredential("EmptyEmail"));
            }
        }

        [Then("the system should show a relevant error message to the user")]
        public void ThenTheSystemShouldShowARelevantErrorMessageToTheUser()
        {
            var errorMessage = ForgotPasswordPage.CheckTheVerificationErrortext_ChangePasswordPage(_driver);
            errorMessage.Should().NotBeNullOrEmpty("because a relevant error message must be displayed");
        }
        #endregion

        #region TC 03. Invalid Email
        [When("the user enters an invalid email (.*) in the email field")]
        public void WhenTheUserEntersAnInvalidEmailInvalidEmailInTheEmailField(string InvalidEmail)
        {
            var cancelButton = ForgotPasswordPage.CancelButton_fromForgotPasswordPage(_driver);
            cancelButton.Displayed.Should().BeTrue();
            cancelButton.Enabled.Should().BeTrue();
            cancelButton.Text.Should().Be("CANCEL");
            var emailMeta = ForgotPasswordPage.CheckTheStatusOfEmailFieldMeta_ForgotPasswordPage(_driver);
            emailMeta["Label"].Should().Be("Email Address");
            emailMeta["Placeholder"].Should().Be("Email Address");
            ForgotPasswordPage.EnterEmailOnForgotPasswordPage(_driver, InvalidEmail);
        }
        [Then("the system should show a relevant error message to the user on the display")]
        public void ThenTheSystemShouldShowARelevantErrorMessageToTheUserOnTheDisplay()
        {
            var errorMessage = ForgotPasswordPage.CheckTheVerificationErrortext_ChangePasswordPage(_driver);
            errorMessage.Should().NotBeNullOrEmpty("because a validation error message should be displayed");
        }

        #endregion

        #region TC 04. incorrect verification code
        
        [Then("the user enters the Incorrect OTP and clicks on the Verify Codebutton")]
        public void ThenTheUserEntersTheIncorrectOTPAndClicksOnTheVerifyCodebutton()
        {
            var fieldMeta = ForgotPasswordPage.CheckOnTheVerificationCodeFieldMeta_ForgotPasswordPage(_driver);
            fieldMeta["Label"].Should().Be("Verification code");
            fieldMeta["Placeholder"].Should().Be("Verification code");            
            Thread.Sleep(20000);
            var verifyCodeButton = ForgotPasswordPage.VerifyCodeButton_FromForgotPasswordPage(_driver);
            verifyCodeButton.Displayed.Should().BeTrue();
            verifyCodeButton.Enabled.Should().BeTrue();
            verifyCodeButton.Text.Trim().Should().Be("Verification code");
            ForgotPasswordPage.ClickOnTheVerifyCodeButton_ForgotPasswordPage(_driver);
        }
        [Then("the system should display an error message")]
        public void ThenTheSystemShouldDisplayAnErrorMessage()
        {
            var errorMessage = ForgotPasswordPage.CheckTheVerificationErrortext_ChangePasswordPage(_driver);
            errorMessage.Should().NotBeNullOrEmpty("because at least one error message should be shown for incorrect verification code");

        }

        #endregion

        #region TC 05. password mismatch error
        [Then("the system should display an error message Passwords do not match")]
        public void ThenTheSystemShouldDisplayAnErrorMessagePasswordsDoNotMatch()
        {
            var errorMessage = ForgotPasswordPage.CheckTheVerificationPasswordError_FromForgotPasswordPage(_driver);
            errorMessage.Should().NotBeNullOrEmpty("because an error message must appear for mismatched passwords");
        }
        #endregion
    }
}
