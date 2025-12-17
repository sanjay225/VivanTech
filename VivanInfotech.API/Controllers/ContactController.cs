using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VivanInfotech.API.Data;
using VivanInfotech.API.Models;
using VivanInfotech.API.Services;

namespace VivanInfotech.API.Controllers
{
    [ApiController]
    [Route("contact")]
    public class ContactController: ControllerBase
    {
        private readonly ContactService _service;
        public ContactController(ContactService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ContactRequest request)
        {
            await _service.SubmitAsync(request);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [Authorize]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            await _service.UpdateStatusAsync(id, status);
            return Ok();
        }
    }
}
