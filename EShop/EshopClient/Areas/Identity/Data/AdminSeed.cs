using EshopClient.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopClient.Areas.Identity.Data
{
    public class AdminSeed
    {
        private readonly EshopClientContext _context;
        public AdminSeed(EshopClientContext context)
        {
            _context = context;
        }
        public async void Initialize()
        {
            var admin = new EshopUser()
            {
                UserName = "super@test.dk",
                NormalizedUserName = "super@test.dk",
                Email = "super@test.dk",
                NormalizedEmail = "super@test.dk",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            }

            if (!_context.Users.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<EshopUser>();
                var hashed = password.HashPassword(admin, "P@ssw0rd");
                admin.PasswordHash = hashed;
                var userStore = new UserStore<EshopUser>(_context);
                await userStore.CreateAsync(admin);
                await userStore.AddToRoleAsync(admin, "admin");
            }

            await _context.SaveChangesAsync();
        }
    }
}
