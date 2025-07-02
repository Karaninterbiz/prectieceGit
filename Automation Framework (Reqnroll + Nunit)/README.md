# Automation\_Framework\_Reqnroll\_Nunit

## Overview

This project is a Behavior-Driven Development (BDD) automation framework designed using:

- Reqnroll (SpecFlow) for Gherkin-based test definitions
- NUnit as the test runner
- Selenium WebDriver for browser automation
- ExtentReports for HTML test reporting
- ChromeDriver as the default browser
- C# and .NET 8.0

## Project Structure

```
Automation_Framework_Reqnroll_Nunit/
|
├── Features/                      # Gherkin (.feature) files for each test scenario
├── StepDefinitions/              # Step definition bindings for features
├── Pages/                        # Page Object Model (POM) classes
├── Utility/                      # Common reusable utilities
│   ├── BaseClass.cs              # Browser launcher and data reader access
│   ├── CommonSteps.cs           # Role-based credential fetcher
│   ├── ExtentReport.cs          # Handles report lifecycle, screenshots, and logging
│   ├── WebDriverExtensions.cs   # Extension methods for WebDriver
├── TestData/
│   ├── RoleCredentials.json     # JSON file containing role-based login credentials
│   └── TestUrl.json             # JSON file containing test environment URL
├── Hooks/
│   └── Hooks.cs                 # SpecFlow lifecycle hook integration (init, teardown, reporting)
└── README.md                     # Project documentation
```

## Key Features

- Gherkin Syntax: Human-readable test scenarios
- Dependency Injection: Uses SpecFlow's built-in DI for driver/context injection
- Extent Report Integration: Automatic step-level logging with screenshots on failure
- Role-Based Login: JSON-based credential management for multiple user roles
- Headless Execution Ready: Optional Chrome headless mode for CI/CD pipelines
- Dynamic Path Resolution: Project-relative paths for test data and reports

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET SDK (8.0 or compatible)
- Chrome browser installed
- Required NuGet packages:
  - Reqnroll
  - Reqnroll.NUnit
  - Selenium.WebDriver
  - Selenium.WebDriver.ChromeDriver
  - AventStack.ExtentReports
  - Newtonsoft.Json

### Setup Steps

1. **Clone the Repository**

   ```bash
   git clone https://github.com/your-repo/Automation_Framework_Reqnroll_Nunit.git
   cd Automation_Framework_Reqnroll_Nunit
   ```

2. **Configure Test Data**

   - Update `TestData/TestUrl.json` with your test environment URL
   - Add credentials in `TestData/RoleCredentials.json`

3. **Build the Project**

   - Using Visual Studio or:
     ```bash
     dotnet build
     ```

4. **Execute Tests**

   ```bash
   dotnet test
   ```

## Sample Login Feature

```
Feature: Login Functionality

  Scenario: Verify SupportAdmin can log into the system
    Given Login To DMEScripts SupportAdmin, "password123"
    Then Verify user is redirected to dashboard
```

## Reports

- HTML test reports are generated after test execution.
  - Output Location: `/TestResults/ExtentReport_<timestamp>.html`
  - Screenshots Location: `/Screenshots/`

## Contribution Guidelines

- Maintain structured region blocks and XML comments in all C# files.
- Follow the documented file header format for consistency.
- Adhere to standard Gherkin syntax in `.feature` files.

## Author & Maintainer

**Rishabh Vishwakarma**

For any queries or support, please contact the author or raise issues via your source control platform.

## License

This project is licensed under the MIT License.

