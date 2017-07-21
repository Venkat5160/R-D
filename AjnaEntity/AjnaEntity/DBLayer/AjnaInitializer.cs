using AjnaEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjnaEntity.DBLayer
{
    public class AjnaInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<AjnaContext>
    {
        protected override void Seed(AjnaContext context)
        {
            //base.Seed(context);
            var students = new List<Student>
            {
                new Student{FirstMidName="Venkanna",LastName="Bandi",EnrollmentDate=DateTime.Now},
                new Student{FirstMidName="Srishanth",LastName="Bandi",EnrollmentDate=DateTime.Now},
                new Student {FirstMidName="Kumar",LastName="Bandi",EnrollmentDate=DateTime.Now},
                new Student {FirstMidName="Srudeep",LastName="Bandi",EnrollmentDate=DateTime.Now},
            };

            students.ForEach(x => context.Students.Add(x));
            context.SaveChanges();
            var courses = new List<Course>
            {
                new Course{CourseID=001,Title="Maths",Credits=3},
                new Course{CourseID=002,Title="Phisics",Credits=3},
                new Course{CourseID=003,Title="Chemistry",Credits=4},
                new Course{CourseID=004,Title="Biology",Credits=4},
            };
            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var enrollments = new List<Enrollment> {
            new Enrollment{StudentID=1,CourseID=001,Grade=Grade.A},
            new Enrollment{StudentID=2,CourseID=002,Grade=Grade.B},
            new Enrollment{StudentID=3,CourseID=003,Grade=Grade.C},
            new Enrollment{StudentID=4,CourseID=004,Grade=Grade.D},
            new Enrollment{StudentID=1,CourseID=001,Grade=Grade.F},
            };

            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();


        }
    }
}