using OpenQA.Selenium;
using Xunit;

namespace TietoevryTest.PageObjects
{
    public class RegistrationPageObject
    {
        private const string RegistrationForumUrl = "https://www.kharkovforum.com/register.php";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        public RegistrationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Finding elements
        private IWebElement RuleValidationCheckbox => _webDriver.FindElement(By.Id("cb_rules_agree"));
        private IWebElement SubmitButton => _webDriver.FindElement(By.XPath(".//input[@type='submit']"));
        private IWebElement UserNameField => _webDriver.FindElement(By.Id("regusername"));
        private IWebElement PasswordField => _webDriver.FindElement(By.Name("password"));
        private IWebElement ConfirmPasswordField => _webDriver.FindElement(By.Name("passwordconfirm"));
        private IWebElement EmailAddressField => _webDriver.FindElement(By.Name("email"));
        private IWebElement ConfirmEmailAddressField => _webDriver.FindElement(By.Name("emailconfirm"));
        private IWebElement ErrorMessageText => _webDriver.FindElement(By.XPath(".//td[@class='alt1']//li"));


        public void ConfirmRegistrationRules()
        {
            RuleValidationCheckbox.Click();
        }

        public void ClickSubmit()
        {
            SubmitButton.Click();
        }

        public void EnterUserName(string name)
        {
            UserNameField.Clear();
            UserNameField.SendKeys(name);
        }

        public void EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ConfirmPassword(string password)
        {
            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(password);
        }

        public void EnterEmailAddress(string mail)
        {
            EmailAddressField.Clear();
            EmailAddressField.SendKeys(mail);
        }

        public void ConfirmEmailAddress(string mail)
        {
            ConfirmEmailAddressField.Clear();
            ConfirmEmailAddressField.SendKeys(mail);
        }

        public void OpenRegistrationForumPage()
        {
            _webDriver.Navigate().GoToUrl(RegistrationForumUrl);
        }

        public void GetErrorMessageText(string expectedText)
        {
            var text = ErrorMessageText.Text;
            Assert.Equal(expectedText, text);
        }
    }
}