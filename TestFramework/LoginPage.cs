using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public static class Browser
    {
        public static IWebDriver Driver { get; set; }
        public static bool Initialised { get; set; }

        public static void Initialize()
        {
            Driver = new ChromeDriver();
            Initialised = true;
        }

        public static void Quit()
        {
            Driver.Quit();
            Initialised = false;
        }
    }
    public class LoginPage
    {
        private IWebElement HomeButton = Browser.Driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(2) > a"));
        private IWebElement FieldForEmail = Browser.Driver.FindElement(By.Id("emailLogin"));
        private IWebElement FieldForPassword = Browser.Driver.FindElement(By.Id("passwordLogin"));
        private IWebElement SubmitButton = Browser.Driver.FindElement(By.Id("submitLogin"));

        public void HomeButtonClick()
        {
            HomeButton.Click();
        }
        public void InputEmail(string email)
        {
            FieldForEmail.SendKeys(email);
        }
        public void InputPassword(string password)
        {
            FieldForPassword.SendKeys(password);
        }
        public void ClickOnSubmitNutton()
        {
            SubmitButton.Click();
        }

    }

    public class Loginned
    {
        private IWebElement SignUp = Browser.Driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(3) > a"));
        private IWebElement LogOut = Browser.Driver.FindElement(By.CssSelector("#logoutForm > button"));

        public string SignUpField()
        {
            var result = SignUp.Text;
            return result;
        }
        public void ClickOnLogOutButton()
        {
            LogOut.Click();
        }

    }

    public class Header
    {
        private IWebElement SignIn = Browser.Driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(4) > a"));
        private IWebElement SignUp = Browser.Driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(3) > a"));

        public void SignInClick()
        {
            SignIn.Click();            
        }

        public void SignUpClick()
        {
            SignUp.Click();            
        }

        public string GetSignInText()
        {
            var text = SignUp.Text;
            return text;
        }

    }
}
