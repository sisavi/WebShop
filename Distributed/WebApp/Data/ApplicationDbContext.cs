using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Account> Account { get; set; }

        public DbSet<Domain.Warehouse> Warehouse { get; set; }

        public DbSet<Domain.Basket> Basket { get; set; }

        public DbSet<Domain.Campaign> Campaign { get; set; }

        public DbSet<Domain.Comment> Comment { get; set; }

        public DbSet<Domain.Category> Category { get; set; }

        public DbSet<Domain.Order> Order { get; set; }

        public DbSet<Domain.Payment> Payment { get; set; }

        public DbSet<Domain.Picture> Picture { get; set; }

        public DbSet<Domain.Price> Price { get; set; }

        public DbSet<Domain.Product> Product { get; set; }

        public DbSet<Domain.ProductInBasket> ProductInBasket { get; set; }

        public DbSet<Domain.ProductInWarehouse> ProductInWarehouse { get; set; }
    }
