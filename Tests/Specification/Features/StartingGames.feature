Feature: Addition
	In order to play games
	As a game ownerer
	I want to be able to start a game

Scenario: Starting a game you own
	Given a player 'Dominique'
	And a player 'Justin'
	When player 'Dominique' creates a game 'Game'
	And player 'Justin' joins 'Game'
	And player 'Dominique' starts game 'Game'
	Then game 'Game' should be started

Scenario: Starting a game you don't own
	Given a player 'Dominique'
	And a player 'Justin'
	When player 'Justin' creates a game 'Game'
	And player 'Dominique' joins 'Game'
	And player 'Dominique' starts game 'Game'
	Then game 'Game' should not be started
