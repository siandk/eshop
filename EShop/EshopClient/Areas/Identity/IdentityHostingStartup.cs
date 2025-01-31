﻿using System;
using EshopClient.Areas.Identity.Data;
using EshopClient.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EshopClient.Areas.Identity.IdentityHostingStartup))]
namespace EshopClient.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EshopClientContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EshopClientContextConnection")));

                services.AddDefaultIdentity<EshopUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<EshopClientContext>();
            });
        }
    }
}