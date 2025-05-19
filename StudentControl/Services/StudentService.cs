using StudentControl.Models;

namespace StudentControl.Services
{
    public class StudentService
    {
        private readonly List<Student> students = new List<Student>();

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int CI)
        {
            var student = students.FirstOrDefault(s => s.CI == CI);
            if (student == null)
            {
                student = new Student { CI = 0, Name = "Unknown", Grade = 0 };
            }
            return student;
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public bool Update(int CI, Student updatedStudent)
        {
            var student = GetById(CI);
            if (student == null) return false;
            
            student.Name = updatedStudent.Name;
            student.Grade = updatedStudent.Grade;

            return true;
        }

        public bool Delete(int id)
        {
            var student = GetById(id);
            if (student == null) return false;

            students.Remove(student);
            return true;
        }
    }
}