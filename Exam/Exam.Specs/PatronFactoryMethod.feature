Feature: PatronFactoryMethod
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Patron Factory Method
	Given I have the following data from a file
	| Name           | FirstElement | SecondElement |
	| Suma           | 1            | 3             |
	| Resta          | 5            | 6             |
	| Multiplicacion | 4            | 3             | 
	When I call Factory Method
	Then the result should be 
	| Result |
	| 4      |
	| -1     |
	| 12     |
