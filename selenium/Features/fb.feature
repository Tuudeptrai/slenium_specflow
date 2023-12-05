Feature: Facebook home page login

@smoke 
Scenario Outline: To check the login functionality for the FB home page with invalid credentials
	Given User navigates to the Facebook home page
	When User enters "<username>" as username and "<password>" as password
	And Click on the login button
	Then the login not successful

	Examples: 
	|username   |  password    |
	|dd%&dff    |  password123 |
	|đfffff     |  password223 |
	|ffeedđ     |  password233 |
	|fhfjfj|  password233 |