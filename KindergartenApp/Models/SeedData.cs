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
                    },
                                        new Flower
                                        {
                                            Name = "Lyly",
                                            Description = "Does not have thorns",
                                            DateAdded = DateTime.UtcNow,
                                            MarketPrice = 12,
                                            FlowerUpkeepDificulty = FlowerUpkeepDifficulty.Easy
                                        }
                );
                context.SaveChanges();
            }

            //using (var context = new ChildrenDbContext(serviceProvider.GetRequiredService<DbContextOptions<ChildrenDbContext>>()))
            using (var context = new KindergartensDbContext(serviceProvider.GetRequiredService<DbContextOptions<KindergartensDbContext>>()))
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
                        ChildrenGroup = ChildrenGroup.Small //,
                      //  KindergartenID = 1
                    },
                    new Child
                    {
                        Name = "Denis-Alexandru Calin",
                        Gender = "Boy",
                        Characterization = "Dynamic and spontaneous",
                        Age = 7.0,
                        Height = 140,
                        Weight = 30.0,
                       ChildrenGroup = ChildrenGroup.Bigger //,
                     //   KindergartenID = 2
                    },
                    new Child
                    {
                        Name = "Eric Nicolae Trasca",
                        Gender = "Boy",
                        Characterization = "Calm and obedient",
                        Age = 6.0,
                        Height = 120,
                        Weight = 22.0,
                       ChildrenGroup = ChildrenGroup.Middle//,
                    //    KindergartenID = 1
                    }

                    //                    new Child
                    //                    {
                    //                        Name = "Ericka-Alexandra Vanta",
                    //                        Gender = "Girl",
                    //                        Characterization = "Dynamic and spontaneous",
                    //                        Age = 2.7,
                    //                        Height = 100,
                    //                        Weight = 13.2,
                    //                        ChildrenGroup = ChildrenGroup.Small,
                    //                        KindergartenID = 1
                    //                    },
                    //new Child
                    //{
                    //    Name = "Denis-Alexandru Calin",
                    //    Gender = "Boy",
                    //    Characterization = "Dynamic and spontaneous",
                    //    Age = 7.0,
                    //    Height = 140,
                    //    Weight = 30.0,
                    //    ChildrenGroup = ChildrenGroup.Bigger,
                    //    KindergartenID = 2
                    //},
                    //new Child
                    //{
                    //    Name = "Eric Nicolae Trasca",
                    //    Gender = "Boy",
                    //    Characterization = "Calm and obedient",
                    //    Age = 6.0,
                    //    Height = 120,
                    //    Weight = 22.0,
                    //    ChildrenGroup = ChildrenGroup.Middle,
                    //    KindergartenID = 1
                    //}
                );
               // context.SaveChanges();
           // }
            //using (var context = new KindergardensDbContext(serviceProvider.GetRequiredService<DbContextOptions<ChildrenDbContext>>()))
            //  using (var context = new ChildrenDbContext(serviceProvider.GetRequiredService<DbContextOptions<ChildrenDbContext>>()))
          //  using (var context = new KindergartensDbContext(serviceProvider.GetRequiredService<DbContextOptions<KindergartensDbContext>>()))
          //  {
                // Look for any Kindergarten 

                //KindergartenId 
                //KindergartenName
                //Address 
                //Capacity 

                //ICollection<Child> Children 
                //IList<UserKindergarten> UserKindergartens 

                if (context.Kindergartens.Any())
                {
                    return;   // Kindergarten DB table has been seeded
                }


                context.Kindergartens.AddRange(
                    new Kindergarten
                    {
                        KindergartenName = "Gradinita Casuta Povestilor",
                        Address = "Str Bucuresti",
                        Capacity = 100,
                    },
                    new Kindergarten
                    {
                        KindergartenName = "Gradinita Casuta Iepurasilor",
                        Address = "Str Parcul Feroviarilor",
                        Capacity = 60,
                    },
                        new Kindergarten
                        {
                            KindergartenName = "Gradinita Casuta Spiridusilor",
                            Address = "Str Rovine",
                            Capacity = 100,
                        }
                );
               // context.SaveChanges();
           // }
          //  using (var context = new KindergartensDbContext(serviceProvider.GetRequiredService<DbContextOptions<KindergartensDbContext>>()))
            //{
                // Look for any Users 

                if (context.Users.Any())
                {
                    return;   // Users DB table has been seeded
                }

                //User tb
                //Id 
                //FirstName 
                //LastName
                //Username
                //Phone
                //Email
                //Password
              //  IList<UserKindergarten> UserKindergatens
                context.Users.AddRange(
                    new User
                    {
                        FirstName = "Alexandra",
                        LastName = "Muresan",
                        Username = "Muralex",
                        Phone = "+40710123456",
                        Email= "alexandra.muresan@kindergartens.com",
                        Password = "Parola 1"
                    },

                    new User
                    {
                        FirstName = "Alexandru",
                        LastName = "Moldovan",
                        Username = "Lexy",
                        Phone = "+40720123456",
                        Email = "alexandru.moldovan@kindergartens.com",
                        Password = "Parola 2"
                    },
                     
                    new User
                     {
                         FirstName = "Gabriel",
                         LastName = "Ibraileanu",
                         Username = "Ibrahim",
                         Phone = "+40730123456",
                         Email = "gabriel.ibraileanu@kindergartens.com",
                         Password = "Parola 3"
                     }
                );
                context.SaveChanges();

            }
        }
    }
}
