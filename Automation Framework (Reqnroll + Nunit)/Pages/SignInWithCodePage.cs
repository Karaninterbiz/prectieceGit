using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.Pages
{
    public class SignInWithCodePage
    {      
        public static IWebElement CheckOnTheSignInWithACodeButtonLink_SignInWithCodePage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::a[normalize-space(text())='Sign in with a code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnSignInWithACodeButton_SignInWithCodePage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Sign In to DMEScripts']/following::a[normalize-space(text())='Sign in with a code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement CheckOnTheVerificationLabel_SignInWithCodePage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Verification']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static Dictionary<string,string> CheckTheStatusOFEmailField_SignInWithCodePage(IWebDriver driver)
        {
            string emailPlaceHolder = "//h3[normalize-space(text())='Verification']/following::input[@id='email-label']";
            string emailLabel = "//h3[normalize-space(text())='Verification']/following::label[normalize-space(text())='Enter email']";
            var result = new Dictionary<string, string>();
            result["Label"] = driver.FindElement(By.XPath(emailLabel)).Text;
            result["Placeholder"] = driver.FindElement(By.XPath(emailPlaceHolder)).GetAttribute("placeholder");

            return result;
        }
        public static void EnterEmailOnSignInWithCodePage(IWebDriver driver,string Email)
        {
            string Xpath = "//h3[normalize-space(text())='Verification']/following::label[normalize-space(text())='Enter email']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(Email.Trim());
        }
        public static IList<string> CheckTheErrorMessages_SingInWithCodePage(IWebDriver driver)
        {
            string Xpath = "//div[contains(text(),'Email is') or contains(text(),'Please enter a valid')]";
            var ErrorsMessage = driver.FindElements(By.XPath(Xpath));
            IList<string> errorMessages = new List<string>();

            foreach(var error in ErrorsMessage)
            {
                if (error.Displayed && !string.IsNullOrWhiteSpace(error.Text))
                {
                    errorMessages.Add(error.Text.Trim());
                }
            }
            return errorMessages;
        }
        public static IWebElement CheckTheStatucOfGenerateCodeButton(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Verification']/following::button[normalize-space(text())='Generate Code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
       

    }
}
