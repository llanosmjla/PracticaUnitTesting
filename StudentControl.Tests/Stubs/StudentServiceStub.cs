using StudentControl.Models;
using StudentControl.Services;

namespace StudentControl.Tests.Stubs
{
    public class StudentServiceStub : IStudentService
    {
        private List<Student> _students;
        public StudentServiceStub()
        {
            _students = new List<Student>
            {
                new Student { CI = 1111, Name = "Ana Maria", Grade = 55 },
                new Student { CI = 2222, Name = "Jose Mesa", Grade = 46 },
                new Student { CI = 3333, Name = "Luis Martinez", Grade = 78 },
                new Student { CI = 4444, Name = "Erick Mela", Grade = 90 }
            };
        }
        public List<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(s => s.CI == id) ?? new Student { CI = 0, Name = "Not Found", Grade = 0 };
        }
        public Student Create(Student student)
        {
            if (_students.Any(s => s.CI == student.CI))
            {
                return new Student { CI = 0, Name = "Already Exists", Grade = 0 };
            }
            if (student.CI < 1000 || student.Grade < 0 || student.Grade > 100)
            {
                return new Student { CI = 0, Name = "Invalid Data", Grade = 0 };
            }
            
            _students.Add(student);
            return student;
        }
        public Student Update(int id, Student updatedStudent)
        {
            var student = GetById(id);
            if (student == null)
            {
                return new Student { CI = 0, Name = "Not Found", Grade = 0 };
            }

            student.Name = updatedStudent.Name;
            student.Grade = updatedStudent.Grade;
            return student;
        }
        public Student Delete(int id)
        {
            var student = GetById(id);
            if (student == null)
            {
                return new Student { CI = 0, Name = "Not Found", Grade = 0 };
            }

            _students.Remove(student);
            return student;

        }
        public bool HasAproved(int id)
        {
            var student = GetById(id);
           
            return student != null && student.Grade >= 51;
        }
    }
}