using Microsoft.AspNetCore.Mvc;
using VivanInfotech.API.Data;
using VivanInfotech.API.Services;

namespace VivanInfotech.API.Controllers
{
    [ApiController]
    [Route("testimonials")]
    public class TestimonialsController: ControllerBase
    {
        private readonly TestimonialsService _service;

        public TestimonialsController(TestimonialsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpGet("featured")]
        public async Task<IActionResult> Featured() => Ok(await _service.GetFeaturedAsync());
    }
}
