using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FlowersDbContext(serviceProvider.GetRequiredService<DbContextOptions<FlowersDbContext>>()))
            {
                // Look for any flowers.
                if (context.Flowers.Any())
                {
                    return;   // Flowers DB table has been seeded
                }

                context.Flowers.AddRange(
                    new Flower
                    {
                        Name = "Rose",
                        Description = "Has thorns",
                        DateAdded = DateTime.Now,
                        MarketPrice = 10,
                        FlowerUpkeepDificulty = FlowerUpkeepDifficulty.Medium
                    },
                    new Flower
                    {
                        Name = "Tulip",
                        Description = "Does not have thorns",
                        DateAdded = DateTime.UtcNow,
                        MarketPrice = 15,
                        FlowerUpkeepDificulty = FlowerUpkeepDifficulty.Easy
                    }
                );
                context.SaveChanges();
            }
            using (var context = new ChildrenDbContext(serviceProvider.GetRequiredService<DbContextOptions<ChildrenDbContext>>()))
            {
                // Look for any children.
                if (context.Children.Any())
                {
                    return;   // Children DB table has been seeded
                }

                context.Children.AddRange(
                    new Child
                    {
                        Name = "Ericka-Alexandra Vanta",
                        Gender = "Girl",
                        Characterization = "Dynamic and spontaneous",
                        Age = 2.7,
                        Height = 100,
                        Weight = 13.2,
                        ChildrenGroup = ChildrenGroup.Small
                    },
                    new Child
                    {
                        Name = "Denis-Alexandru Calin",
                        Gender = "Boy",
                        Characterization = "Dynamic and spontaneous",
                        Age = 7.0,
                        Height = 140,
                        Weight = 30.0,
                        ChildrenGroup = ChildrenGroup.Bigger
                    },
                    new Child
                    {
                        Name = "Eric Nicolae Trasca",
                        Gender = "Boy",
                        Characterization = "Calm and obedient",
                        Age = 6.0,
                        Height = 120,
                        Weight = 22.0,
                        ChildrenGroup = ChildrenGroup.Middle
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
