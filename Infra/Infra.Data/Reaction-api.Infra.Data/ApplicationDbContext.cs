using Microsoft.EntityFrameworkCore;
using Reaction_api.Domain;

namespace Reaction_api.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Moment> Moments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
            builder.Entity<Moment>().ToTable("Moment");
            builder.Entity<Comment>().ToTable("Comment");
        }
    }
}