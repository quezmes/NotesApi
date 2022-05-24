namespace NotesApi.Models.Database
{
    public enum UserRoles
    {
        Admin,
        SuperUser,
        StandardUser,
    }
    public abstract  class User
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();
        public String UserName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual UserRoles Role { get; set; }
    }
}
