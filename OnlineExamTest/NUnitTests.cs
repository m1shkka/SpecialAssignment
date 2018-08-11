﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestFramework;

namespace OnlineExamTest
{
    [TestFixture]
    public class NUnitTests
    {
        const string Student_email = "student@gmail.com";
        const string Student_password = "Student_123";
        const string Teacher_email = "teacher@gmail.com";
        const string Teacher_password = "Teacher_123";
        const string Admin_email = "admin@gmail.com";
        const string Admin_password = "Admin_123";

 
        [Test]
        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://51.144.34.125/");
            var header = new Header_POM(driver);
            header.SignInClick();
            var loginPage = new LoginPage(driver);
            loginPage.Login(Student_email, Student_password);
            var loginned = new Loginned(driver);
            var result = loginned.SignUpField();
            driver.Quit();

            StringAssert.Contains(Student_email, result.ToLowerInvariant());
        }

        [Test]
        public void LogOutTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://51.144.34.125/");
            var header = new Header_POM(driver);
            header.SignInClick();
            var loginPage = new LoginPage(driver);
            loginPage.Login(Student_email, Student_password);
            var loginned = new Loginned(driver);
            loginned.ClickOnLogOutButton();
            var NewHeader = new Header_POM(driver);
            var result = NewHeader.GetSignUpText();
            driver.Quit();

            StringAssert.Contains("SIGN UP", result);
        }

    }
}
    







