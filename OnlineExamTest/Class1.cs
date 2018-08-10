using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineExamTest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://51.144.34.125/");

            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"gn - menu\"]/li[4]/a"));
            element.Click();

            Assert.AreEqual("http://51.144.34.125/Account/Login", driver.Url);

        } 
    }
}
