using Automation_Framework_Reqnroll_Nunit.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.Pages
{
    public class LoginPage
    {
        public static string CheckTheDMETitle_FromLoginPage(IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.TitleContains("DME"));

                string pageTitle = driver.Title;
                return pageTitle;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting page title: " + ex.Message);
                return string.Empty;
            }
        }
        public static Boolean CheckOnTheDMELogo_FromLoginPage(IWebDriver driver)
        {
            string Xpath = "//img[@alt='DMEScripts']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static string CheckOnTheDMELabel_FromLoginPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static void EnterEmailOnLoginPage(IWebDriver driver, string Email)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::input[@id='signInName']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(Email.Trim());
        }
        public static string CheckOnTheEmailPlaceHolder(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::input[@id='signInName']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("placeholder").Trim();
        }
        public static void EnterPasswordOnLoginPage(IWebDriver driver, string password)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::input[@id='password']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(password.Trim());
        }
        public static string CheckOnThePasswordPlaceHolder(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::input[@id='password']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("placeholder").Trim();
        }
        public static void ClickOnSignInButton_LoginPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::button[normalize-space(text())='Sign in']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static string CheckOnSignInButtonText_LoginPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::button[normalize-space(text())='Sign in']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;

        }
        public static IList<string> CheckTheAllErrorMessages_FromLoginPage(IWebDriver driver)
        {
            Thread.Sleep(3000);
            string Xpath = "//p[contains(text(),'enter your') or contains(text(),'find your') or contains(text(),'is incorrect') or contains(text(),'required')] | //h1[contains(text(),'sign you in')]";
            var elements = driver.FindElements(By.XPath(Xpath));
            IList<string> errors = new List<string>();

            foreach (var element in elements)
            {
                if (element.Displayed && !string.IsNullOrWhiteSpace(element.Text))
                {
                    errors.Add(element.Text.Trim());
                }
            }
            return errors;
        }
        public static IWebElement CheckOnTheSignInWithACodeButtonLink_SignInWithCodePage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::a[normalize-space(text())='Sign in with a code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CheckOnTheStatusOfForgotPasswordLink_FromLoginPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::a[normalize-space(text())='Forgot your password?']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CheckOnTheStatusOfSignUpNowLink_FromLoginPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::a[normalize-space(text())='Sign up now']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }

    }
}
