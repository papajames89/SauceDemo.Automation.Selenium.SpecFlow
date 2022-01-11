Feature: Login

@Login_valid
Scenario: Verify login with valid credentials
	Given I am on expected URL: 'HomePage'
	And I enter '<login>' and '<password>'
	When I press Login button
	Then I am on expected URL: 'InventoryPage'

	Examples:
		| login         | password     |
		| standard_user | secret_sauce |

@Login_invalid
Scenario: Verify login with invalid credentials
	Given I am on expected URL: 'HomePage'
	And I enter '<login>' and '<password>'
	When I press Login button
	Then I can see '<popup>' message

	Examples:
		| login | password | popup                                                       |
		| asd   | 123      | Username and password do not match any user in this service |

@Login_locked
Scenario: Verify login with locked user credentials
	Given I am on expected URL: 'HomePage'
	And I enter '<login>' and '<password>'
	When I press Login button
	Then I can see '<popup>' message

	Examples:
		| login           | password     | popup                                |
		| locked_out_user | secret_sauce | Sorry, this user has been locked out |