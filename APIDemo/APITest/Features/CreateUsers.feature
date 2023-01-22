Feature: CreateUsers

Scenario: Add a New User
	Given I input name "Mike"
	And I input job "QA"
	When I send request to create user
	Then Validate user is created