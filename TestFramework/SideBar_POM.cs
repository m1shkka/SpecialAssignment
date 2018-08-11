using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class SideBar_POM : BasePage
    {
        //public SideBar_POM(IWebDriver driver) : base(driver)
        //{
        //}

        By uadminPanelMenuItemElement = By.CssSelector(@"a[href*='/AdminPanel/Users']");
        By newsMenuItemElement = By.CssSelector("a[href*='/AddNews/News']");
        By coursesMenuItemElement = By.CssSelector(@"a[href*='/CourseManagement']");
        By tasksMenuItemElement = By.CssSelector(@"a[href*='/CodeHistory/History']");
        By codeHistoryMenuItemElement = By.CssSelector(@"a[href*='/CourseManagement']");
        By navBarElement = By.CssSelector(".gn-icon-menu");

        public SideBar_POM()
        {
        }

        public void GoToNavBar()
        {
            Initialize(navBarElement).Click();
        }               

        public void GoToCoursePage()
        {
            Initialize(coursesMenuItemElement).Click();
        }
        
        public void GoToTasksPage()
        {
            Initialize(tasksMenuItemElement).Click();
        }
        
        public void GoToCodeHistoryPage()
        {
            Initialize(codeHistoryMenuItemElement).Click();
        }
        
        public void GoToNewsPage()
        {
            Initialize(newsMenuItemElement).Click();
        }
    }
}
