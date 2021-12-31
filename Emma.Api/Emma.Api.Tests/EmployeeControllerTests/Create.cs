using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emma.Api.Tests.EmployeeControllerTests;

[TestClass]
public class Create : BaseEmployeeControllerTest
{
    [TestMethod]
    public async Task ItExists()
    {
        // Act
        var result = await _employeeController.Create(new Employee());
        var okResult = result as CreatedResult;

        // Assert
        Assert.IsNotNull(okResult, $"Expected CreatedResult, got { result.GetType().Name }");
    }

    [TestMethod]
    public async Task ItCallsCreate()
    {
        // Arrange
        _employeeRepository.Clear();

        var craig = new Employee
        {
            FirstName = "Craig",
            LastName = "Middlebrooks",
            BirthDate = new DateTime(1985, 6, 20),
            HireDate = new DateTime(2004, 4, 1),
            Department = _parksAndRec,
            Designation = _worker,
            Salary = 30_000m
        };

        // Act
        var result = await _employeeController.Create(craig) as CreatedResult;
        var actual = result?.Value as Employee;

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual($"employees/{actual.Id}", result?.Location);
        Assert.AreNotEqual(craig.Id, actual.Id);
        Assert.AreEqual(craig.FirstName, actual.FirstName);
        Assert.AreEqual(craig.LastName, actual.LastName);
        Assert.AreEqual(craig.BirthDate, actual.BirthDate);
        Assert.AreEqual(craig.HireDate, actual.HireDate);
        Assert.AreEqual(craig.Department, actual.Department);
        Assert.AreEqual(craig.Designation, actual.Designation);
        Assert.AreEqual(craig.Salary, actual.Salary);
    }
}
