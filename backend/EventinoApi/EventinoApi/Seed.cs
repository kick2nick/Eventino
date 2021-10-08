using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EventinoApi
{
    public static class Seed
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            var users = new List<User>()
            {
                new User() { UserName = "Ivan Ivanov", Email = "ivan_ivanov@email.com" },
                new User() { UserName = "Oleg Tarusov", Email = "oleg_tarusov@email.com" },
                new User() { UserName = "Nikolay Kuksov", Email = "nikolay_kuksov@email.com" },
                new User() { UserName = "Vladislav Cheliadin", Email = "vladialv_cheliadin@email.com" },
            };

            users.ForEach(async u => await userManager.CreateAsync(u, "12345678Aa@"));
        }
    }
}