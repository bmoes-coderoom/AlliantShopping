Feature: Shopping

As a member of the Alliant Hiring Team
I want to test the coding exercises of candidates
To help assess their technical skills

Background: 
Given all the inventory is loaded

@tag1
Scenario Outline: User Goes Shopping For Items
	Given user shops for following items '<Items>'
	When user goes to checkout
	Then the total should be <Total>
	Examples: 
	| Items    | Total |
	| ABCDABAA | 32.40 |
	| CCCCCCC  | 7.25  |
	| ABCD     | 15.40 |
