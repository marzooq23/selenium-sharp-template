Feature: RegisterCustomer

Scenario: Register individual customer
	Given user launches para bank
	When user register as individual customer
	Then user should be able to register as individual customer

Scenario: Register organization customer
	Given user launches para bank
	When user register as organization customer
	Then user should be able to register as organization customer