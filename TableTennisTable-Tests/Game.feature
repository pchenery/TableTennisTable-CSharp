Feature: Game

    Scenario: Empty League
	    Given the league has no players
	    When I print the league
	    Then I should see "No players yet"

	Scenario: Load League
		Given the league has saved game
		When I load the league
		Then I should see the players
