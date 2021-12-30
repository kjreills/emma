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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogDebug("{Method} was called", nameof(GetAll));

            return Ok(await _employeeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogDebug("{Method} was called", nameof(GetById));

            var employee = await _employeeRepository.GetById(id);

            if (employee.HasValue)
            {
                return Ok(employee.Value);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            _logger.LogDebug("{Method} was called", nameof(Create));

            var createdResult = await _employeeRepository.Create(employee);

            if (createdResult.IsSuccess)
            {
                var created = createdResult.Value;

                return Created($"employees/{created.Id}", created);
            }

            _logger.LogError("Unhandled error case for {Method} in {Controller}: {Error}", nameof(Create), nameof(EmployeeController), createdResult);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest(new Error("The ID in the route did not match the ID in the employee object"));
            }

            var updateResult = await _employeeRepository.Update(employee);

            if (updateResult.IsSuccess)
            {
                return Ok(updateResult.Value);
            }

            if (updateResult.Error == RepositoryError.NotFound)
            {
                return NotFound();
            }

            _logger.LogError("Unhandled error case for {Method} in {Controller}: {Error}", nameof(Update), nameof(EmployeeController), updateResult);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.Delete(id);

            return Ok();
        }
    }
}
