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

        //public Header_POM(IWebDriver driver) : base(driver)
        //{}

        //IWebDriver driver = DriverFabric.GetDriver();

        By SignIn = By.CssSelector("#gn-menu > li:nth-child(4) > a");
        By SignUp = By.CssSelector("#gn-menu > li:nth-child(3) > a");
        By HomeButton = By.CssSelector("#gn-menu > li:nth-child(2) > a");

        

            public void HomeButtonClick()
            {
                Initialize(HomeButton).Click();
            }

            public void SignInClick()
            {
                Initialize(SignIn).Click();
            }

            public void SignUpClick()
            {
            Initialize(SignUp).Click();
            }

            public string GetSignInText()
            {
                var text = Initialize(SignIn).Text;
                return text;
            }
            
            public string GetSignUpText()
            {
                var text = Initialize(SignUp).Text;
                return text;
            }

        
    }
}
