using Microsoft.EntityFrameworkCore;

namespace KindergartenApp.Models
{
    public class ChildrenDbContext: DbContext
    {
        public ChildrenDbContext(DbContextOptions<ChildrenDbContext> options)
            : base(options)
        {
        }
        public DbSet<Child> Children{ get; set; }
    }
}
