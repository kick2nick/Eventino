using Dal.DbContext;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventinoApi
{
    public static class Seed
    {
        public static async Task SeedData(EventinoDbContext dbContext)
        {
            #region create Users
            var IvanIvanov = new User() { UserName = "Ivan Ivanov", Email = "ivan_ivanov@email.com", SubscribedEvents = new List<Event>(), Interests = new List<Interest>() };
            var OlegTarusov = new User() { UserName = "Oleg Tarusov", Email = "oleg_tarusov@email.com", SubscribedEvents = new List<Event>(), Interests = new List<Interest>() };
            var NikolayKuksov = new User() { UserName = "Nikolay Kuksov", Email = "nikolay_kuksov@email.com", SubscribedEvents = new List<Event>(), Interests = new List<Interest>() };
            var VladislavCheliadin = new User() { UserName = "Vladislav Cheliadin", Email = "vladialv_cheliadin@email.com", SubscribedEvents = new List<Event>(), Interests = new List<Interest>() };
            #endregion

            #region cretae Interests
            var sports = new Interest() { Name = "Sports", Events = new List<Event>(), Users = new List<User>() };
            var outdoor = new Interest() { Name = "Outdoor", Events = new List<Event>(), Users = new List<User>() };
            var games = new Interest() { Name = "Games", Events = new List<Event>(), Users = new List<User>() };
            var party = new Interest() { Name = "Party", Events = new List<Event>(), Users = new List<User>() };
            var movie = new Interest() { Name = "Movie", Events = new List<Event>(), Users = new List<User>() };
            var music = new Interest() { Name = "Music", Events = new List<Event>(), Users = new List<User>() };
            var online = new Interest() { Name = "Online", Events = new List<Event>(), Users = new List<User>() };
            var restarant = new Interest() { Name = "Restarant", Events = new List<Event>(), Users = new List<User>() };
            var traning = new Interest() { Name = "Traning", Events = new List<Event>(), Users = new List<User>() };
            var classes = new Interest() { Name = "Classes", Events = new List<Event>(), Users = new List<User>() };
            #endregion

            #region create Events
            var sportEvent = new Event()
            {
                HostId = IvanIvanov.Id,
                Host = IvanIvanov,
                Title = "Test title event",
                Description = "Test Description event",
                Type = EventType.Online,
                Status = EventStatus.Created,
                MaxMembers = 10,
                MinUserAge = 20,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = DateTime.Now,
                Interests = new List<Interest>(),
                Attendees = new List<User>()
            };
            var outdoorEvent = new Event()
            {
                HostId = OlegTarusov.Id,
                Host = OlegTarusov,
                Title = "Test title event",
                Description = "Test Description event",
                Type = EventType.Offline,
                Status = EventStatus.InProgress,
                MaxMembers = 5,
                MinUserAge = 30,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = DateTime.Now,
                Interests = new List<Interest>(),
                Attendees = new List<User>()
            };
            var onlineGameEvent = new Event()
            {
                HostId = NikolayKuksov.Id,
                Host = NikolayKuksov,
                Title = "Test title event",
                Description = "Test Description event",
                Type = EventType.Online,
                Status = EventStatus.Completed,
                MaxMembers = 100,
                MinUserAge = 25,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = DateTime.Now,
                Interests = new List<Interest>(),
                Attendees = new List<User>()
            };
            var partyEvent = new Event()
            {
                HostId = VladislavCheliadin.Id,
                Host = VladislavCheliadin,
                Title = "Test title event",
                Description = "Test Description event",
                Type = EventType.Offline,
                Status = EventStatus.Canceled,
                MaxMembers = 3,
                MinUserAge = 40,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = DateTime.Now,
                Interests = new List<Interest>(),
                Attendees = new List<User>()
            };
            #endregion

            #region friendship
            var friends1 = new Friendship() { User1 = IvanIvanov, User2 = OlegTarusov };
            var friends2 = new Friendship() { User1 = NikolayKuksov, User2 = VladislavCheliadin };
            #endregion

            #region add events and interests to users
            IvanIvanov.SubscribedEvents.Add(outdoorEvent);
            IvanIvanov.SubscribedEvents.Add(onlineGameEvent);
            IvanIvanov.SubscribedEvents.Add(partyEvent);

            OlegTarusov.SubscribedEvents.Add(sportEvent);
            OlegTarusov.SubscribedEvents.Add(onlineGameEvent);
            OlegTarusov.SubscribedEvents.Add(partyEvent);

            NikolayKuksov.SubscribedEvents.Add(sportEvent);
            NikolayKuksov.SubscribedEvents.Add(outdoorEvent);
            NikolayKuksov.SubscribedEvents.Add(partyEvent);

            VladislavCheliadin.SubscribedEvents.Add(sportEvent);
            VladislavCheliadin.SubscribedEvents.Add(outdoorEvent);
            VladislavCheliadin.SubscribedEvents.Add(onlineGameEvent);

            IvanIvanov.Interests.Add(sports);
            OlegTarusov.Interests.Add(outdoor);
            NikolayKuksov.Interests.Add(games);
            VladislavCheliadin.Interests.Add(party);
            #endregion

            #region add events and users to interests
            sports.Users.Add(IvanIvanov);
            outdoor.Users.Add(IvanIvanov);
            games.Users.Add(IvanIvanov);
            party.Users.Add(IvanIvanov);

            sports.Events.Add(sportEvent);
            outdoor.Events.Add(outdoorEvent);
            online.Events.Add(onlineGameEvent);
            games.Events.Add(onlineGameEvent);
            party.Events.Add(partyEvent);
            #endregion

            #region add users and interstst to events
            sportEvent.Interests.Add(sports);
            outdoorEvent.Interests.Add(outdoor);
            onlineGameEvent.Interests.Add(online);
            onlineGameEvent.Interests.Add(games);
            partyEvent.Interests.Add(party);

            sportEvent.Attendees.Add(OlegTarusov);
            outdoorEvent.Attendees.Add(IvanIvanov);
            onlineGameEvent.Attendees.Add(OlegTarusov);
            partyEvent.Attendees.Add(OlegTarusov);
            #endregion

            #region add data to db
            await dbContext.AddRangeAsync(sports, outdoor, games, party, movie, music, online, restarant, traning, classes);
            await dbContext.AddRangeAsync(sportEvent, outdoorEvent, onlineGameEvent, partyEvent);
            await dbContext.AddRangeAsync(friends1, friends2);
            await dbContext.SaveChangesAsync();
            #endregion
        }
    }
}