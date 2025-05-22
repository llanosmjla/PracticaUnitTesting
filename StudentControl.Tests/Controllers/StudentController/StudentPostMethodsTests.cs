using Microsoft.AspNetCore.Mvc;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Services;
using StudentControl.Tests.Stubs;
using Xunit;
using Moq;

namespace StudentControl.Controllers.UnitTests
{

    public class StudentPostMehtodTests
    {
        // Unit tests using Mocks with Moq
        [Fact]
        public void Create_ValidStudent_ReturnsStudentWithSameNameSent()
        {
            // Arrange - Given
            var studentServiceMock = new Mock<IStudentService>();
            var student = new Student
            {
                CI = 5555,
                Name = "Jorge Luis",
                Grade = 85
            };

            studentServiceMock
                .Setup(service => service.Create(student))
                .Returns(student);

            StudentController controller = new StudentController(studentServiceMock.Object);
            // Act - When

            var result = controller.Create(student);
            // Assert - Then

            Assert.NotNull(result);
            Assert.Equal(student.Name, result.Name);
        }

        [Fact]
        public void Create_ValidStudent_ReturnsStudentWithSameCISent()
        {
            // Arrange
            var studentServiceMock = new Mock<IStudentService>();
            var student = new Student
            {
                CI = 5555,
                Name = "Jorge Luis",
                Grade = 85
            };

            studentServiceMock
                .Setup(service => service.Create(student))
                .Returns(student);

            StudentController controller = new StudentController(studentServiceMock.Object);
            // Act
            var result = controller.Create(student);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(student.CI, result.CI);
        }


        // Unit tests using Stubs
        [Fact]
        public void Create_ValidStudent_ReturnsStudentWithSameGradeSent()
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
            Assert.Equal(student.Grade, result.Grade);
        }
        [Fact]
        public void Create_ValidStudent_ReturnsStudentWithSameData()
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
            Assert.Equal(student.Name, result.Name);
            Assert.Equal(student.Grade, result.Grade);
        }
    }
}