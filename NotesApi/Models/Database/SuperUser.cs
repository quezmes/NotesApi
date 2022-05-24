namespace NotesApi.Models.Database
{
    public class SuperUser : User
    {
        public virtual ICollection<StandardUser> Employees { get; set; }
        public virtual ICollection<Note> ApprovedNotes { get; set; }
    }
}
