Feature: See Available Shipping Methods
	In order to choose a shipping method that suits my budget and needs
	As a customer
	I want to see which shipping methods I can choose

@mytag
Scenario: A bag with two items
	Given I have two items in my bag
	When I look at my shipping methods
	Then I should see which methods fit each item
