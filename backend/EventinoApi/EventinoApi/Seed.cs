using Dal.DbContext;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventinoApi
{
    public static class Seed
    {
        public static async Task SeedData(UserManager<User> userManager, EventinoDbContext dbContext)
        {
            await SeedUsers(userManager);
            await SeedInterests(dbContext);
            await SeedEvents(dbContext);
        }

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

        public static async Task SeedEvents(EventinoDbContext dbContext)
        {
            var user1 = dbContext.Set<User>().FirstOrDefault(x => x.UserName.Equals("Ivan Ivanov"));
            var user2 = dbContext.Set<User>().FirstOrDefault(x => x.UserName.Equals("Oleg Tarusov"));

            var events = new List<Event>()
            {
                new Event() 
                {
                    HostId = user1.Id,
                    Host = user1,
                    Title = "Test title event",
                    Description = "Test Description event",
                    Type = EventType.Online,
                    Status = EventStatus.Created,
                    MaxMembers = 10,
                    MinUserAge = 20,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    StartDate = DateTime.Now
                },
                new Event()
                {
                    HostId = user2.Id,
                    Host = user2,
                    Title = "Test title event",
                    Description = "Test Description event",
                    Type = EventType.Offline,
                    Status = EventStatus.InProgress,
                    MaxMembers = 5,
                    MinUserAge = 30,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    StartDate = DateTime.Now
                },
                new Event()
                {
                    HostId = user1.Id,
                    Host = user1,
                    Title = "Test title event",
                    Description = "Test Description event",
                    Type = EventType.Online,
                    Status = EventStatus.Completed,
                    MaxMembers = 100,
                    MinUserAge = 25,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    StartDate = DateTime.Now
                },
                new Event()
                {
                    HostId = user2.Id,
                    Host = user2,
                    Title = "Test title event",
                    Description = "Test Description event",
                    Type = EventType.Offline,
                    Status = EventStatus.Canceled,
                    MaxMembers = 3,
                    MinUserAge = 40,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    StartDate = DateTime.Now
                },
            };

            await dbContext.AddRangeAsync(events);
            await dbContext.SaveChangesAsync();
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