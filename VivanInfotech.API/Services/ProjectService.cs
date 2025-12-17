using VivanInfotech.API.Models;
using VivanInfotech.API.Repositories;

namespace VivanInfotech.API.Services
{
    public class ProjectService
    {
        private readonly IRepository _repo;

        public ProjectService (IRepository repo)
        {
            _repo = repo;
        }
        public Task<List<Project>> GetAllAsync()
         => _repo.GetAllAsync<Project>();

        public Task<List<Project>> GetFeaturedAsync()
            => _repo.FindAsync<Project>(x => x.IsFeatured);

        public Task<List<Project>> GetByCategoryAsync(string category)
            => _repo.FindAsync<Project>(x => x.Category == category);

        public Task CreateAsync(Project project)
            => _repo.AddAsync(project);

        public async Task UpdateAsync(int id, Project project)
        {
            project.Id = id;
            await _repo.UpdateAsync(project);
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _repo.GetByIdAsync<Project>(id);
            if (project != null)
                await _repo.DeleteAsync(project);
        }
    }
}
