using VivanInfotech.API.Models;
using VivanInfotech.API.Repositories;

namespace VivanInfotech.API.Services
{
    public class TechnologiesService
    {
        private readonly IRepository _repo;

        public TechnologiesService(IRepository repo)
        {
            _repo = repo;
        }
        public Task<List<Technology>> GetAllAsync()
        => _repo.GetAllAsync<Technology>();
    }
}
