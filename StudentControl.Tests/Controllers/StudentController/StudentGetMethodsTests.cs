using Microsoft.AspNetCore.Mvc;
using StudentControl.Controllers;
using StudentControl.Models;
using StudentControl.Services;
using StudentControl.Tests.Stubs;
using StudentControl.Tests.Utils;
using Xunit;

namespace StudentControl.Controllers.UnitTests
{

    public class StudentGetMehtodsTests
    {
        [Fact]
        public void GetAll_ListOfStudents_ReturnsAllStudents()
        {
            // Arrange
            //var controller = new StudentController(new StudentServiceStub());
            StudentController controller = StudentUtils.GetTestStudentController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Equal(1111, result[0].CI);
            Assert.Equal(2222, result[1].CI);
            Assert.Equal(3333, result[2].CI);
            Assert.Equal(4444, result[3].CI);
        }

    }
}