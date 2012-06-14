Feature: Joining games
	In order play games
	As a player
	I want to be be able to join existing games that haven't started yet.

Scenario: Join existing game
	Given a game 'Game'
	And a player 'Dominique'
	When player 'Dominique' joins 'Game'
	Then player 'Dominique' should be playing in 'Game'
