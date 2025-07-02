using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Automation_Framework_Reqnroll_Nunit.Pages
{
    public class ForgotPasswordPage
    {
        public static IWebElement CheckOnTheStatusOfForgotPasswordLink_FromLoginPage(IWebDriver driver)
        {            
            string Xpath = "//label[normalize-space(text())='Password']/following::a[@id='forgotPassword']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnForgotPasswordLink_FromLoginPage(IWebDriver driver)
        {
            string Xpath = "//label[normalize-space(text())='Password']/following::a[@id='forgotPassword']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement link = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();",link);
        }
        public static System.Boolean CheckOnTheStatusOfRoviCareLogo_ForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "(//img[@alt='RoviCare'])[2]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static IWebElement CheckTheChangePasswordHeading_ForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static Dictionary<string, string> CheckTheStatusOfEmailFieldMeta_ForgotPasswordPage(IWebDriver driver)
        {
            var result = new Dictionary<string, string>();

            string labelXpath = "//h3[normalize-space(text())='Change password']/following::label[@id='email_label']";
            string inputXpath = "//h3[normalize-space(text())='Change password']/following::input[@id='email']";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(labelXpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(inputXpath)));

            result["Label"] = driver.FindElement(By.XPath(labelXpath)).Text.Trim();
            result["Placeholder"] = driver.FindElement(By.XPath(inputXpath)).GetAttribute("placeholder").Trim();

            return result;
        }
        public static void EnterEmailOnForgotPasswordPage(IWebDriver driver, string Email)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::input[@id='email']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(Email.Trim());
        }
        public static IWebElement CheckTheSendVerificationCodeButton_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::button[normalize-space(text())='Send verification code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnTheSendVerificationCodeButton_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::button[normalize-space(text())='Send verification code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement ContinueButton_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::button[normalize-space(text())='Continue']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CancelButton_fromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::button[normalize-space(text())='Cancel']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static Dictionary<string, string> CheckOnTheVerificationCodeFieldMeta_ForgotPasswordPage(IWebDriver driver)
        {
            var result = new Dictionary<string, string>();

            string labelXpath = "//h3[normalize-space(text())='Change password']/following::label[normalize-space(text())='Verification code']";
            string inputXpath = "//h3[normalize-space(text())='Change password']/following::input[@id='email_ver_input']";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(labelXpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(inputXpath)));

            result["Label"] = driver.FindElement(By.XPath(labelXpath)).Text.Trim();
            result["Placeholder"] = driver.FindElement(By.XPath(inputXpath)).GetAttribute("placeholder").Trim();

            return result;
        }     
        public static void ClickOnTheVerifyCodeButton_ForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::button[normalize-space(text())='Verify code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IList<string> CheckTheVerificationInfoText_ChangePasswordPage(IWebDriver driver)
        {
            string Xpath = "//div[contains(text(),'Verification') or contains(text(),'address verified')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            var infoMessage = driver.FindElements(By.XPath(Xpath));
            IList<string> info = new List<string>();

            foreach (var message in infoMessage)
            {
                if (message.Displayed && !string.IsNullOrWhiteSpace(message.Text))
                {
                    info.Add(message.Text.Trim());
                }
            }
            return info;
        }
        public static IList<string> CheckTheVerificationErrortext_ChangePasswordPage(IWebDriver driver)
        {
            string Xpath = "//div[contains(@class,'error') or contains(@id,'error')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            var element = driver.FindElements(By.XPath(Xpath));
            IList<string> error = new List<string>();

            foreach (var message in element)
            {
                if (message.Displayed && !string.IsNullOrWhiteSpace(message.Text))
                {
                    error.Add(message.Text.Trim());
                }
            }
            return error;
        }
        public static IWebElement VerifyCodeButton_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::label[normalize-space(text())='Verification code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement SendNewCodeButton_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::button[normalize-space(text())='Send new code']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CheckTheNewPasswordLabel_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::label[normalize-space(text())='New Password']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static string CheckTheNewPasswordPlaceHolder_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::input[@id='newPassword']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("placeholder").Trim();
        }
        public static IWebElement CheckTheConfirmNewPasswordLabel_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::label[normalize-space(text())='Confirm New Password']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static string CheckTheConfirmNewPasswordPlaceHolder_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::input[@id='reenterPassword']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("placeholder").Trim();
        }
        public static void ClickOnTheContinueButtonButton_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::button[normalize-space(text())='Continue']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void EnterNewPasswordOnForgotPasswordPage(IWebDriver driver,string newPassword)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::input[@id='newPassword']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(newPassword.Trim());
        }
        public static void EnterConfirmNewPasswordOnForgotPasswordPage(IWebDriver driver, string confirmNewPassword)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::input[@id='reenterPassword']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(confirmNewPassword.Trim());
        }
        public static IList<string> CheckTheVerificationPasswordError_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//div[contains(text(),'and try again')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            var infoMessage = driver.FindElements(By.XPath(Xpath));
            IList<string> info = new List<string>();

            foreach (var message in infoMessage)
            {
                if (message.Displayed && !string.IsNullOrWhiteSpace(message.Text))
                {
                    info.Add(message.Text.Trim());
                }
            }
            return info;
        }
        public static IList<string> CheckTheFieldErrorInConfirmPasswordPage_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//div[@class='error itemLevel show']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            var infoMessage = driver.FindElements(By.XPath(Xpath));
            IList<string> info = new List<string>();

            foreach (var message in infoMessage)
            {
                if (message.Displayed && !string.IsNullOrWhiteSpace(message.Text))
                {
                    info.Add(message.Text.Trim());
                }
            }
            return info;
        }
        public static IWebElement CheckOnTheStatusOfTermsOfUseRoviCareAcceptButton(IWebDriver driver)
        {
            string Xpath = "//button[normalize-space(text())='I Accept']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnTheTermsOfUseRoviCareAcceptButton(IWebDriver driver)
        {
            string Xpath = "//button[normalize-space(text())='I Accept']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement CheckTheStatusOfChangeEmailButton_FromForgotPasswordPage(IWebDriver driver)
        {
            string Xpath = "//h3[normalize-space(text())='Change password']/following::input[@id='reenterPassword']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }

    }

}
