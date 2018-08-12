using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace TestFramework
{
    public class DriversFabric
    {
        public static ExtDriver Init()
        {
            IWebDriver Chromedriver = new ChromeDriver();
            return new ExtDriver(Chromedriver);
        }
    }
}
