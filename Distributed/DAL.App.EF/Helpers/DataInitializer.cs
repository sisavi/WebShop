using System;
using System.Linq;
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Product = DAL.App.DTO.Product;

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
                    CategoryName = "Bed",
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                },
                new Category()
                {
                    CategoryName = "Book",
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                },
                new Category()
                {
                    CategoryName = "Chairs",
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                },
                new Category()
                {
                    CategoryName = "Tables",
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                },
                new Category()
                {
                    CategoryName = "Other",
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


            var products = new Domain.App.Product[]
            {
                new Domain.App.Product()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    CategoryId = new Guid("00000000-0000-0000-0000-000000000001"),
                    CampaignId = new Guid("00000000-0000-0000-0000-000000000002"),
                    ProductName = "Child Bed",
                    ProductPrice = 20.30,
                    Description = "Comfortable child bed in size 120x80mm"
                },
                new Domain.App.Product()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    CategoryId = new Guid("00000000-0000-0000-0000-000000000002"),
                    ProductName = "How to teach your child to read",
                    ProductPrice = 20.55,
                    Description =
                        "A textbook that can help your child to start reading. Contains funny games and lot of world puzzels"
                },
                new Domain.App.Product()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    CategoryId = new Guid("00000000-0000-0000-0000-000000000001"),
                    ProductName = "Toddler Bed",
                    ProductPrice = 15.30,
                    Description = "Comfortable toddler bed in size 120x80mm"
                },
                new Domain.App.Product()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    CategoryId = new Guid("00000000-0000-0000-0000-000000000001"),
                    ProductName = "Pre-Teen Bed",
                    ProductPrice = 50,
                    Description = "Comfortable child bed in size 180x120mm"
                },
            };
            foreach (var product in products)
            {
                if (!context.Products.Any(l => l.Id == product.Id))
                {
                    context.Products.Add(product);
                }
            }

            context.SaveChanges();
            
            
            var warehouses = new Warehouse[]
            {
                new Warehouse()
                {
                    WarehouseCode= "Lahemaa 55",
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                },
                new Warehouse()
                {
                    WarehouseCode = "Lehe 27",
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                },
                new Warehouse()
                {
                    WarehouseCode = "Lepa 8",
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                },
                
            };
            foreach (var warehouse in warehouses)
            {
                if (!context.Warehouses.Any(l => l.Id == warehouse.Id))
                {
                    context.Warehouses.Add(warehouse);
                }
            }

            context.SaveChanges();
            
            
            
            var productsInWarehouses = new ProductInWarehouse[]
            {
                new ProductInWarehouse()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    WarehouseId = new Guid("00000000-0000-0000-0000-000000000001"),
                    ProductId = new Guid("00000000-0000-0000-0000-000000000001"),
                    Quantity = 1
                },
                new ProductInWarehouse()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    WarehouseId = new Guid("00000000-0000-0000-0000-000000000001"),
                    ProductId = new Guid("00000000-0000-0000-0000-000000000002"),
                    Quantity = 5
                },
                new ProductInWarehouse()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    WarehouseId = new Guid("00000000-0000-0000-0000-000000000002"),
                    ProductId = new Guid("00000000-0000-0000-0000-000000000003"),
                    Quantity = 4
                },
                new ProductInWarehouse()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    WarehouseId = new Guid("00000000-0000-0000-0000-000000000001"),
                    ProductId = new Guid("00000000-0000-0000-0000-000000000004"),
                    Quantity = 10
                },
                
            };
            foreach (var stuff in productsInWarehouses)
            {
                if (!context.ProductInWarehouses.Any(l => l.Id == stuff.Id))
                {
                    context.ProductInWarehouses.Add(stuff);
                }
            }

            context.SaveChanges();
            
            
            var deliveryTypes = new DeliveryType[]
            {
                new DeliveryType()
                {
                    Price = 25,
                    DeliveryTypeName = "DPD Kojuvedu",
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                },
                new DeliveryType()
                {
                    Price = 50,
                    DeliveryTypeName = "UPS kojuvedu",
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                },
                new DeliveryType()
                {
                    Price = 10,
                    DeliveryTypeName = "Pakiautomaat",
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                },
            };
            foreach (var delivery in deliveryTypes)
            {
                if (!context.DeliveryTypes.Any(l => l.Id == delivery.Id))
                {
                    context.DeliveryTypes.Add(delivery);
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