using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopTest.Utilities
{
    public class SqlContext
    {
        public static DbContextOptions<ShopContext> TestDbContextOptions()
        {
            // Create a new service provider to create a new SQL database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            // Create a new options instance using an SQL database and 
            // IServiceProvider that the context should resolve all of its services from.
            var builder = new DbContextOptionsBuilder<ShopContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EshopDbTest;Trusted_Connection=True;MultipleActiveResultSets=true")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;

        }
    }
}
