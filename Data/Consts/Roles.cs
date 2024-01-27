using Microsoft.AspNetCore.Identity;

namespace Books.Data.Consts
{
    public static class Roles
    {
        public static async Task AddAdminRole(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }
        public static async Task AddUserRole(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }
    }
}