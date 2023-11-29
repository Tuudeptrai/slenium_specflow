Feature: search Google

#test comment in gg feature file
Background:
	Given Google page open 
	And search box should present and enable 

Scenario Outline: search in GG home page with some tutorial
	
	When User search a course with key "<keyworkname>" tutorial
	And hit enter
	Then all course "<keyworkname>" tutorial should be díplayed

	Examples: 
	|keyworkname|
	|java		|
	|Specflow	|
	|Selenium	|