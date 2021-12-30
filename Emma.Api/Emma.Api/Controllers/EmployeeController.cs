using Microsoft.AspNetCore.Mvc;

namespace Emma.Api.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> GetAll()
        {
            _logger.LogDebug("{Method} was called", nameof(GetAll));

            return Ok(_employeeRepository.GetAll());
        }

        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogDebug("{Method} was called", nameof(GetById));

            var employee = _employeeRepository.GetById(id);

            if (employee.HasValue)
            {
                return Ok(employee.Value);
            }

            return NotFound();
        }

        public async Task<IActionResult> Create(Employee employee)
        {
            _logger.LogDebug("{Method} was called", nameof(Create));

            return Ok();
        }
    }
}