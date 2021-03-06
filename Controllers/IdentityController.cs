using mentorship_docker_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mentorship_docker_api.Controllers
{
    [Route("")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly IGuidService _service;
        public IdentityController (IGuidService service,
                                    ILogger<IdentityController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            _logger.LogInformation($"Get request at {DateTime.Now}");
            return await _service.GetMessageAsync();
        }
    }
}
