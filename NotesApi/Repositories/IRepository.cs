using Microsoft.EntityFrameworkCore;

namespace NotesApi.Repositories
{
    public interface IRepository<T> where T : class
    { 
        Task<T?> UpdateAsync(T entity);
        Task DeleteAsync(string id);
        Task<T?> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task<ICollection<T>> GetAllAsync();
    }
}
