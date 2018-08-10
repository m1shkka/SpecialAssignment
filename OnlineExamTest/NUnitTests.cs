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
        const string Teacher_email = "teacher@gmail.com";
        const string Teacher_password = "Teacher_123";
        const string Admin_email = "admin@gmail.com";
        const string Admin_password = "Admin_123";

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
    







