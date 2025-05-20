using Microsoft.AspNetCore.Mvc;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Services;
using StudentControl.Tests.Stubs;
using Xunit;

namespace StudentControl.Controllers.UnitTests
{

    public class StudentPutMehtodTests
    {
        [Fact]
        public void Update_ExistingCI_ReturnsUpdatedStudent()
        {
            // Arrange
            StudentController controller = new StudentController(new StudentServiceStub());
            var studentCI = 1111;
            Student student = new Student
            {
                CI = studentCI,
                Name = "Test Student 1",
                Grade = 50
            };

            // Act
            var result = controller.Update(studentCI, student);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(student.Name, result.Name);
            Assert.Equal(student.Grade, result.Grade);
            Assert.Equal(studentCI, result.CI);

        }
    }
}