using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ProductSupplierPrice Join Table
            modelBuilder.Entity<ProductSupplierPrice>()
                .HasKey(p => new { p.ProductId, p.SupplierId });
            modelBuilder.Entity<ProductSupplierPrice>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSupplierPrices);
            modelBuilder.Entity<ProductSupplierPrice>()
                .HasOne(ps => ps.Supplier)
                .WithMany(s => s.ProductSupplierPrices);

            // Seed Data
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                Name = "Level 0"
            },
            new Category
            {
                CategoryId = 2,
                Name = "Level 1",
                ParentCategoryId = 1
            },
            new Category
            {
                CategoryId = 3,
                Name = "Level 2",
                ParentCategoryId = 2
            },
            new Category
            {
                CategoryId = 4,
                Name = "Level 3",
                ParentCategoryId = 3
            },
            new Category
            {
                CategoryId = 5,
                Name = "Level 4",
                ParentCategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Test Product 01",
                CategoryId = 1,
                UnitPrice = 30.0M,
            },
            new Product
            {
                ProductId = 2,
                Name = "Test Product 02",
                CategoryId = 2,
                UnitPrice = 45.0M,
            },
            new Product
            {
                ProductId = 3,
                Name = "Test Product 03",
                CategoryId = 3,
                UnitPrice = 30.5M,
            },
            new Product
            {
                ProductId = 4,
                Name = "Test Product 04",
                CategoryId = 4,
                UnitPrice = 10.0M,
            },
            new Product
            {
                ProductId = 5,
                Name = "Test Product 05",
                CategoryId = 5,
                UnitPrice = 130.0M,
            });
        }

    }
}
