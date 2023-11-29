Feature: Facebook home page login

@smoke @Application1 @Application2
Scenario: To check the login functionality for the FB home page with invalid credentials
	Given User navigates to the Facebook home page
	When User enters test123 as username and pass11 as passwork
	And Click on the login button
	Then the login not successful
