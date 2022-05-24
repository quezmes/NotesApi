namespace NotesApi.Models.Database
{
    public class Note
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual SuperUser ApprovedBy { get; set; }
    }
}
