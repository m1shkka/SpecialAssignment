using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public abstract class BasePage
    {
        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        virtual public IWebElement Initialize(By by)
        {
            return driver.FindElement(by);
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://51.144.34.125/");
        }
    }
}
