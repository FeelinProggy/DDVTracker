using Microsoft.AspNetCore.Identity;
using System.Security.Policy;

namespace DDVTracker.Models
{
#nullable disable
    public static class IdentityHelper
    {
        /// <summary>
        /// Master role has the highest level of access.
        /// </summary>
        public const string Master = "Master";
        /// <summary>
        /// Admin role has the second highest level of access, cannot affect other admins.
        /// </summary>
        public const string Admin = "Admin";
        /// <summary>
        /// Moderator role has the third highest level of access, cannot affect other moderators.
        /// Purpose is to moderate user activity and content.
        /// </summary>
        public const string Moderator = "Moderator";
        /// <summary>
        /// Registered users are able to access certain areas of the site and save their data, 
        /// unlkike guests that can only view.
        /// </summary>
        public const string User = "User";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
