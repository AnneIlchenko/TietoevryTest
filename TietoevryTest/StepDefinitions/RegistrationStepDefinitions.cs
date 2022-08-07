using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TietoevryTest.Drivers;
using TietoevryTest.PageObjects;

namespace TietoevryTest.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        //Page Object for Registration
        private readonly RegistrationPageObject _registrationPageObject;

        public RegistrationStepDefinitions(BrowserDriver browserDriver)
        {
            _registrationPageObject = new RegistrationPageObject(browserDriver.Current);
        }

        [Given(@"go to the registration page")]
        public void GivenGoToTheRegistrationPage()
        {
            _registrationPageObject.OpenRegistrationForumPage();
        }

        [When("user confirms the conditions of registration")]
        public void WhenUserConfirmsTheConditionsOfRegistration()
        {
            _registrationPageObject.ConfirmRegistrationRules();
            _registrationPageObject.ClickSubmit();
        }

        [When("user enters '(.*)' user name")]
        public void WhenUserEntersUserName(string userName)
        {
            _registrationPageObject.EnterUserName(userName);
        }

        [When("user enters the following values for password")]
        public void WhenUserEntersTheFollowingValuesForPassword(Table table)
        {
            foreach (var row in table.Rows)
            {
                _registrationPageObject.EnterPassword(row["Password"]);
                _registrationPageObject.ConfirmPassword(row["ConfirmPassword"]);
            }
        }

        [When("user enters the following values for mail")]
        public void WhenUserEntersTheFollowingValuesForMail(Table table)
        {
            foreach (var row in table.Rows)
            {
                _registrationPageObject.EnterPassword(row["Mail"]);
                _registrationPageObject.ConfirmPassword(row["ConfirmMail"]);
            }
        }

        [When("user presses the registration confirmation button")]
        public void WhenUserPressesTheRegistrationConfirmationButton()
        {
            _registrationPageObject.ClickSubmit();
        }

        [Then("error message with '(.*)' text is displayed for user")]
        public void WhenErrorMessageWithTextIsDisplayedForUser(string messageText)
        {
            _registrationPageObject.GetErrorMessageText(messageText);
        }
    }
}