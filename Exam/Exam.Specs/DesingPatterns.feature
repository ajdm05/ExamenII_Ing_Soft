Feature: PatronFactoryMethod
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Desing Methods
	Given I have the following data from a file
	| Name           | FirstElement | SecondElement |
	| Suma           | 1            | 3             |
	| Resta          | 5            | 6             |
	| Multiplicacion | 4            | 3             | 
	When I call Factory Method
	And I call Iterator Method
	And I call Observer Method
	Then the result should be 
	| FactoryResult | IteratorResult | ObserverResult |
	| 4             | 3              | 5              |
	| -1            | 1              | 5              |
	| 12            | 2              |                |
