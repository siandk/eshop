﻿using DataLayer.Entities;
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

        }

    }
}
