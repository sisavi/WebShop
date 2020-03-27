using System;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<Account> Accounts { get; set; } = default!;

        public DbSet<Basket> Baskets { get; set; } = default!;

        public DbSet<Campaign> Campaigns { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<Picture> Pictures { get; set; } = default!;
        public DbSet<Price> Prices { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductInBasket> ProductInBaskets { get; set; } = default!;
        public DbSet<ProductInWarehouse> ProductInWarehouses { get; set; } = default!;
        public DbSet<Warehouse> Warehouses { get; set; } = default!;
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}