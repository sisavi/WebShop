using System;
using System.Linq;
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    public class DataInitializer
    {
        public static void MigrateDatabase(AppDbContext context)
        {
            context.Database.Migrate();
        }
        public static void DeleteDatabase(AppDbContext context)
        {
            context.Database.EnsureDeleted();
        }
        
        public static void SeedData(AppDbContext context)
        {
            var campaigns = new Campaign[]
            {
                new Campaign()
                {
                    Discount = 25,
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    
                    
                },
                new Campaign()
                {
                    Discount = 50,
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    
                    
                },
                new Campaign()
                {
                    Discount = 10,
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    
                    
                },
            };
            foreach (var campaign in campaigns)
            {
                if (!context.Campaigns.Any(l => l.Id == campaign.Id))
                {
                    context.Campaigns.Add(campaign);
                }
            }
            context.SaveChanges();
            
            var categories = new Category[]
            {
                new Category()
                {
                    CategoryName = "Voodi",
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    
                    
                },
                new Category()
                {
                    CategoryName = "Raamat",
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    
                    
                },
                new Category()
                {
                    CategoryName = "Toolid",
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    
                    
                },
                new Category()
                {
                    CategoryName = "Lauad",
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    
                    
                },
                new Category()
                {
                    CategoryName = "Muu",
                    Id = new Guid("00000000-0000-0000-0000-000000000005"),
                    
                    
                }
            };
            foreach (var category in categories)
            {
                if (!context.Categories.Any(l => l.Id == category.Id))
                {
                    context.Categories.Add(category);
                }
            }
            context.SaveChanges();
            
        }
        
        public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var roles = new (string roleName, string roleDisplayName)[]
            {
                ("user", "User"),
                ("admin", "Admin")
            };

            foreach (var (roleName, roleDisplayName) in roles)
            {
                var role = roleManager.FindByNameAsync(roleName).Result;
                if (role == null)
                {
                    role = new AppRole()
                    {
                        Name = roleName,
                        DisplayName = roleDisplayName
                    };

                    var result = roleManager.CreateAsync(role).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("Role creation failed!");
                    }
                }
            }


            var users = new (string name, string password, string firstName, string lastName, Guid Id)[]
            {
                ("i@leht.com", "MetsaMees.1", "Simo", "Savila", new Guid("00000000-0000-0000-0000-000000000002")),
            };

            foreach (var userInfo in users)
            {
                var user = userManager.FindByEmailAsync(userInfo.name).Result;
                if (user == null)
                {
                    user = new AppUser()
                    {
                        Id = userInfo.Id,
                        Email = userInfo.name,
                        UserName = userInfo.name,
                        FirstName = userInfo.firstName,
                        LastName = userInfo.lastName,
                        EmailConfirmed = true
                    };
                    var result = userManager.CreateAsync(user, userInfo.password).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("User creation failed!");
                    }
                }

                var roleResult = userManager.AddToRoleAsync(user, "admin").Result;
                //roleResult = userManager.AddToRoleAsync(user, "user").Result;

            }
        }

        
    }
}