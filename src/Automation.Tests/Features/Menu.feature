Feature: Menu

Scenario: Launch about us from menu
	Given user launches para bank
	When user clicks on About Us from menu
	Then user should be able to view About Us page

Scenario: Launch services from menu
	Given user launches para bank
	When user clicks on Services from menu
	Then user should be able to view Services page