using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventinoApi
{
    public static class Seed
    {
        public static async Task SeedUsers(UserManager<User> userManager)
        {
            var users = new List<User>()
            {
                new User() { UserName = "Ivan Ivanov", Email = "ivan_ivanov@email.com" },
                new User() { UserName = "Oleg Tarusov", Email = "oleg_tarusov@email.com" },
                new User() { UserName = "Nikolay Kuksov", Email = "nikolay_kuksov@email.com" },
                new User() { UserName = "Vladislav Cheliadin", Email = "vladialv_cheliadin@email.com" },
            };
            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "12345678Aa@");
            }
        }
    }
}