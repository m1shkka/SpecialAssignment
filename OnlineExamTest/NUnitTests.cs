using System;
using System.Net;
using NUnit.Framework;
using TestFramework;
using OnlineExamTest;
using DataAccess;

namespace OnlineExamTest
{
    [TestFixture]
    public class NUnitTests
    {
        const string Student_email = "student@gmail.com";
        const string Student_password = "Student_123";
        const string Teacher_email = "teacher@gmail.com";
        const string Teacher_password = "Teacher_123";
        const string Admin_email = "admin@gmail.com";
        const string Admin_password = "Admin_123";

        protected ExtDriver driver;

 
        [Test]
        public void LoginTest()
        {
            driver = DriversFabric.Init();
            driver.GoToUrl("http://51.144.34.125/");
            var header = new Header_POM(driver);
            header.SignInClick();
            var loginPage = new LoginPage(driver);
            loginPage.Login(Student_email, Student_password);
            var loginned = new Loginned(driver);
            var result = loginned.SignUpField();
            driver.Dispose();

            StringAssert.Contains(Student_email, result.ToLowerInvariant());
        }
        [Test]
        public void LogOutTest()
        {
            driver = DriversFabric.Init();
            driver.GoToUrl("http://51.144.34.125/");
            var header = new Header_POM(driver);
            header.SignInClick();
            var loginPage = new LoginPage(driver);
            loginPage.Login(Student_email, Student_password);
            var loginned = new Loginned(driver);
            loginned.ClickOnLogOutButton();
            var NewHeader = new Header_POM(driver);
            var result = NewHeader.GetSignUpText();
            driver.Dispose();

            StringAssert.Contains("SIGN UP", result);
        }


        //private CoursesClient client;
        //[Test]
        //public void PostCourse()
        //{
        //    var guid = new Guid().ToString();
        //    var obj = new
        //    {
        //        name = $"C# CourseName111 {guid}",
        //        description = "Description for new Course",
        //        UserId = "6d377a43-7c36-4f6c-8555-b88d4f0043dc"
        //    };

        //    client = new CoursesClient();
        //    var result = client.Post(obj);
        //    Assert.NotNull(result);
        //    Assert.AreEqual(result, HttpStatusCode.OK);
        //    var actual = new DAL().GetCourseByCourseName(obj.name);
        //    var actualDescription = actual.Description;
        //    Assert.AreEqual(obj.description, actualDescription, "Method post doesn't work, because of expected course name isn't equal actual course name");
        //}

        [Test]
        public void EF_add_test()
        {
            string coursename = "C# Starter";
            var course = new DAL();
            course.AddCourseByEF(coursename, "tratata", "6d377a43-7c36-4f6c-8555-b88d4f0043dc");
            var result = course.IsCoursePresentedByDesc("tratata");
            Assert.True(result);

            driver = DriversFabric.Init();
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

            driver = DriversFabric.Init();
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
            driver = DriversFabric.Init();
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
    







