using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockTrackingApp.Core.Enums;

namespace StockTrackingApp.DataAccess.EFCore.Seeds
{
    internal static class AdminSeed
    {
        private const string AdminEmail = "ibrahimdeniz24@hotmail.com";
        private const string AdminPassword = "newPassword+0";

        public static async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<StockAppDbContext>();

            dbContextBuilder.UseSqlServer(configuration.GetConnectionString(StockAppDbContext.ConnectionName));

            using StockAppDbContext context = new(dbContextBuilder.Options);
            if (!context.Roles.Any())
            {
                await AddRoles(context);
            }

            if (!context.Users.Any(user => user.Email == AdminEmail))
            {
                await AddAdmin(context);
            }

            await Task.CompletedTask;
        }

        private static async Task AddAdmin(StockAppDbContext context)
        {
            IdentityUser user = new()
            {
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpperInvariant(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpperInvariant(),
                EmailConfirmed = true
            };
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, AdminPassword);
            await context.Users.AddAsync(user);

            var adminRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Admin.ToString())!.Id;

            await context.UserRoles.AddAsync(new IdentityUserRole<string> { UserId = user.Id, RoleId = adminRoleId });



            context.Admins.Add(new Admin
            {
                Status = Status.Added,
                CreatedBy = "Super-Admin",
                CreatedDate = DateTime.Now,
                ModifiedBy = "Super-Admin",
                ModifiedDate = DateTime.Now,
                FirstName = "Admin",
                LastName = "Admin",
                Email = AdminEmail,
                Gender = true,
                //DateOfBirth = new DateTime(2000, 1, 1),
                IdentityId = user.Id,
            });

            await context.SaveChangesAsync();
        }

        private static async Task AddRoles(StockAppDbContext context)
        {
            string[] roles = Enum.GetNames(typeof(Roles));
            for (int i = 0; i < roles.Length; i++)
            {
                if (await context.Roles.AnyAsync(role => role.Name == roles[i]))
                {
                    continue;
                }

                await context.Roles.AddAsync(new IdentityRole(roles[i]));
            }
        }
    }
}
