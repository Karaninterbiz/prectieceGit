Feature: Rovicare

  Validate the login functionality of Rovicare with valid and invalid credentials

  @Valid
  Scenario: Validating the login functionality with valid credential
    Given User opens the Chrome browser
    And User enters valid credentials
    When User clicks the Sign In button
    Then User should navigate to the home page

  @Invalid
  Scenario Outline: Validating the login functionality with invalid credentials
    Given User opens the Chrome browser
    And User enters invalid credentials "<EmailAddress>" and "<Password>"
    When User clicks the Sign In button
    Then Error message should be displayed

    Examples:
      | EmailAddress           | Password                             |
      | test@example.com       | wrongpass                            |
      | wronguser@rovicare.com | correctpass                          |
      |                        | somepass123                          |
      | user@rovicare.com      |                                      |
      | !@#$$%%^&*             | !@#pass                              |
      | test@@rovicare.com     | pass123                              |
      | user@rovicare.com      | short                                |
      | rovicare@test.com      | pass with space                      |
      | user@rovicare.com      | 123456789012345678901234567890123456 |
      | null@null.com          | null                                 |
      | sharma@*%gmail.co      | sharma@*%gmail.co                    |
      |                        |                                      |
      |                        |                                      |

