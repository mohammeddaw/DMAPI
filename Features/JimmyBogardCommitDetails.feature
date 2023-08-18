Feature: JimmyBogardCommitDetails

@apitest
Scenario: As a user that is interested in Jimmy Bogard's Github commits

	Given a valid auth token
	When requesting GET  https://api.github.com/repos/jbogard/MediatR/commit
	Then the most recent commit is authored by Jimmy Bogard
	And the most recent commit is dated 10th July 2023