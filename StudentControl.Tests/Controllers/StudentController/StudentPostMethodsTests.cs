using Microsoft.AspNetCore.Mvc;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Services;
using StudentControl.Tests.Stubs;
using Xunit;

namespace StudentControl.Controllers.UnitTests
{

    public class StudentPostMehtodTests
    {
        [Fact]
        public void Create_ValidStudent_ReturnsStudentWithSameName()
        {
            // Arrange
            StudentController controller = new StudentController(new StudentServiceStub());
            Student student = new Student
            {
                CI = 5555,
                Name = "Test Student 5",
                Grade = 85
            };

            // Act
            var result = controller.Create(student);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(student.Name, result.Name);
        }
        [Fact]
        public void Create_ValidStudent_ReturnsStudentWithSameCI()
        {
            // Arrange
            StudentController controller = new StudentController(new StudentServiceStub());
            Student student = new Student
            {
                CI = 5555,
                Name = "Test Student 5",
                Grade = 85
            };

            // Act
            var result = controller.Create(student);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(student.CI, result.CI);
        }
    }
}