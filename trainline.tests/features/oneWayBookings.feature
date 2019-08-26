Feature: oneWayBookings
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Posetive @DataDriven
Scenario Outline: List of trains is getting displayed for correct Route
	Given I am on landing page
	And I enter <origin> and <destination> cities
	And I select date and <Time>
	And I select <Adult> and <Children> details
	When I click on  Get Time and Tickets button
	Then list of trains should be displayed for correct <origin> and <destination> cities

	Examples:
		| origin       | destination   | Adult | Children | Time       |
		| Eaglescliffe | Dagenham Dock | 1     | 0        | LeavingAt  |
		| Eaglescliffe | Dagenham Dock | 9     | 0        | ArrivingBy |
		| Eaglescliffe | Dagenham Dock | 2     | 1        | ArrivingBy |
		| Eaglescliffe | Dagenham Dock | 2     | 2        | LeavingAt  |



Scenario Outline: Travel options screen is displayed when user clicks on Continue button on Result Page
	Given I am on landing page
	And I enter <origin> and <destination> cities
	And I select date and <Time>
	And I select <Adult> and <Children> details
	When I click on  Get Time and Tickets button
	And I click on "Continue" button 
	Then I should be navigated to Travel options screen
		Examples:
		| origin       | destination   | Adult | Children | Time       |
		| Eaglescliffe | Dagenham Dock | 1     | 0        | LeavingAt  |


Scenario Outline: User is asked to Login before proceeding to payments
	Given I am on landing page
	And I enter <origin> and <destination> cities
	And I select date and <Time>
	And I select <Adult> and <Children> details
	When I click on  Get Time and Tickets button
	And I click on "Continue" button 
	And I click on Continue button on Travel options page
	Then I should be navigated to Sign in Page
		Examples:
		| origin       | destination   | Adult | Children | Time       |
		| Eaglescliffe | Dagenham Dock | 1     | 0        | LeavingAt  |