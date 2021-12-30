using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emma.Api.Tests.EmployeeControllerTests;

[TestClass]
public class GetAll : BaseEmployeeControllerTest
{
    [TestMethod]
    public async Task ItExists()
    {
        // Act
        var result = await _employeeController.GetAll();

        var okResult = result as OkObjectResult;

        // Assert
        Assert.IsNotNull(okResult, $"Expected OkObjectResult, got { result.GetType().Name }");
    }

    [TestMethod]
    public async Task ItReturnsEmployeesFromTheRepository()
    {
        // Arrange
        var expected = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                BirthDate = DateOnly.FromDayNumber(700000),
                HireDate = DateOnly.FromDayNumber(710000),
                FirstName = "Tom",
                LastName = "Haverford",
                Department = _parksAndRec
            },
        };

        _employeeRepository.Setup(expected);

        // Act
        var result = (await _employeeController.GetAll()) as OkObjectResult;
        var actual = result?.Value as IEnumerable<Employee>;

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(1, actual.Count());
        Assert.AreEqual(expected.First(), actual.First());
    }
}
