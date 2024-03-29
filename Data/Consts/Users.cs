﻿using Microsoft.AspNetCore.Identity;

namespace Books.Data.Consts
{
    public static class Users
    {
        public static async Task AddAdminUser(UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser()
            {
                UserName = "Admin@gmail.com",
                Email = "Admin@gmail.com"
            };
            await userManager.CreateAsync(user, "Ba$$am3324");
            await userManager.AddToRolesAsync(user, new List<string>() { "Admin", "User" });
        }
        public static async Task AddUser(UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser()
            {
                UserName = "User@gmail.com",
                Email = "User@gmail.com"
            };
            await userManager.CreateAsync(user, "Ba$$am3324");
            await userManager.AddToRoleAsync(user, "User");
        }
    }
}
