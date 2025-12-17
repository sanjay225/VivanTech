namespace VivanInfotech.API.Repositories
{
    public interface IRepository
    {
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<T?> GetByIdAsync<T>(int id) where T : class;
        Task<List<T>> FindAsync<T>(Func<T, bool> predicate) where T : class;

        Task AddAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
