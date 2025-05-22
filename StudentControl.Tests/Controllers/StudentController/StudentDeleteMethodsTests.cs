using Microsoft.AspNetCore.Mvc;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Services;
using StudentControl.Tests.Stubs;
using Xunit;
using Moq;
    
namespace StudentControl.Controllers.UnitTests
{


    public class StudentDeleteMethodsTests
    {
        /*
            Pruebas unitarias usando Mocks con Moq
        */
        [Fact]
        public void Delete_ValidStudent_ReturnsNotFound()
        {
            // Arrange
            int studentCI = 0;
            var studentServiceMock = new Mock<IStudentService>();

            var expectedStudent = new Student { CI = 0, Name = "Not Found", Grade = 0 };

            studentServiceMock
                .Setup(service => service.Delete(studentCI))
                .Returns(expectedStudent);

            var controller = new StudentController(studentServiceMock.Object);

            // Act
            var result = controller.Delete(studentCI);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Not Found", result.Name);
            Assert.Equal(0, result.CI);
            Assert.Equal(0, result.Grade);
        }

        /**
            Pruebas unitarias usando Stubs
        */
        [Fact]
        public void Delete_ValidStudent_ReturnsDeletedStudent()
        {
            // Arrange
            StudentController controller = new StudentController(new StudentServiceStub());
            int studentCI = 1111;

            // Act
            var result = controller.Delete(studentCI);
            var studentsCount = controller.GetAll().Count;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ana Maria", result.Name);
            Assert.Equal(1111, result.CI);
            Assert.Equal(3, studentsCount);
        }
    }
}