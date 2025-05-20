using Microsoft.AspNetCore.Mvc;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Services;
using StudentControl.Tests.Stubs;
using Xunit;
    
namespace StudentControl.Controllers.UnitTests
{


    public class StudentDeleteMethodsTests
    {
        [Fact]
        public void Delete_ValidStudent_ReturnsDeletedStudent()
        {
            // Arrange
            StudentController controller = new StudentController(new StudentServiceStub());
            int studentId = 1111;

            // Act
            var result = controller.Delete(studentId);
            var studentsCount = controller.GetAll().Count;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Student 1", result.Name);
            Assert.Equal(1111, result.CI);
            Assert.Equal(3, studentsCount);
        }
    }
}