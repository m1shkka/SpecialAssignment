using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace TestFramework
{
    public class DriversFabric
    {
        public static ExtDriver Init(string Browser)
        {
            switch (Browser)
            {
                case ("IE"):
                    IWebDriver IEDriver = new InternetExplorerDriver();
                    return new ExtDriver(IEDriver);
                case ("Edge"):
                    IWebDriver Edgedriver = new EdgeDriver();
                    return new ExtDriver(Edgedriver);
                default:
                    IWebDriver Chromedriver = new ChromeDriver();
                    return new ExtDriver(Chromedriver);
            }
        }
    }
}
