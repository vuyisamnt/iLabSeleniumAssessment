Feature: iLab
	Apply for job with no resume file attached.

@mytag
Scenario: Apply for job with no resume file attached
	Given I launch iLab Website
	Then I should see iLabs Home Page
	When I click on Careers Link
	Then I should see Careers Page
	When I click on South Africa Link
	Then I should see South Africa Careers Page
	When I click on first Job option
	Then I should see first Job Page
	When I click Apply Online dropdown
	And I fill in required textbox
	| Name   | Email_Address                        |
	| Vuyisa | automationAssessment@iLABQuality.com |
	And I click on Send Application
	Then I should see uplaod File Error Message 
	And I close the browser