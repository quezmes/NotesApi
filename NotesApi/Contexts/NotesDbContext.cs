using Microsoft.EntityFrameworkCore;
using NotesApi.Models.Database;

namespace NotesApi.Contexts
{
    public class NotesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<SuperUser> SuperUsers { get; set; }
        //public DbSet<StandardUser> StandardUsers { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Note> Notes { get; set; }
        public NotesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperUser>();
            modelBuilder.Entity<Admin>();
            modelBuilder.Entity<StandardUser>();

            modelBuilder.Entity<User>().HasDiscriminator<UserRoles>(x => x.Role)
                .HasValue<SuperUser>(UserRoles.SuperUser)
                .HasValue<StandardUser>(UserRoles.StandardUser)
                .HasValue<Admin>(UserRoles.Admin)
                .IsComplete(false) ;


            modelBuilder.Entity<User>()
                .HasMany(x => x.Notes)
                .WithOne(y => y.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SuperUser>()
                .HasMany(x => x.Employees)
                .WithOne(y => y.Supervisor)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SuperUser>()
                .HasMany(x => x.ApprovedNotes)
                .WithOne(x => x.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
