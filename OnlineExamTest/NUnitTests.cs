using System;
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

        //[SetUp]
        //public void Before()
        //{
        //    if (!Browser.Initialised) Browser.Initialize();
        //    Browser.Driver.Navigate().GoToUrl("http://51.144.34.125/");
        //}

        //[TearDown]
        //public void After()
        //{
        //    Browser.Quit();
        //}

        [Test]
        public void LoginTest()
        {
            if (!Browser.Initialised) Browser.Initialize();
            Browser.Driver.Navigate().GoToUrl("http://51.144.34.125/");
            Header header = new Header();
            header.SignInClick();
            LoginPage loginPage = new LoginPage();
            loginPage.InputEmail(Student_email);
            loginPage.InputPassword(Student_password);
            loginPage.ClickOnSubmitNutton();
            Loginned loginned = new Loginned();
            var result = loginned.SignUpField();
            Browser.Quit();

            StringAssert.Contains(Student_email, result.ToLowerInvariant());
        }

        [Test]
        public void LogOuttest()
        {
            if (!Browser.Initialised) Browser.Initialize();
            Browser.Driver.Navigate().GoToUrl("http://51.144.34.125/");
            Header header = new Header();
            header.SignInClick();
            LoginPage loginPage = new LoginPage();
            loginPage.InputEmail(Student_email);
            loginPage.InputPassword(Student_password);
            loginPage.ClickOnSubmitNutton();
            Loginned loginned = new Loginned();
            loginned.ClickOnLogOutButton();
            Header NewHeader = new Header();
            var result = NewHeader.GetSignInText();
            Browser.Quit();

            StringAssert.Contains("SIGN UP", result);
        }

        [Test]
        public void CreateCourseTest()
        {

            string NewCourseName = "TheBestCourse";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://51.144.34.125/");

            IWebElement element = driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(4) > a"));
            element.Click();
            element = driver.FindElement(By.Id("emailLogin"));
            element.SendKeys(Teacher_email);
            element = driver.FindElement(By.Id("passwordLogin"));
            element.SendKeys(Teacher_password);
            element = driver.FindElement(By.Id("submitLogin"));
            element.Click();

            element = driver.FindElement(By.CssSelector("#gn-menu > li.gn-trigger > a"));
            element.Click();
            element = driver.FindElement(By.CssSelector("#gn-menu > li.gn-trigger > nav > div > ul > li:nth-child(4) > a"));
            element.Click();
            element = driver.FindElement(By.CssSelector("body > div > div > a:nth-child(1)"));
            element.Click();
            element = driver.FindElement(By.Id("Name"));
            element.SendKeys(NewCourseName);
            element = driver.FindElement(By.Id("Description"));
            element.SendKeys("Description");
            element = driver.FindElement(By.CssSelector("body > div > div > form > div:nth-child(3) > input"));
            element.Click();
            element = driver.FindElement(By.XPath($"//*[contains(text(), '{NewCourseName}')]"));
            driver.Close();
            Assert.IsNotNull(element);

        }

        [Test]
        public void DeleteCourseTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://51.144.34.125/");

            IWebElement element = driver.FindElement(By.CssSelector("#gn-menu > li:nth-child(4) > a"));
            element.Click();
            element = driver.FindElement(By.Id("emailLogin"));
            element.SendKeys(Admin_email);
            element = driver.FindElement(By.Id("passwordLogin"));
            element.SendKeys(Admin_password);
            element = driver.FindElement(By.Id("submitLogin"));
            element.Click();
            
            element = driver.FindElement(By.CssSelector("#gn-menu > li.gn-trigger > a"));
            element.Click();
            element = driver.FindElement(By.CssSelector("#gn-menu > li.gn-trigger > nav > div > ul > li:nth-child(4) > a"));
            element.Click();
            element = driver.FindElement(By.CssSelector("body > div > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > form > a.btn.btn-sm.btn-danger"));
            element.Click();
            driver.Navigate().Refresh();
            element = driver.FindElement(By.CssSelector("body > div > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > form > a.btn.btn-sm.btn-primary"));
            var result = element.Text;
            element.Click();
            driver.Close();
            Assert.AreEqual("Recover", result);




        }
    }
}
    







