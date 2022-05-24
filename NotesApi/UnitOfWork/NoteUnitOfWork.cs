using NotesApi.Contexts;
using NotesApi.Models.Database;
using NotesApi.Repositories;

namespace NotesApi.UnitOfWork
{
    public class NoteUnitOfWork : IDisposable
    {
        private readonly NotesDbContext _db;
        public IRepository<Note> NoteRepository{ get; set; } 
    
        private readonly IRepository<User> _userRepository;

        public NoteUnitOfWork(NotesDbContext db)
        {
            _db = db;
            NoteRepository = new NoteRepository(db);
            _userRepository = new UserRepository(db);
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
