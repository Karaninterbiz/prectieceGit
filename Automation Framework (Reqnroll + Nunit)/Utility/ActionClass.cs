using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.Utility
{
    public class ActionClass
    {

        // A generic method to check the element is visible and clickable
        public static Boolean IsElementVisibleAndClickable(IWebDriver driver,string Xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(20));

                IWebElement _element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));

                return _element.Displayed && _element.Enabled;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Element Check Failed : {ex.Message}");
                return false;
            }
        }

        // A generic method to get the placeholder of the element
        public static string GetPlaceHolderText(IWebDriver driver,string Xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement _placeHolder = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                return _placeHolder.GetAttribute("placeholder");
            }
            catch(NoSuchElementException)
            {
                Console.WriteLine("Element not found for placeholder..");
                return null;
            }
        }
    }
}
