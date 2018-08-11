using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class LoginPage : BasePage
    {
        //public LoginPage(IWebDriver driver) : base(driver)
        //{
        //}

        By FieldForEmail = By.Id("emailLogin");
        By FieldForPassword = By.Id("passwordLogin");
        By SubmitButton = By.Id("submitLogin");

        public LoginPage()
        {
        }

        public void Login(string email, string password)
        {
            Initialize(FieldForEmail).SendKeys(email);
            Initialize(FieldForPassword).SendKeys(password);
            Initialize(SubmitButton).Click();
        }

        public void InputEmail(string email)
        {
            Initialize(FieldForEmail).SendKeys(email);
        }
        public void InputPassword(string password)
        {
            Initialize(FieldForPassword).SendKeys(password);
        }
        public void ClickOnSubmitNutton()
        {
            Initialize(SubmitButton).Click();
        }

    }

    public class Loginned : BasePage
    {
        By SignUP = By.CssSelector("#gn-menu > li:nth-child(3) > a");
        By LogOut = By.CssSelector("#logoutForm > button");

        //public Loginned(IWebDriver driver) : base(driver)
        //{
        //}

        public string SignUpField()
        {            
            var result = Initialize(SignUP).Text;
            return result;
        }
        public void ClickOnLogOutButton()
        {
            Initialize(LogOut).Click();
        }

    }
}
