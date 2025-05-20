using System.Net.Http.Headers;
using StudentControl.Models;

namespace StudentControl.Services
{
    public class StudentService : IStudentService
    {
        private List<Student> students;

        public StudentService()
        {
            // Dummy in-memory list for demonstration
            students = new List<Student>();
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int CI)
        {
            var student = students.FirstOrDefault(s => s.CI == CI);
            if (student == null)
            {
                student = new Student { CI = 0, Name = "Not Found", Grade = 0 };
            }
            return student;
        }

        public Student Create(Student student)
        {
            Student createdStudent;
            if (students.Any(s => s.CI == student.CI))
            {
                createdStudent = new Student { CI = 0, Name = "Already Exists", Grade = 0 };
            }

            if (student.CI < 1000 || student.Grade < 0 || student.Grade > 100)
            {
                createdStudent = new Student { CI = 0, Name = "Invalid Data", Grade = 0 };
            }
            else
            {
                students.Add(student);
                createdStudent = student;
            }
            return createdStudent;
        }
        public Student Update(int CI, Student updatedStudent)
        {
            Student student = GetById(CI);
            if (student == null)
            {
                student = new Student { CI = 0, Name = "Not Found", Grade = 0 };
            }
            else
            {
                student.Name = updatedStudent.Name;
                student.Grade = updatedStudent.Grade;
            }
            return student;
        }

        public Student Delete(int CI)
        {
            var student = GetById(CI);
            if (student == null)
            {
                student = new Student { CI = 0, Name = "Not Found", Grade = 0 };
            }
            else
            {
                students.Remove(student);
            }
            return student;
        }

        public bool HasAproved(int CI)
        {
            var student = GetById(CI);
            if (student == null)
            {
                return false;
            }

            return student.Grade >= 51;
        }
    }
}