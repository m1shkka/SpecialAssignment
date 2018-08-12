using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public class Courses_POM : BasePage
    {
        public Courses_POM(ExtDriver driver) : base(driver)
        {
        }

        IWebElement CourseName1;
        IWebElement CourseName2;

        string NewCourseName1 = "C# Starter";
        string NewCourseName2 = "C# Essential";

        public override void Initt()
        {
            this.CourseName1 = driver.Find(By.XPath($"//*[contains(text(), '{NewCourseName1}')]"));
            this.CourseName2 = driver.Find(By.XPath($"//*[contains(text(), '{NewCourseName2}')]"));
        }

        public string GetCourseName1()
        {
            var text = CourseName1.Text;
            return text;
        }
        public string GetCourseName2()
        {
            var text = CourseName2.Text;
            return text;
        }
    }
}
