Feature: Creating games
	In order to play games
	As a player
	I want to be able to create games

Scenario: Create a new game
	Given a player 'Dominique'
	When player 'Dominique' creates the game 'Game'
	Then a game 'Game' should exist
	And player 'Dominique' should be playing in 'Game'