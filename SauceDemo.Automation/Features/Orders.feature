Feature: Orders

Background:
	Login to application. Old steps used.
	Given I am on expected URL: 'HomePage'
	And I enter 'standard_user' and 'secret_sauce'
	When I press Login button
	Then I am on expected URL: 'InventoryPage'


@order_everything @basket_items
Scenario: Adding every item to the basket.
	Given I am on expected URL: 'InventoryPage'
	When I click 'ADD TO CART' button of each item in the store
	Then I can see a number of items in a basket equals number of items available in shop