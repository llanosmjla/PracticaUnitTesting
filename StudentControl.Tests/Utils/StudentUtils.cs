
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
                new Student { CI = 1111, Name = "Test Student 1", Grade = 50 },
                new Student { CI = 2222, Name = "Test Student 2", Grade = 46 },
                new Student { CI = 3333, Name = "Test Student 3", Grade = 70 },
                new Student { CI = 4444, Name = "Test Student 4", Grade = 80 }
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