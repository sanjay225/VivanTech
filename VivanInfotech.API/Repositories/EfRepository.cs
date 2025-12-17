using Microsoft.EntityFrameworkCore;
using VivanInfotech.API.Data;

namespace VivanInfotech.API.Repositories
{
    public class EfRepository: IRepository
    {
        private readonly ApplicationDbContext _db;

        public EfRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class
        => await _db.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
            => await _db.Set<T>().FindAsync(id);

        public async Task<List<T>> FindAsync<T>(Func<T, bool> predicate) where T : class
            => _db.Set<T>().Where(predicate).ToList();

        public async Task AddAsync<T>(T entity) where T : class
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
