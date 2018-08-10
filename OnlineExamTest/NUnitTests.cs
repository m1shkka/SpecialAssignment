using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineExamTest
{
    [TestFixture]
    public class NUnitTests
    {
        const string Student_email = "student@gmail.com";
        const string Student_password = "Student_123";

        [Test]
        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://51.144.34.125/");

            IWebElement element = driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(4) > a"));
            element.Click();
            element = driver.FindElement(By.Id("emailLogin"));
            element.SendKeys(Student_email);
            element = driver.FindElement(By.Id("passwordLogin"));
            element.SendKeys(Student_password);
            element = driver.FindElement(By.Id("submitLogin"));
            element.Click();
            element = driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(3) > a"));
            var result = element.Text;
            driver.Close();
            driver.Quit();


            StringAssert.Contains(Student_email, result.ToLowerInvariant());

        }

        [Test]
        public void LogOutTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://51.144.34.125/");

            IWebElement element = driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(4) > a"));
            element.Click();
            element = driver.FindElement(By.Id("emailLogin"));
            element.SendKeys(Student_email);
            element = driver.FindElement(By.Id("passwordLogin"));
            element.SendKeys(Student_password);
            element = driver.FindElement(By.Id("submitLogin"));
            element.Click();

            element = driver.FindElement(By.CssSelector("#logoutForm > button"));
            element.Click();
            element = driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(3) > a"));
            var result = element.Text;
            driver.Close();
            driver.Quit();


            StringAssert.Contains("SIGN UP", result);

        }
    }
}
