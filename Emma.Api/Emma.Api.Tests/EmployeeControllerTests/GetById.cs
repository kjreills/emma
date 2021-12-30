using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emma.Api.Tests.EmployeeControllerTests;

[TestClass]
public class GetById : BaseEmployeeControllerTest
{
    [TestMethod]
    public async void ItExists()
    {
        // Act
        var result = await _employeeController.GetById(1);
        var okResult = result as OkObjectResult;

        // Assert
        Assert.IsNotNull(okResult, $"Expected OkObjectResult, got { result.GetType().Name }");
    }

    [TestMethod]
    public async void ItReturnsTheCorrectEmployee()
    {
        // Arrange
        _employeeRepository.Setup(new List<Employee> { _tomHaverford });

        // Act
        var result = await _employeeController.GetById(_tomHaverford.Id) as OkObjectResult;
        var actual = result?.Value as Employee;

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(_tomHaverford, actual);
    }

    [TestMethod]
    public async void ItReturns404NotFoundForMissingEmployee()
    {
        // Arrange
        _employeeRepository.Setup(new List<Employee> { _tomHaverford });

        // Act
        var result = await _employeeController.GetById(404);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}
