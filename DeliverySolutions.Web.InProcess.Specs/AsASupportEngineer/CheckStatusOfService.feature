Feature: CheckStatusOfService
	In order to troubleshoot problems with the service
	As a support engineer
	I want to be able to see the status of the service and its dependencies

Background: 
	When I hit the healthcheck endpoint

Scenario: See assembly version
	Then I should see the assembly version of the service

Scenario: Check database connection status
	Then I should see the database connection status
