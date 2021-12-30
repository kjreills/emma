using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emma.Api.Tests.EmployeeControllerTests;

[TestClass]
public class Delete : BaseEmployeeControllerTest
{
    [TestMethod]
    public async Task ItExists()
    {
        // Act
        var result = await _employeeController.Delete(1);
        var okResult = result as OkResult;

        // Assert
        Assert.IsNotNull(okResult, $"Expected OkResult, got { result.GetType().Name }");
    }

    [TestMethod]
    public async Task ItDeletes()
    {
        // Arrange
        _employeeRepository.Setup(new List<Employee> { _tomHaverford });

        // Act
        var result = await _employeeController.Delete(_tomHaverford.Id) as OkResult;

        var dbRecord = await _employeeRepository.GetById(_tomHaverford.Id);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(dbRecord.HasNoValue);
    }
}
