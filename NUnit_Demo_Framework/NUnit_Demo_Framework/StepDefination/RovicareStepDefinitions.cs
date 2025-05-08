using System;
using NUnit_Demo_Framework.Hooks_BDD;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using System.Net.Mail;

namespace NUnit_Demo_Framework.StepDefination
{
    [Binding]
    public class RovicareStepDefinitions : Hooks
    {
        ArrayList _list = new ArrayList();

        private WebDriverWait _wait = new WebDriverWait(_driver.Value, TimeSpan.FromSeconds(30));

        [Given("User opens the Chrome browser")]
        public void GivenUserOpensTheChromeBrowser()
        {
            try
            {
                _driver.Value.Navigate().GoToUrl("https://test.rovicare.com/");
                _test.Value.Log(Status.Info, "User Navigate to the Chrome Browser");
            }
            catch (Exception ex)
            {
                _test.Value.Log(Status.Fail, "Failed to open Chrome browser: " + ex.Message);
            }
        }

        [Given("User enters valid credentials")]
        public void GivenUserEntersValidCredentials()
        {
            try
            {
                IWebElement _emailField = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[normalize-space(text())='Email Address']/following::input[@id='signInName']")));
                _emailField.SendKeys("hospital@rovicare.com");
                _test.Value.Log(Status.Pass, $"user Enther the Valid Email Id");

                IWebElement _password = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[normalize-space(text())='Password']/following::input[@id='password']")));
                _password.SendKeys("RoviPass@321");
                _test.Value.Log(Status.Pass, $"user Enther the Valid Password");
            }
            catch (Exception ex)
            {
                _test.Value.Log(Status.Fail, "Failed to enter valid credentials: " + ex.Message);
            }
        }

        [When("User clicks the Sign In button")]
        public void WhenUserClicksTheSignInButton()
        {
            try
            {
                IWebElement _signInButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(" //label[normalize-space(text())='Password']/following::button[@id='next']")));
                _signInButton.Click();
                _test.Value.Log(Status.Info, "user click the sign in button");
                Thread.Sleep(15000);
            }
            catch (Exception ex)
            {
                _test.Value.Log(Status.Fail, "Failed to click Sign In button: " + ex.Message);
            }
        }
       
        [Then("User should navigate to the home page")]
        public void ThenUserShouldNavigateToTheHomePage()
        {
            try
            {
                var GetText = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Incoming']"))).Text;
                Console.WriteLine($"Home Page : {GetText}");
                _test.Value.Log(Status.Pass, $"Navigated to Home Page successfully. Found text: {GetText}");
                Thread.Sleep(2000);
                _driver.Value.FindElement(By.XPath("//li[@class='menuContainer'][9]")).Click();
            }
            catch (Exception ex)
            {
                _test.Value.Log(Status.Fail, "Failed to validate Home Page: " + ex.Message);
            }
        }
        
        [Given("User enters invalid credentials (.*) and (.*)")]
        public void GivenUserEntersInvalidCredentialsAnd(string EmailAddress, string Password)
        {
            try
            {
                IWebElement _emailField = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[normalize-space(text())='Email Address']/following::input[@id='signInName']")));
                _emailField.SendKeys(EmailAddress);
                _test.Value.Log(Status.Info, $"user Enther the Invalid Email : {EmailAddress}");

                IWebElement _password = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[normalize-space(text())='Password']/following::input[@id='password']")));
                _password.SendKeys(Password);
                _test.Value.Log(Status.Info, $"user Enther the Invalid Password : {Password}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                _test.Value.Log(Status.Fail, $"Error while entering invalid credentials: {ex.Message}");
                Console.WriteLine("Exception in entering credentials: " + ex.Message);
            }
        }

        [Then("Error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            _test.Value.Log(Status.Info, "Attempting to click Sign In button with invalid credentials.");
            try
            {
                IWebElement _signInButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(" //label[normalize-space(text())='Password']/following::button[@id='next']")));
                _signInButton.Click();
                _test.Value.Log(Status.Pass, "Sign In button clicked successfully.");
            }
            catch (Exception ex)
            {
                _test.Value.Log(Status.Fail, $"Sign In button could not be clicked: {ex.Message}");
                Console.WriteLine("Exception while clicking Sign In button: " + ex.Message);
            }
            try
            {
                var _emailField = _driver.Value.FindElement(By.XPath("//p[text()='Please enter your Email Address']")).Text;
                if (_emailField != null)
                {
                    _test.Value.Log(Status.Fail, $"Error displayed: {_emailField}");
                    Console.WriteLine($"Error : {_emailField}");
                }
            }
            catch(Exception ex)
            {
                _test.Value.Log(Status.Info, "Email field error message not displayed.");
            }
            try
            {
                var _password = _driver.Value.FindElement(By.XPath("//p[text()='Please enter your password']")).Text;
                if (_password != null)
                {
                    _test.Value.Log(Status.Fail, $"Error displayed: {_password}");
                    Console.WriteLine($"Error : {_password}");
                }
            }
            catch (Exception ex)
            {
                _test.Value.Log(Status.Info, "Password field error message not displayed.");
            }
            try
            {
                var _errorMessage = _driver.Value.FindElement(By.XPath("//p[normalize-space(text())=\"We can't seem to find your account.\"]")).Text;
                if (_errorMessage != null)
                {
                    _test.Value.Log(Status.Fail, $"Error displayed: {_errorMessage}");
                    Console.WriteLine($"Error : {_errorMessage}");
                }
            }
            catch (Exception ex)
            {
                _test.Value.Log(Status.Info, "General error message not displayed.");
            }
            
        }
    }
}
