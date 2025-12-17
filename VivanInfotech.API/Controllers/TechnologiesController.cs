using Microsoft.AspNetCore.Mvc;
using VivanInfotech.API.Data;
using VivanInfotech.API.Services;

namespace VivanInfotech.API.Controllers
{
    [ApiController]
    [Route("technologies")]
    public class TechnologiesController: ControllerBase
    {
        private readonly TechnologiesService _service;

        public TechnologiesController(TechnologiesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());
    }
}
