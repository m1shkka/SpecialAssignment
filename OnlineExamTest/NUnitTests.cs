using System;
using System.Net;
using NUnit.Framework;
using TestFramework;
using OnlineExamTest;
using DataAccess;

namespace OnlineExamTest
{
    [TestFixture]
    [Category("UI_test")]
    public class NUnitTests
    {
        const string Student_email = "student@gmail.com";
        const string Student_password = "Student_123";
        const string Teacher_email = "teacher@gmail.com";
        const string Teacher_password = "Teacher_123";
        const string Admin_email = "admin@gmail.com";
        const string Admin_password = "Admin_123";

        protected ExtDriver driver;

        [Test]
        public void LoginTest()
        {
            driver = DriversFabric.Init("Chrome");
            driver.GoToUrl("http://51.144.34.125/");
            var header = new Header_POM(driver);
            header.SignInClick();
            var loginPage = new LoginPage(driver);
            loginPage.Login(Student_email, Student_password);
            var loginned = new Loginned(driver);
            var result = loginned.SignUpField();
            driver.Dispose();

            StringAssert.Contains(Student_email, result.ToLowerInvariant());
        }

        [Test]
        public void LogOutTest()
        {
            driver = DriversFabric.Init("chrome");
            driver.GoToUrl("http://51.144.34.125/");
            var header = new Header_POM(driver);
            header.SignInClick();
            var loginPage = new LoginPage(driver);
            loginPage.Login(Student_email, Student_password);
            var loginned = new Loginned(driver);
            loginned.ClickOnLogOutButton();
            var NewHeader = new Header_POM(driver);
            var result = NewHeader.GetSignUpText();
            driver.Dispose();

            StringAssert.Contains("SIGN UP", result);
        }


    }
}
    







