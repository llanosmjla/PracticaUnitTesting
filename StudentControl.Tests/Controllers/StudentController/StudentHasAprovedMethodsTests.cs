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
            studentService.Create(new Student { CI = studentCI, Name = "Ana Maria", Grade = 55 });
            studentService.Create(new Student { CI = 2222, Name = "Jose Mesa", Grade = 46 });
            studentService.Create(new Student { CI = 3333, Name = "Luis Martinez", Grade = 78 });
            studentService.Create(new Student { CI = 4444, Name = "Erick Mela", Grade = 90 });

            var controller = new StudentController(studentService);

            // Act
            var result = controller.HasAproved(studentCI);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void HasAproved_ValidStudent_ReturnsFalse_StudentService()
        {
            // Arrange
            int studentCI = 2222;
            var studentService = new StudentService();
            studentService.Create(new Student { CI = 1111, Name = "Ana Maria", Grade = 55 });
            studentService.Create(new Student { CI = studentCI, Name = "Jose Mesa", Grade = 46 });
            studentService.Create(new Student { CI = 3333, Name = "Luis Martinez", Grade = 78 });
            studentService.Create(new Student { CI = 4444, Name = "Erick Mela", Grade = 90 });

            var controller = new StudentController(studentService);

            // Act
            var result = controller.HasAproved(studentCI);

            // Assert
            Assert.False(result);
        }
    }


}