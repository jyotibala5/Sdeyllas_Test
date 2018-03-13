Feature: Search
	As A User
	I want to perform a search using the term sdesyllas
	So that I can investigate the returned search results

@mytag
Scenario: User searches for Sdesyllas
	Given I am on the Search pages
	When I search for the term "sdesyllas"
	Then the user avatar is returned within the results
	And the user location is returned within the results
	And the user top five repositories are returned within the results
