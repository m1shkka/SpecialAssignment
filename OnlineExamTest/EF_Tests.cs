using System;
using System.Net;
using NUnit.Framework;
using TestFramework;
using OnlineExamTest;
using DataAccess;

namespace OnlineExamTest
{
    [TestFixture]
    [Category("EF_test")]
    public class EF_Tests
    {
        const string Student_email = "student@gmail.com";
        const string Student_password = "Student_123";
        const string Teacher_email = "teacher@gmail.com";
        const string Teacher_password = "Teacher_123";
        const string Admin_email = "admin@gmail.com";
        const string Admin_password = "Admin_123";

        protected ExtDriver driver;

        [Test]
        public void EF_add_test()
        {
            string coursename = "C# Starter";
            var course = new DAL();
            course.AddCourseByEF(coursename, "tratata", "6d377a43-7c36-4f6c-8555-b88d4f0043dc");
            var result = course.IsCoursePresentedByDesc("tratata");
            Assert.True(result);

            driver = DriversFabric.Init("Chrome");
            driver.GoToUrl("http://localhost:55842/CourseManagement");
            var Course = new Courses_POM(driver);
            var textresult = Course.GetCourseName1();
            driver.Dispose();
            Assert.AreEqual(coursename, textresult);
        }

        [Test]
        public void EF_Change_Test()
        {
            string coursename = "C# Starter";
            string newname = "C# Essential";
            var course = new DAL();
            course.ChangeCourseByEF(coursename, newname);
            var result = course.IsCoursePresentedByName(newname);
            Assert.True(result);

            driver = DriversFabric.Init("Chrome");
            driver.GoToUrl("http://localhost:55842/CourseManagement");
            var Course = new Courses_POM(driver);
            var textresult = Course.GetCourseName2();
            driver.Dispose();
            Assert.AreEqual(newname, textresult);
        }

        [Test]
        public void EF_2_v_1()
        {
            string coursename = "C# Starter";
            string newname = "C# Essential";
            driver = DriversFabric.Init("Chrome");
            driver.GoToUrl("http://localhost:55842/CourseManagement");

            var course = new DAL();
            course.AddCourseByEF(coursename, "tratata", "6d377a43-7c36-4f6c-8555-b88d4f0043dc");

            driver.refresh();
            var Course = new Courses_POM(driver);
            var textresult = Course.GetCourseName1();
            Assert.AreEqual(coursename, textresult);

            course.ChangeCourseByEF(coursename, newname);

            driver.refresh();
            Course = new Courses_POM(driver);
            textresult = Course.GetCourseName2();
            Assert.AreEqual(newname, textresult);
        }

    }
}








