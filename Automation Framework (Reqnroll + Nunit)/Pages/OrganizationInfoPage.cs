using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.Pages
{
    public class OrganizationInfoPage
    {
        public static IWebElement CheckTheStatusOfGoBackButton_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//span[@class='app-go-back-button']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnTheGoBackButton_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//span[@class='app-go-back-button']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement CheckTheStatusOfAdministarationLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//span[normalize-space(text())='Administration']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CheckTheStatusOfOrganizationInfoLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//span[normalize-space(text())='Organization Info']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CheckTheStatusOfOrganizationInfoHeaderLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//span[normalize-space(text())='Organization Info']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CheckTheStatusOfBasicDetailsMatLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//div[contains(text(),'Organization Info')]/following::mat-card-title[normalize-space(text())='Basic Details']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }

        #region 1. Company Type List
        public static string CheckTheDefaultSelectedFromCompanyType_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-select[@name='companyType']//span[contains(@class,'mat-mdc-select-min-line')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text.Trim();
        }
        public static string CheckTheCompanyTypeNameLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='Company Type']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static void ClickOnTheCompanyTypeDropDown_OrganizationInfopage(IWebDriver driver)
        {
            string clickDropdown = "//mat-select[@id='mat-select-4']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(clickDropdown)));
            driver.FindElement(By.XPath(clickDropdown)).Click();
        }
        public static IList<string> GetAllOptionsFromCompanyTypeDropDown_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-option//span[contains(@class,'mdc-list')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            var allOptions = driver.FindElements(By.XPath(Xpath));
            IList<string> optionTexts = new List<string>();

            foreach (var option in allOptions)
            {
                optionTexts.Add(option.Text.Trim());
            }

            return optionTexts;
        }        
        public static void ClickOnTheOptionFromCompanyTypeDropDown_OrganizationInfopage(IWebDriver driver,string companyType)
        {
            string Xpath = "//mat-option//span[contains(@class,'mdc-list')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            var allOptions = driver.FindElements(By.XPath(Xpath));
            var targetOption = allOptions.First(value => value.Text.Contains(companyType));
            targetOption.Click();
        }                
        #endregion

        //Organization Name
        public static string CheckTheOrganizationNameLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='Name']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static string CheckTheDefaultSelectedOrganizationName_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='Name']/following::input[@id='mat-input-0']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("value");
        }
        public static void EnterOrganizationName_OrganizationInfopage(IWebDriver driver, string OrganizationName)
        {
            string Xpath = "//mat-label[normalize-space(text())='Name']/following::input[@id='mat-input-0']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(OrganizationName.Trim());
        }

        //Organization Legal Name
        public static string CheckTheOrganizationLegalNameLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='Legal Name']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static string CheckTheDefaultSelectedOrganizationLegalName_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='Legal Name']/following::input[@id='mat-input-9']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("value");
        }
        public static void EnterOrganizationLegalName_OrganizationInfopage(IWebDriver driver, string OrganizationLegalName)
        {
            string Xpath = "//mat-label[normalize-space(text())='Legal Name']/following::input[@id='mat-input-9']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(OrganizationLegalName.Trim());
        }

        #region 2. State Of Incorporation
        public static string CheckTheStateOfInCorporationLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='State of Incorporation']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static void ClickOnTheStateOfInCorporationDropDown_OrganizationInfopage(IWebDriver driver)
        {
            string clickDropdown = "//mat-select[@id='mat-select-0']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(clickDropdown)));
            driver.FindElement(By.XPath(clickDropdown)).Click();
        }
        public static IList<string> GetAllOptionsFromStateOfInCorporationDropDown_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//div[@id='cdk-overlay-1']//mat-option";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            var allOptions = driver.FindElements(By.XPath(Xpath));
            IList<string> optionTexts = new List<string>();

            foreach (var option in allOptions)
            {
                optionTexts.Add(option.Text.Trim());
            }

            return optionTexts;
        }
        public static void ClickOnTheOptionStateOfInCorporationDropDown_OrganizationInfopage(IWebDriver driver, string incorporation)
        {
            string Xpath = "//div[@id='cdk-overlay-1']//mat-option";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            var allOptions = driver.FindElements(By.XPath(Xpath));
            var targetOption = allOptions.First(value => value.Text.Contains(incorporation));
            targetOption.Click();
        }
        #endregion

        //Website
        public static string CheckTheWebsiteLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='Website']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static string CheckTheDefaultSelectedWebsiteName_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='Website']/following::input[@id='mat-input-10']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("value");
        }
        public static void EnterWeisiteName_OrganizationInfopage(IWebDriver driver,string websiteName)
        {
            string Xpath = "//mat-label[normalize-space(text())='Website']/following::input[@id='mat-input-10']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(websiteName.Trim());
        }

        //AHCCCS ID
        public static string CheckTheAHCCCSIDLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='AHCCCS ID']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static string CheckTheDefaultSelectedAHCCCSID_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='AHCCCS ID']/following::input[@id='mat-input-11']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("value");
        }
        public static void EnterAHCCCSID_OrganizationInfopage(IWebDriver driver, string AhcccsId)
        {
            string Xpath = "//mat-label[normalize-space(text())='AHCCCS ID']/following::input[@id='mat-input-11']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(AhcccsId.Trim());
        }

        #region 3. Subscription Plan
        public static string CheckTheDefaultSelectedSubscriptionPlan_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-select[@id='mat-select-6']//span[contains(@class,'mat-mdc-select-min')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text.Trim();
        }
        public static string CheckTheSubscriptionPlanLabel_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//mat-label[normalize-space(text())='Subscription Plan']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static void ClickOnTheSubscriptionPlanTypeDropDown_OrganizationInfopage(IWebDriver driver)
        {
            string clickDropdown = "//mat-select[@id='mat-select-6']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(clickDropdown)));
            driver.FindElement(By.XPath(clickDropdown)).Click();
        }
        public static IList<string> GetAllOptionsFromSubscriptionPlanTypeDropDown_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//div[@id='cdk-overlay-3']//span[contains(@class,'mdc-list')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            var allOptions = driver.FindElements(By.XPath(Xpath));
            IList<string> optionTexts = new List<string>();

            foreach (var option in allOptions)
            {
                optionTexts.Add(option.Text.Trim());
            }

            return optionTexts;
        }
        public static void ClickOnTheOptionFromSubscriptionPlanTypeDropDown_OrganizationInfopage(IWebDriver driver, string subscriptionPlan)
        {
            string Xpath = "//div[@id='cdk-overlay-3']//span[contains(@class,'mdc-list')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            var allOptions = driver.FindElements(By.XPath(Xpath));
            var targetOption = allOptions.First(value => value.Text.Contains(subscriptionPlan));
            targetOption.Click();
        }
        #endregion

        //Medicare Rating
        public static string CheckTheRovicareRating_OrganizationInfopage(IWebDriver driver)
        {
            string Xpath = "//label[normalize-space(text())='Medicare Rating']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
       /* public static */
    }
}
