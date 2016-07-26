Feature: CheckStatusOfService
	In order to troubleshoot problems with the service
	As a support engineer
	I want to be able to see the status of the service and its dependencies

Scenario: Check database connection status
	When I hit the healthcheck endpoint
	Then I should see the database connection status
