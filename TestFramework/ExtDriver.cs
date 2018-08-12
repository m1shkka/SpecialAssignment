using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public class ExtDriver
    {
        private IWebDriver driver;

        public ExtDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        public IWebElement Find(By by)
        {
            return driver.FindElement(by);
        }
    }
    
}
