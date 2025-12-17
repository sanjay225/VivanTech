using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VivanInfotech.API.Data;
using VivanInfotech.API.Models;
using VivanInfotech.API.Services;

namespace VivanInfotech.API.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectsController: ControllerBase
    {
        private readonly ProjectService _service;
        public ProjectsController(ProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
         => Ok(await _service.GetAllAsync());

        [HttpGet("featured")]
        public async Task<IActionResult> Featured()
            => Ok(await _service.GetFeaturedAsync());

        [HttpGet("category/{category}")]
        public async Task<IActionResult> ByCategory(string category)
            => Ok(await _service.GetByCategoryAsync(category));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            await _service.CreateAsync(project);
            return Ok(project);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Project project)
        {
            await _service.UpdateAsync(id, project);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
