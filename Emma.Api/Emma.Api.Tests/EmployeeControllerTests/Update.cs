using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emma.Api.Tests.EmployeeControllerTests;

[TestClass]
public class Update : BaseEmployeeControllerTest
{
    [TestMethod]
    public async Task ItCallsUpdate()
    {
        // Arrange
        _employeeRepository.Setup(new List<Employee> { _tomHaverford });
        var updated = _tomHaverford with { Salary = 60_000 };

        // Act
        var result = (await _employeeController.Update(_tomHaverford.Id, updated)) as OkObjectResult;
        var actual = result?.Value as Employee;

        var dbRecord = await _employeeRepository.GetById(updated.Id);

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(updated, actual);
        Assert.AreEqual(updated, dbRecord);
    }

    [TestMethod]
    public async Task ItReturnsNotFoundForMissingRecords()
    {
        // Arrange
        _employeeRepository.Clear();
        var updated = _tomHaverford with { Salary = 60_000 };

        // Act
        var result = await _employeeController.Update(_tomHaverford.Id, updated);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

    [TestMethod]
    public async Task ItReturnsBadRequestForMismatchingIds()
    {
        // Arrange
        var update = new Employee { Id = 1 };

        // Act
        var result = await _employeeController.Update(2, update);

        // Assert
        Assert.IsInstanceOfType(result, typeof (BadRequestObjectResult));
    }
}
