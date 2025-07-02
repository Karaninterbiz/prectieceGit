// --------------------------------------------------------------------------------------------------------------------
//  Author      : RIshabh Vishwakarma
//  File        : BaseClass.cs
//  Description : Core utility class for browser and test environment setup in the automation framework.
//  Purpose     : 
//     - Provides reusable methods for launching the Chrome browser with preconfigured options.
//     - Manages WebDriver initialization and test environment setup.
//     - Exposes utility for reading JSON-based test data dynamically using JSonReader.
// --------------------------------------------------------------------------------------------------------------------

using Automation_Framework_Reqnroll_Nunit.TestData;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.Utility
{
    public class BaseClass
    {
        #region 1. JSON Test Data Reader
        /// <summary>
        /// Instantiates and returns a JSON test data reader.
        /// </summary>
        /// <returns>New instance of JSonReader</returns>
        public static JSonReader GetDataParser()
        {
            return new JSonReader();
        }

        #endregion

        #region 2. Browser Launch (Chrome)
        /// <summary>
        /// Launches the Chrome browser with specified options and navigates to the given test URL.
        /// </summary>
        /// <param name="testUrl">The URL to navigate to upon browser launch</param> string? ModuleName = "other"
        /// <returns>An initialized Chrome WebDriver instance</returns>
        public IWebDriver BrowserLaunch(string testUrl, string? ModuleName = "other")
        {
            try
            {
                IWebDriver driver;
                // Define the default download directory
                var downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                // Chrome preferences for file downloads
                var chromeOpts = new ChromeOptions();
                chromeOpts.AddUserProfilePreference("download.default_directory", downloadPath);
                chromeOpts.AddUserProfilePreference("download.prompt_for_download", false);
                chromeOpts.AddUserProfilePreference("download.directory_upgrade", true);
                chromeOpts.AddUserProfilePreference("safebrowsing.enabled", true);

                // Additional Chrome options
                var options = new ChromeOptions();
                //options.AddArgument("--headless"); // Uncomment for CI runs

                // Initialize the WebDriver
                if (ModuleName == "chrome")
                {
                    driver = new ChromeDriver(options);
                }
                else if (ModuleName == "firefox")
                {
                    driver = new FirefoxDriver();
                }
                else if (ModuleName == "edge")
                {
                    driver = new EdgeDriver();
                }
                else
                {
                    driver = new ChromeDriver(options);
                }        
                                
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(testUrl);

                return driver;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WebDriver ERROR] {ex.Message}");
                throw;
            }
        }
        #endregion

    }
}
