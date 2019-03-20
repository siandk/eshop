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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EShopDb; Trusted_Connection = True;");
            }
        }
    }
}
