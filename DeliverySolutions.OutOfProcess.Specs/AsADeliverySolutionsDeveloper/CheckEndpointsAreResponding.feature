Feature: Check Endpoints Are Responding
	In order to have confidence that the application works as expected
	As a developer of the Delivery solutions service
	I want to check that the endpoints respond

Scenario: Check healthcheck endpoint
	When I hit the healthcheck endpoint
	Then I should get a healthcheck response
