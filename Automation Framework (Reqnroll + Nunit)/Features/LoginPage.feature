Feature: To Check the Login Functionality for different user roles

Scenario Outline: TC 01. Verify successful login for different user roles
	Given the user is on the login page and check the DME logo is visible
	When the user validates the placeholder text for email and password fields
	And Login To DMEScripts and <User> enter the email and password <Password>
	And clicks on the Sign In button
	Then the user should not see any error messages
	And the user should be successfully redirected to the DME Home page


Examples:
	| User                       | Password             |
	| supportadmin               | supportadminpassword |
	| providerorganization       | password             |
	| providerprescriber         | password             |
	| providercareteammember     | password             |
	| supplierorganization       | password             |
	| supplierteammember         | password             |
	| supplierteammemberreadonly | password             |
	

Scenario Outline: TC 02. Verify error messages when login fails with invalid credentials
	Given the user is on the login page and check the DME logo is visible
	And Login To DMEScripts <Email> enter the email and enter the password <Passwordd>
	And clicks on the Sign In button
	Then error messages should be displayed on the Login Page

Examples:
	| Email                        | Passwordd   |
	|                              |             |
	|                              | Testdme@123 |
	| DMESupportAdmin@yopmail.com  |             |
	| wrongadmin@yopmail.com       | Test@123    |
	| DMESupportAdmin@yopmail.com  | Wrong@123   |
	| DMESupportAdmin@yoopmail.com | Test@123    |
	| dmesupportadminyopmail.com   | Test@123    |
	| DMESupportAdmin@yopmail.com  | test@123    |
	| DMESupportAdmin@yopmail.com  | Test123     |
	| DMESupportAdmin@invalid.com  | Test@123    |
	| wrong@example.com            | wrongpass   |
	| DMESupportAdmin@yopmail.com  | !@#$%^&*    |
	| admin@rovicare.com           | <script>    |
	| DMESupportAdmin@yopmail.com  | pass@       |
	| DMESupportAdmin@yopmail.com  | password@!  |
	| %user%@rovicaretest.com      | Test@123    |
	| DME!Support@rovicaretest.com | Test@123    |	

