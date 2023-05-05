Feature: APITesting

A short summary of the feature

@tag1
Scenario Outline: Validation of POST request
	Given I have a POST request for the REST API as
		| Field  | Value    |
		| Name   | <Name>   |
		| Salary | <Salary> |
		| Age    | <Age>    |
	When I send the POST request for REST API
	Then I receive the response
	And the status code should be 200
Examples:
	| TestCase ID | Name   | Salary | Age |
	| TC001       | Sachin | 25000  | 30  |
	| TC002       | Chris  | 35000  | 28  |
	| TC003       | Morris | 20000  | 31  |
	| TC004       | Lynn   | 45000  | 32  |

Scenario Outline: Validation of GET request
	Given I have a GET request for the REST API
	When I send the GET request for REST API
	Then I receive the response
	And the status code should be 200
	And the response should contain data as
		| Field     | Value       |
		| ID        | <ID>        |
		| EMAIL     | <EMAIL>     |
		| FIRSTNAME | <FIRSTNAME> |
		| LASTNAME  | <LASTNAME>  |
Examples:
	| TestCaseID | ID | EMAIL                  | FIRSTNAME | LASTNAME |
	| TC001      | 2  | janet.weaver@reqres.in | Janet     | Weaver   |




