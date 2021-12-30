using Emma.Api.Controllers;
using Emma.Api.Tests.Mocks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Emma.Api.Tests.EmployeeControllerTests;

public class BaseEmployeeControllerTest
{
    protected MockEmployeeRepository _employeeRepository = new();
    protected Mock<ILogger<EmployeeController>> _logger = new();
    protected EmployeeController _employeeController = new(new Mock<ILogger<EmployeeController>>().Object, new Mock<IEmployeeRepository>().Object);

    protected readonly Department _parksAndRec = new()
    {
        Name = "Parks and Recreation",
        Id = 1
    };

    protected readonly Department _sewage = new()
    {
        Name = "Sewage",
        Id = 2
    };

    protected Employee _tomHaverford = new();

    [TestInitialize]
    public void Setup()
    {
        _tomHaverford = new Employee
        {
            Id = 1,
            BirthDate = DateOnly.FromDayNumber(700000),
            HireDate = DateOnly.FromDayNumber(710000),
            FirstName = "Tom",
            LastName = "Haverford",
            Department = _parksAndRec
        };


        _logger = new Mock<ILogger<EmployeeController>>();

        _employeeRepository = new MockEmployeeRepository(new List<Employee> { _tomHaverford });

        _employeeController = new EmployeeController(_logger.Object, _employeeRepository);
    }
}
