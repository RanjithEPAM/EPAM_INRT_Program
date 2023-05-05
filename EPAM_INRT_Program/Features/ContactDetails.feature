Feature: Contact Details

A short summary of the feature

Background:
	Given I launch the Orange HRM url
	When I enter the HRM user credentials
	Then OrangeHRM home page should be displayed


Scenario: Verification of Contact Details page
	Given I am on OrangeHRM home page
	When I navigate to Contact Details page
	Then I should be able to enter below data in Contact details page
		| Field   | Value     |
		| Street1 | <Street1> |
		| Street2 | <Street2> |
		| City    | <City>    |
	
Examples:
	| TC  | Street1   | Street2   | City    |
	| 101 | Street101 | Street201 | Chennai |
	| 102 | Street102 | Street202 | Karur   |
	| 103 | Street103 | Street203 | Pune    |
	| 104 | Street104 | Street204 | Delbhi  |
