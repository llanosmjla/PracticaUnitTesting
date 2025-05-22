using Moq;
using Xunit;

using Microsoft.AspNetCore.Mvc;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Services;
using StudentControl.Tests.Stubs;


namespace StudentControl.Controllers.UnitTests
{

    public class StudentHasAprovedMethodsTests
    {
        //Unit tests using Mocks with Moq
        [Fact]
        public void HasAproved_WithAPassedGrade_ReturnsTrue()
        {
            // Arrange
            int studentCI = 3333;
            var studentServiceMock = new Mock<IStudentService>();

            studentServiceMock
                .Setup(service => service.HasAproved(studentCI))
                .Returns(true);

            var controller = new StudentController(studentServiceMock.Object);

            // Act
            var result = controller.HasAproved(studentCI);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasAproved_WithNotPassedGrade_ReturnsFalse()
        {
            // Arrange
            int studentCI = 1111;
            var studentServiceMock = new Mock<IStudentService>();

            studentServiceMock
                .Setup(service => service.HasAproved(studentCI))
                .Returns(false);

            var controller = new StudentController(studentServiceMock.Object);

            // Act
            var result = controller.HasAproved(studentCI);

            // Assert
            Assert.False(result);
        }

        // Unit Tests using Stub 
        [Fact]
        public void HasAproved_ValidStudent_ReturnsTrue()
        {
            // Arrange
            StudentController controller = new StudentController(new StudentServiceStub());
            var studentCI = 1111;

            // Act
            var result = controller.HasAproved(studentCI);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasAproved_ValidStudent_ReturnsFalse()
        {
            // Arrange
            StudentController controller = new StudentController(new StudentServiceStub());
            var studentCI = 2222;

            // Act
            var result = controller.HasAproved(studentCI);

            // Assert
            Assert.False(result);
        }

        // Unit tests using Student service
        [Fact]
        public void HasAproved_ValidStudent_ReturnsTrue_StudentService()
        {
            // Arrange
            int studentCI = 1111;
            var studentService = new StudentService();
            studentService.Create(new Student { CI = studentCI, Name = "Test Student 1", Grade = 80});
            studentService.Create(new Student { CI = 2222, Name = "Test Student 2", Grade = 50});
            studentService.Create(new Student { CI = 3333, Name = "Test Student 3", Grade = 90});
            studentService.Create(new Student { CI = 4444, Name = "Test Student 4", Grade = 40});

            var controller = new StudentController(studentService);

            // Act
            var result = controller.HasAproved(studentCI);

            // Assert
            Assert.True(result);
        }
    }


}