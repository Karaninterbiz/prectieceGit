Feature: validate the Forgot Password functionality

Scenario Outline: TC 01. Verify successful Forgot Password request with valid email addresses
	Given the user is on the login page and check the DME logo is visible
	And the user verifies that the Forgot Password link is displayed and clicks on it
	Then the user should be navigated to the Change Password section
	When the user enters a valid email <Email> in the email field
	And clicks on the Send Verification Code button
	Then a verification code should be sent to the email <Email>
	And the user enters the received OTP and clicks on the Verify Codebutton
	And the user clicks on the Continue button to complete the password change process
	And the user creates a new password <NewPassword> and confirm password <ConfirmPassword> and clicks on the Continue button
	And the user must accept the RoviCare TERM OF USE condition
	And the user should be successfully redirected to the DME Home page

Examples:
	| Email      | NewPassword | ConfirmPassword    |
	| Automation | NewPassword | ConfirmNewPassword |

Scenario: TC 02. Verify Forgot Password fails with blank email address
	Given the user is on the login page and check the DME logo is visible
	And the user verifies that the Forgot Password link is displayed and clicks on it
	Then the user should be navigated to the Change Password section
	When the user leaves the email field blank <Empty>
	And clicks on the Send Verification Code button
	Then the system should show a relevant error message to the user

Scenario Outline: TC 03. Verify Forgot Password fails with invalid email format
	Given the user is on the login page and check the DME logo is visible
	And the user verifies that the Forgot Password link is displayed and clicks on it
	Then the user should be navigated to the Change Password section
	When the user enters an invalid email <InvalidEmail> in the email field
	And clicks on the Send Verification Code button
	Then the system should show a relevant error message to the user on the display
Examples:
	| InvalidEmail                 |
	| dmesupportadminyopmail.com   |
	| DMESupportAdmin@             |
	| @yopmail.com                 |
	| DMESupportAdmin@yopmail      |
	| DMESupportAdmin@yopmail..com |
	| DMESupportAdmin@.com         |
	| DMESupportAdmin@.yopmail.com |
	| DMESupportAdminyopmail.com   |
	| DMESupportAdmin@yop mailcom  |
	| DMESupportAdmin@@yopmail.com |
	| DMESupportAdmin@yopmail,com  |
	| DMESupportAdmin@#$.com       |

Scenario: TC 04. Verify OTP validation with incorrect verification code
	Given the user is on the login page and check the DME logo is visible
	And the user verifies that the Forgot Password link is displayed and clicks on it
	Then the user should be navigated to the Change Password section
	When the user enters a valid email <Email> in the email field
	And clicks on the Send Verification Code button
	Then a verification code should be sent to the email <Email>
	And the user enters the Incorrect OTP and clicks on the Verify Codebutton
	And the system should display an error message

Examples:
	| Email      |
	| Automation |

Scenario: TC 05. Verify password mismatch error during reset
	Given the user is on the login page and check the DME logo is visible
	And the user verifies that the Forgot Password link is displayed and clicks on it
	Then the user should be navigated to the Change Password section
	When the user enters a valid email <Email> in the email field
	And clicks on the Send Verification Code button
	Then a verification code should be sent to the email <Email>
	And the user enters the received OTP and clicks on the Verify Codebutton
	And the user clicks on the Continue button to complete the password change process
	And the user creates a new password <NewPassword> and confirm password <ConfirmPasswordd> and clicks on the Continue button
	And the system should display an error message Passwords do not match
Examples:
	| Email      | NewPassword | ConfirmPasswordd    |
	| Automation | NewPassword | ConfirmNewPasswordd |
