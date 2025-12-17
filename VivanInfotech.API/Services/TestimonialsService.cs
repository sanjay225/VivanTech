using VivanInfotech.API.Models;
using VivanInfotech.API.Repositories;

namespace VivanInfotech.API.Services
{
    public class TestimonialsService
    {
        private readonly IRepository _repo;

        public TestimonialsService(IRepository repo)
        {
            _repo = repo;
        }
        public Task<List<Testimonial>> GetAllAsync() => _repo.GetAllAsync<Testimonial>();

        public Task<List<Testimonial>> GetFeaturedAsync() => _repo.FindAsync<Testimonial>(x => x.IsFeatured);
    }
}
