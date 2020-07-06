using Microsoft.EntityFrameworkCore;

namespace KindergartenApp.Models
{
    public class KindergartensDbContext : DbContext
    {
        public KindergartensDbContext(DbContextOptions<KindergartensDbContext> options)
            : base(options)
        {
           // Children.Add
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Kindergarten> Kindergartens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserKindergarten> UserKindergartens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserKindergarten>()
                .HasKey(c => new { c.UserId, c.KindergardenId });
        }
    }
}