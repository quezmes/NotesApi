using Microsoft.EntityFrameworkCore;
using NotesApi.Contexts;
using NotesApi.Models.Database;

namespace NotesApi.Repositories
{
    public interface INoteRepository : IRepository<Note>{ 
        Task<Note?> GetByTitleAsync(string title);
    }
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _db;

        public NoteRepository(NotesDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Note entity)
        {
          await _db.Notes.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
           var toDelete = await _db.Notes.FirstOrDefaultAsync(x=> x.Id == id);
            if (toDelete != null) _db.Notes.Remove(toDelete);
        }

        public async Task<ICollection<Note>> GetAllAsync() => await _db.Notes.ToListAsync();

        public async Task<Note?> GetByIdAsync(string id) => await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);

        public Task<Note?> GetByTitleAsync(string title)
        => _db.Notes.FirstOrDefaultAsync(x => x.Title == title);

        public async Task<Note?> UpdateAsync(Note entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existNote = await _db.Set<Note>().FindAsync(entity.Id);

            if (existNote is null)
            {
                return null;
            }

            _db.Entry(existNote).CurrentValues.SetValues(entity);
            return entity;
        }
    }
}
