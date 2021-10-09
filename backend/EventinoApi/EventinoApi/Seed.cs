using Dal.DbContext;
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

        public static async Task SeedInterests(EventinoDbContext dbContext)
        {
            var interests = new List<Interest>()
            {
                new Interest() { Name = "Sports" },
                new Interest() { Name = "Outdoor" },
                new Interest() { Name = "Games" },
                new Interest() { Name = "Party" },
                new Interest() { Name = "Movie" },
                new Interest() { Name = "Music" },
                new Interest() { Name = "Online" },
                new Interest() { Name = "Restarant" },
                new Interest() { Name = "Traning" }, 
                new Interest() { Name = "Classes" }
            };

            await dbContext.AddRangeAsync(interests);
            await dbContext.SaveChangesAsync();
        }
    }
}