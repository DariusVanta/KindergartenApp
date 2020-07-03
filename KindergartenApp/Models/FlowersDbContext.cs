using Microsoft.EntityFrameworkCore;

namespace KindergartenApp.Models
{
    public class FlowersDbContext : DbContext
    {
        public FlowersDbContext(DbContextOptions<FlowersDbContext> options)
            : base(options)
    {
    }

    public DbSet<Flower> Flowers { get; set; }
}
}
