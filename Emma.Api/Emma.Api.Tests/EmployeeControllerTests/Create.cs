using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emma.Api.Tests.EmployeeControllerTests;

[TestClass]
public class Create : BaseEmployeeControllerTest
{
    [TestMethod]
    public async void ItExists()
    {
        // Act
        var result = await _employeeController.Create(new Employee());
        var okResult = result as CreatedResult;

        // Assert
        Assert.IsNotNull(okResult, $"Expected CreatedResult, got { result.GetType().Name }");
    }

    //[TestMethod]
    //public void ItReturnsTheCorrectEmployee()
    //{
    //    // Arrange
    //    _employeeRepository.Setup(new List<Employee> { _tomHaverford });

    //    // Act
    //    var result = _employeeController.GetById(_tomHaverford.Id) as OkObjectResult;
    //    var actual = result?.Value as Employee;

    //    // Assert
    //    Assert.IsNotNull(actual);
    //    Assert.AreEqual(_tomHaverford, actual);
    //}

    //[TestMethod]
    //public void ItReturns404NotFoundForMissingEmployee()
    //{
    //    // Arrange
    //    _employeeRepository.Setup(new List<Employee> { _tomHaverford });

    //    // Act
    //    var result = _employeeController.GetById(404);

    //    // Assert
    //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    //}
}
