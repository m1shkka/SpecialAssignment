using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class LoginPage : BasePage
    {

        IWebElement FieldForEmail; 
        IWebElement FieldForPassword;
        IWebElement SubmitButton;

        public LoginPage(ExtDriver driver) : base(driver)
        {
        }

        public override void Initt()
        {
            //this.driver = DriversFabric.Init();
            this.FieldForEmail = driver.Find(By.Id("emailLogin"));
            this.FieldForPassword = driver.Find(By.Id("passwordLogin"));
            this.SubmitButton = driver.Find(By.Id("submitLogin"));

        }


        public void Login(string email, string password)
        {
            FieldForEmail.SendKeys(email);
            FieldForPassword.SendKeys(password);
            SubmitButton.Click();
        }
    }

    public class Loginned : BasePage
    {
        IWebElement SignUP;
        IWebElement LogOut;

        public Loginned(ExtDriver driver) : base(driver)
        {
        }

        public override void Initt()
        {
            //this.driver = DriversFabric.Init();
            this.SignUP = driver.Find(By.CssSelector("#gn-menu > li:nth-child(3) > a"));
            this.LogOut = driver.Find(By.CssSelector("#logoutForm > button"));
           
        }

        public string SignUpField()
        {            
            var result = SignUP.Text;
            return result;
        }
        public void ClickOnLogOutButton()
        {
            LogOut.Click();
        }

    }
}
