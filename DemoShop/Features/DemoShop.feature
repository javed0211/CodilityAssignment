Feature: DemoShop	
Description : Develop a web test solution that automates below simple test Scenario, composed as BDD scenario the target is the dummy website: https://testscriptdemo.com

@Wishlist 
Scenario Outline: Verify wishlist functionality
	Given I add '<noOfProducts>' different products to my wish list
	When  I view my wishlist table
	Then  I find total '<noOfProducts>' selected items in my wishlist
	When  I search for lowest price product
	And   I am able to add the lowest price to my cart
	Then  I am able to verify the item in my cart
	Examples: 
	| noOfProducts |
	| 4            |