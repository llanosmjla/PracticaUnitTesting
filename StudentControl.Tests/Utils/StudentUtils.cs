
using System.Collections.Generic;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Tests.Stubs;



namespace StudentControl.Tests.Utils
{


    public static class StudentUtils
    {
        public static List<Student> GetDummyStudents()
        {
            return new List<Student>
            {
                new Student { CI = 1111, Name = "Ana Maria", Grade = 55 },
                new Student { CI = 2222, Name = "Jose Mesa", Grade = 46 },
                new Student { CI = 3333, Name = "Luis Martinez", Grade = 78 },
                new Student { CI = 4444, Name = "Erick Mela", Grade = 90 }
            };
        }

        public static Student GetDummyStudent()
        {
            return new Student
            {
                CI = 5555,
                Name = "Alice Johnson",
                Grade = 90
            };
        }

        public static StudentController GetTestStudentController()
        {
            return new StudentController(new StudentServiceStub());
        }
    }
}