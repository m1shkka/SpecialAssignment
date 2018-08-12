using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAL
    {
      //  const string ConnectionString = "Server = (localdb)\\mssqllocaldb; Database = Main; integrated security = True;";
        const string ConnectionString = "data source=(localdb)\\mssqllocaldb;initial catalog=Main;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";


        //public Cours GetCourseByCourseName(string Coursename)
        //{
        //    using (var ctx = new Model1(ConnectionString))
        //    {
        //        var result = ctx.Courses.FirstOrDefault(c => c.Name == Coursename);
        //        return result;
        //    }

        //}

        public void AddCourseByEF(string CourseName, string desc, string userid)
        {
            using (Model1 db = new Model1(ConnectionString))
            {
                Cours cours = new Cours { Name = CourseName, Description = desc, UserId = userid };
                db.Courses.Add(cours);
                db.SaveChanges();
            }
        }


        public bool IsCoursePresentedByDesc(string desc)
        {
            using (Model1 db = new Model1(ConnectionString))
            {
                bool f = false;
                var courses = db.Courses;
                foreach (Cours c in courses)
                {
                    if (c.Description.Equals(desc))
                    {
                        f = true;
                        return f;
                        break;
                    }                    
                }
                return f;
            }
        }

        public void ChangeCourseByEF(string CourseName, string NewName)
        {
            using (Model1 db = new Model1(ConnectionString))
            {
                var result = db.Courses.FirstOrDefault(c => c.Name == CourseName);
                result.Name = NewName;
                db.SaveChanges();
            }
        }

        public bool IsCoursePresentedByName(string name)
        {
            using (Model1 db = new Model1(ConnectionString))
            {
                bool f = false;
                var courses = db.Courses;
                foreach (Cours c in courses)
                {
                    if (c.Name.Equals(name))
                    {
                        f = true;
                        return f;
                        break;
                    }
                }
                return f;
            }
        }


    }
}
