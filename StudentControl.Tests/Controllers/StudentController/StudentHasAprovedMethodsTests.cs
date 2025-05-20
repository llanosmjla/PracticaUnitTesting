using Microsoft.AspNetCore.Mvc;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Services;
using StudentControl.Tests.Stubs;
using Xunit;

namespace StudentControl.Controllers.UnitTests
{

    public class StudentHasAprovedMethodsTests
    {
        [Fact]
        public void HasAproved_ValidStudent_ReturnsTrue()
        {
            // Arrange
            StudentController controller = new StudentController(new StudentServiceStub());
            var studentCI = 1111;

            // Act
            var result = controller.HasAproved(studentCI);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result);
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
            Assert.NotNull(result);
            Assert.Equal(false, result);
        }
    }


}