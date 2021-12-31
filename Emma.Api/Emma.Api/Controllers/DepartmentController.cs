using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emma.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentRepository employeeRepository)
        {
            _logger = logger;
            _departmentRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogDebug("{Method} was called", nameof(GetAll));

            return Ok(await _departmentRepository.GetAll());
        }
    }
}
