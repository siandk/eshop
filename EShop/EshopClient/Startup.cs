using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using EshopClient.Areas.Identity.Data;
using EshopClient.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using ServiceLayer.ShopService.Concrete;
using ServiceLayer.ShopService.Interfaces;

namespace EshopClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // DBContext & Services
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EshopDbContext")));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Identity
            services.AddAuthorization(options =>
            {
                options.AddPolicy("isAdmin", policy => policy.RequireRole("admin"));
            });
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin", "isAdmin");
            });
            services.AddTransient<AdminSeed>();

            // Cache & Session
            services.AddMemoryCache();
            services.AddSession();


            // Extras
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopCenter
            });
            services.AddMiniProfiler(options =>
            {
                options.PopupShowTimeWithChildren = true;
            })
            .AddEntityFramework();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AdminSeed adminSeed)
        {
            adminSeed.Initialize();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseMiniProfiler();
            app.UseNToastNotify();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
