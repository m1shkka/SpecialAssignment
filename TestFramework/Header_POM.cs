using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public class Header_POM : BasePage
    {

        IWebElement HomeButton;
        IWebElement SignIn;
        IWebElement SignUp;

        public Header_POM(ExtDriver driver) : base(driver)
        {
        }


        public override void Initt()
        {
            //this.driver = DriversFabric.Init();
            this.SignIn = driver.Find(By.CssSelector("#gn-menu > li:nth-child(4) > a"));
            this.SignUp = driver.Find(By.CssSelector("#gn-menu > li:nth-child(3) > a"));
        }


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
            var text = SignIn.Text;
            return text;
        }

        public string GetSignUpText()
        {
            var text = SignUp.Text;
            return text;
        }
    }
}