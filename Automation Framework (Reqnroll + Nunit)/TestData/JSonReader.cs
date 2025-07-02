// --------------------------------------------------------------------------------------------------------------------
//  Author      : Rishabh Vishwakarma
//  File        : JSonReader.cs
//  Description : Utility class for reading values from JSON files used in the test automation framework.
//  Purpose     : 
//     - Resolves the project root directory dynamically.
//     - Reads JSON files from relative paths.
//     - Extracts values using JSON token selectors.
//     - Handles missing file or token scenarios gracefully with exception logging.
// --------------------------------------------------------------------------------------------------------------------


using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Reqnroll_Nunit.TestData
{
    /// <summary>
    /// Provides functionality to read data tokens from JSON files.
    /// Designed and implemented by Rishabh Vishwakarma for DMEScripts automation framework.
    /// </summary>
    public class JSonReader
    {
        #region 1. Read JSON Token by Name
        /// <summary>
        /// Retrieves a value from a JSON file based on the provided token name and file path.
        /// </summary>
        /// <param name="tokenName">The name of the token/key to extract from the JSON</param>
        /// <param name="path">The relative path to the JSON file from the project root</param>
        /// <returns>The value of the token as a string, or null if not found</returns>
        public string TestData(string tokenName, string path)
        {
            try
            {
                // Resolve working directory (typically bin/debug) and go to project root
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;

                if (projectDirectory == null)
                    throw new DirectoryNotFoundException("Project directory path could not be resolved.");

                // Construct full file path
                string fullPath = Path.Combine(projectDirectory, path);
                if (!File.Exists(fullPath))
                    throw new FileNotFoundException($"JSON file not found at {fullPath}");

                // Read and parse JSON
                string json = File.ReadAllText(fullPath);
                var token = JToken.Parse(json).SelectToken(tokenName);

                if (token == null)
                    throw new Exception($"Token '{tokenName}' not found in {fullPath}");

                return token.ToString().Trim('"');
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[JSonReader ERROR] {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
