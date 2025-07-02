using Automation_Framework_Reqnroll_Nunit.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.Pages
{
    public class MenuBarPage
    {
        public static Boolean CheckOnTheStatusOfMenuBar_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//i[@class='fa fa-bars']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void ClickOnTheMenuBarOption_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//i[@class='fa fa-bars']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckOnTheStatusOfCreateOrderButton_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Create Order']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void ClickOnCreateOrderButton_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Create Order']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckOnTheStatusOfOrderQueueOptionButton_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Order Queue']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void ClickOnOrderQueueButton_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Order Queue']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckOnTheStateOfMessageOption_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Messages']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void ClickOnMessageOptionButton_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Order Queue']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckOnTheStateOfAdministratorOption_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Administrator']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void ClickOnAdministratorOptionButton_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Administrator']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckOnTheStateOfLogoutOptionButton_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Messages']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void ClickOnLogoutOptionButton_MenuBarPage(IWebDriver driver)
        {
            string Xpath = "//p[normalize-space(text())='Logout']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckTheStatusOfOrderQueueHeading_FromMenuBarPage(IWebDriver driver)
        {
            string Xpath = "//span[normalize-space(text())='Order Queue']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
    }
}
