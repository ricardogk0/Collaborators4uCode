using Microsoft.EntityFrameworkCore;
using CollaboratorsCRUD.Models;

namespace CollaboratorsCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Collaborator>()
                .HasOne(c => c.Role)
                .WithMany(r => r.Collaborators)
                .HasForeignKey(c => c.IdRole);
        }
    }
}