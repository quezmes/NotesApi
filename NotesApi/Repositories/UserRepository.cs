using Microsoft.EntityFrameworkCore;
using NotesApi.Contexts;
using NotesApi.Models.Database;

namespace NotesApi.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
    public class UserRepository : IUserRepository
    {
        private readonly NotesDbContext _db;

        public UserRepository(NotesDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(User entity)
        {
            await _db.Users.AddAsync(entity);
        }


        public async Task DeleteAsync(string id)
        {
            var toDelete = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (toDelete != null) _db.Users.Remove(toDelete);
        }

        public async Task<ICollection<User>> GetAllAsync() => await _db.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(string id) => await _db.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User?> UpdateAsync(User entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existNote = await _db.Set<User>().FindAsync(entity.Id);

            if (existNote is null)
            {
                return null;
            }

            _db.Entry(existNote).CurrentValues.SetValues(entity);
            return entity;
        }

    }
}
