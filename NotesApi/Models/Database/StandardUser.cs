namespace NotesApi.Models.Database
{
    public class StandardUser : User
    {
        public virtual string SupervisorId { get; set; }
        public virtual SuperUser Supervisor { get; set; }

    }
}
