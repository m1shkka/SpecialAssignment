using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class SideBar_POM : BasePage
    {

        IWebElement uadminPanelMenuItemElement;
        IWebElement coursesMenuItemElement; 
        IWebElement tasksMenuItemElement;
        IWebElement codeHistoryMenuItemElement;
        IWebElement navBarElement;

        public SideBar_POM(ExtDriver driver) : base(driver)
        {
        }

        public override void Initt()
        {
            //this.driver = DriversFabric.Init();
            this.uadminPanelMenuItemElement = driver.Find(By.CssSelector(@"a[href*='/AdminPanel/Users']"));
            this.coursesMenuItemElement = driver.Find(By.CssSelector(@"a[href*='/CourseManagement']"));
            this.tasksMenuItemElement = driver.Find(By.CssSelector(@"a[href*='/CodeHistory/History']"));
            this.codeHistoryMenuItemElement = driver.Find(By.CssSelector(@"a[href*='/CourseManagement']"));
            this.navBarElement = driver.Find(By.CssSelector(".gn-icon-menu"));
        }


        public void GoToNavBar()
        {
            navBarElement.Click();
        }               

        public void GoToCoursePage()
        {
            coursesMenuItemElement.Click();
        }
        
        public void GoToTasksPage()
        {
            tasksMenuItemElement.Click();
        }
        
        public void GoToCodeHistoryPage()
        {
            codeHistoryMenuItemElement.Click();
        }
    }
}
