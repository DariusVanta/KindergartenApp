//using Microsoft.EntityFrameworkCore;

//namespace KindergartenApp.Models
//{
//    public class ChildrenDbContext: DbContext
//    {
//        public ChildrenDbContext(DbContextOptions<ChildrenDbContext> options)
//            : base(options)
//        {
//        }
//        public DbSet<Child> Children{ get; set; }
//        public DbSet<Kindergarten> Kindergardens { get; set; }
//        public DbSet<User> Users { get; set; }
//        public DbSet<UserKindergarten> UserKindergartens { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<UserKindergarten>()
//                .HasKey(c => new { c.UserId, c.KindergardenId });
//        }
//    }
//}
