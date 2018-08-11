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
        protected ExtDriver driver;

        public BasePage()
        {

        }

        public void SetDriver(ExtDriver driver)
        {
            this.driver = driver;
        }


        virtual public IWebElement Initialize(By by)
        {
            return driver.Find(by);
        }
    }
}