Feature: Creating games
	In order to play games
	As a player
	I want to be able to create games

Scenario: Create a game
	Given a player 'Dominique'
	When player 'Dominique' creates a game 'Game'
	Then a game 'Game' should exist 
	And player 'Dominique' should be the owner of game 'Game'

Scenario: Owner is also a player
	Given a player 'Dominique'
	When player 'Dominique' creates a game 'Game'
	Then player 'Dominique' should be playing in 'Game'

