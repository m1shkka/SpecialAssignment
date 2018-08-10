using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://51.144.34.125/");

            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"gn - menu\"]/li[4]/a"));
            element.Click();

            Assert.AreEqual("http://51.144.34.125/Account/Login", driver.Url);

        }
    }
}
