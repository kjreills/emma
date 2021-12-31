using Microsoft.AspNetCore.Mvc;

namespace Emma.Api.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DesignationController : ControllerBase
    {
        private readonly ILogger<DesignationController> _logger;
        private readonly IDesignationRepository _designationRepository;

        public DesignationController(ILogger<DesignationController> logger, IDesignationRepository employeeRepository)
        {
            _logger = logger;
            _designationRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogDebug("{Method} was called", nameof(GetAll));

            return Ok(await _designationRepository.GetAll());
        }
    }
}
