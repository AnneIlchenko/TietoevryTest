Feature: Registration
A short summary of the feature

@Tietoevry @Test
Scenario: Check registration error if the user does not pass the picture test
	Given go to the registration page
	When user confirms the conditions of registration
	When user enters 'TestUserName' user name
	When user enters the following values for password
		| Password | ConfirmPassword |
		| 1q2w3e4r | 1q2w3e4r        |
	When user enters the following values for mail
		| Mail                   | ConfirmMail            |
		| TestUserName@gmail.com | TestUserName@gmail.com |
	When user presses the registration confirmation button
	Then error message with 'Ви заповнили не усі обов'язкові поля: логін, пароль і адреса е-пошти.' text is displayed for user