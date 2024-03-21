Feature: AmazonShopping

As an unregistered user I want to search for an item, add it to the cart, and validate the cart contents

@tag1
Scenario: Add item to cart and validate
	Given I navigate to Amazon.com as an unregistered user
	When I search for "TP-Link N450 WiFi Router - Wireless Internet Router for Home (TLWR940N)"
	And I add the item to the cart
	And I navigate to the cart
	Then I should see the correct item and amount in the cart
