using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeLandia.Data.Models;

namespace ShoeLandia.Data.Configurations
{
    public static class SeedAdminUser
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            Console.WriteLine("Starting role and admin user creation...");

            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                Console.WriteLine($"Role '{roleName}' exists: {roleExist}");

                if (!roleExist)
                {
                    var createResult = await roleManager.CreateAsync(new ApplicationRole(roleName));
                    Console.WriteLine($"Role '{roleName}' creation result: {createResult.Succeeded}");

                    if (!createResult.Succeeded)
                    {
                        foreach (var error in createResult.Errors)
                        {
                            Console.WriteLine($"[Role Error] {error.Description}");
                        }
                        return;
                    }
                }
            }

            string adminEmail = "admin@gmail.com";
            string adminPassword = "Admin1234";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            Console.WriteLine($"Admin user exists: {adminUser != null}");

            if (adminUser == null)
            {
                var newAdmin = new ApplicationUser
                {
                    UserName = adminEmail, 
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                Console.WriteLine("Creating new admin user...");
                var createUserResult = await userManager.CreateAsync(newAdmin, adminPassword);
                Console.WriteLine($"Admin user creation result: {createUserResult.Succeeded}");

                if (createUserResult.Succeeded)
                {
                    var passwordValid = await userManager.CheckPasswordAsync(newAdmin, adminPassword);
                    Console.WriteLine($"Password validation test: {passwordValid}");

                    var addToRoleResult = await userManager.AddToRoleAsync(newAdmin, "Admin");
                    Console.WriteLine($"Adding admin to role result: {addToRoleResult.Succeeded}");

                    if (!addToRoleResult.Succeeded)
                    {
                        foreach (var error in addToRoleResult.Errors)
                        {
                            Console.WriteLine($"[Role Assign Error] {error.Description}");
                        }
                    }
                }
                else
                {
                    foreach (var error in createUserResult.Errors)
                    {
                        Console.WriteLine($"[User Error] {error.Description}");
                    }
                }
            }

            Console.WriteLine("Admin user and roles setup completed.");
        }
    }
}

