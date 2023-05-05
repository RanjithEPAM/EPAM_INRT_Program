Feature: PersonalDetails

A short summary of the feature

Background:
	Given I launch the Orange HRM url
	When I enter the HRM user credentials
	Then OrangeHRM home page should be displayed

@Regression
Scenario: Verification of Personal Details page
	Given I am on OrangeHRM home page
	When I navigate to Personal Details page
	Then I should be able to enter below data in personal details page
		| Field     | Value       |
		| FirstName | <FirstName> |
		| LastName  | <LastName>  |
	
Examples:
	| TC  | FirstName | LastName |
	| 101 | Kevin     | Henry    |
	| 102 | Chris     | Morris   |
	| 103 | Steven    | Jerrico  |
	| 104 | Edge      | Austim   |
