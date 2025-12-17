using VivanInfotech.API.Models;
using VivanInfotech.API.Repositories;

namespace VivanInfotech.API.Services
{
    public class ContactService
    {
        private readonly IRepository _repo;

        public ContactService (IRepository repo)
        {
            _repo = repo;
        }
        public Task SubmitAsync(ContactRequest request)
        => _repo.AddAsync(request);

        public Task<List<ContactRequest>> GetAllAsync()
            => _repo.GetAllAsync<ContactRequest>();

        public async Task UpdateStatusAsync(int id, string status)
        {
            var req = await _repo.GetByIdAsync<ContactRequest>(id);
            if (req != null)
            {
                req.Status = status;
                await _repo.UpdateAsync(req);
            }
        }
    }
}
