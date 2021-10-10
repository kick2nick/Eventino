using Dal.DbContext;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventinoApi
{
    public static class Seed
    {
        public static async Task SeedData(EventinoDbContext dbContext, UserManager<User> userManager)
        {
            #region create Users
            var IvanIvanov = new User() { UserName = "Ivan Ivanov", Email = "ivan_ivanov@email.com", SubscribedEvents = new List<Event>(), Interests = new List<Interest>() };
            var OlegTarusov = new User() { UserName = "Oleg Tarusov", Email = "oleg_tarusov@email.com", SubscribedEvents = new List<Event>(), Interests = new List<Interest>() };
            var NikolayKuksov = new User() { UserName = "Nikolay Kuksov", Email = "nikolay_kuksov@email.com", SubscribedEvents = new List<Event>(), Interests = new List<Interest>() };
            var VladislavCheliadin = new User() { UserName = "Vladislav Cheliadin", Email = "vladialv_cheliadin@email.com", SubscribedEvents = new List<Event>(), Interests = new List<Interest>() };
            await userManager.CreateAsync(IvanIvanov, "12345678@aA");
            await userManager.CreateAsync(OlegTarusov, "12345678@aA");
            await userManager.CreateAsync(NikolayKuksov, "12345678@aA");
            await userManager.CreateAsync(VladislavCheliadin, "12345678@aA");
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
            var laTomatina = new Event()
            {
                HostId = IvanIvanov.Id,
                Host = IvanIvanov,
                Title = "La tomatina",
                Description = "Приглашаем на ежегодный праздник, проходящий в последнюю среду августа в испанском городе Буньоль, автономное сообщество Валенсия. Десятки тысяч участников приезжают из разных стран для участия в битве, «оружием» в которой служат помидоры.",
                Type = EventType.Offline,
                Status = EventStatus.Created,
                MaxMembers = 1000,
                MinUserAge = 10,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = new DateTime(2022, 6, 13, 14, 30, 30),
                Interests = new List<Interest>(),
                Attendees = new List<User>(),
                PhotoUrl = "cc2da6cc-086c-417b-8f1a-9e1ce14671ff.jpg",
                Place = "Spain"
            };
            var bycicleEvent = new Event()
            {
                HostId = OlegTarusov.Id,
                Host = OlegTarusov,
                Title = "Cycling Thursday",
                Description = "Bristol Thursday Old Time Cyclists meets every Thursday, and on occasional Tuesdays, for a ride from Bristol to lunch and back.",
                Type = EventType.Offline,
                Status = EventStatus.Created,
                MaxMembers = 10,
                MinUserAge = 30,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = DateTime.Now.AddDays(2).AddHours(14),
                Interests = new List<Interest>(),
                Attendees = new List<User>(),
                Place = "Bristol",
                PhotoUrl = "53046036-8755-46f9-beb1-291be1fe75f6.jpg"
            };
            var footballEvent = new Event()
            {
                HostId = NikolayKuksov.Id,
                Host = NikolayKuksov,
                Title = "Football game",
                Description = "A friendly Football match is to be held between junior team of our school and that of May flower school. ",
                Type = EventType.Offline,
                Status = EventStatus.Created,
                MaxMembers = 100,
                MinUserAge = 15,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = DateTime.Now.AddDays(7).AddHours(1),
                Interests = new List<Interest>(),
                Attendees = new List<User>(),
                PhotoUrl = "1b6b3189-5abe-41b9-a9aa-1515d618762b.jpg"
            };
            var partyEvent = new Event()
            {
                HostId = VladislavCheliadin.Id,
                Host = VladislavCheliadin,
                Title = "Birthday party",
                Description = "I hope you all are doing fine. I have something very special to tell you which is that my birthday is on its way and I want you all to come over to my place.",
                Type = EventType.Offline,
                Status = EventStatus.Canceled,
                MaxMembers = 20,
                MinUserAge = 18,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = DateTime.Now.AddHours(14),
                Interests = new List<Interest>(),
                Attendees = new List<User>(),
                Place = "Cooolest bar",
                PhotoUrl = "84e06d11-3401-4bd1-abcf-aee900cec085.jpg"
            };
            var musicEvent = new Event()
            {
                HostId = IvanIvanov.Id,
                Host = IvanIvanov,
                Title = "My favorite opera",
                Description = "Just listen it!",
                Type = EventType.Offline,
                Status = EventStatus.Created,
                MaxMembers = 100,
                MinUserAge = 10,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = new DateTime(2021, 2, 13, 14, 30, 30),
                Interests = new List<Interest>(),
                Attendees = new List<User>(),
                PhotoUrl = "c18c2a3a-904d-4e6f-b538-56eee1b6cfd5.jpg",
                Place = "САНКТЪ-ПЕТЕРБУРГЪ ОПЕРА"
            };
            var trainingEvent = new Event()
            {
                HostId = OlegTarusov.Id,
                Host = OlegTarusov,
                Title = "Soft skills training",
                Description = "There is much debate at present surrounding the importance of soft skills and their importance in the work place. What’s clear is that while much investment is made in technical proficiency (so called “hard skills”), this only accounts for 20% of job success. The remaining 80% depends on how well we interact with other people – commonly called “soft skills”. Clearly there is nothing “soft” about anything that represents 80% of job success. Renowned organizations such as Google and LinkedIn have drawn the same conclusion and are changing their recruitment and training strategies accordingly. Does your organization recognize the importance of investing in soft skills courses?",
                Type = EventType.Online,
                Status = EventStatus.Created,
                MaxMembers = 20,
                MinUserAge = 20,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                StartDate = DateTime.Now.AddDays(2).AddHours(6),
                Interests = new List<Interest>(),
                Attendees = new List<User>(),
                Place = "Microsoft Teams",
                PhotoUrl = "4c8bcac6-cb85-43d2-9b86-60d645a1dfc0.png"
            };
            #endregion

            #region friendship
            var friends1 = new Friendship() { User1 = IvanIvanov, User2 = OlegTarusov };
            var friends2 = new Friendship() { User1 = NikolayKuksov, User2 = VladislavCheliadin };
            #endregion

            #region add events and interests to users
            IvanIvanov.SubscribedEvents.Add(bycicleEvent);
            IvanIvanov.SubscribedEvents.Add(footballEvent);
            IvanIvanov.SubscribedEvents.Add(partyEvent);

            OlegTarusov.SubscribedEvents.Add(laTomatina);
            OlegTarusov.SubscribedEvents.Add(footballEvent);
            OlegTarusov.SubscribedEvents.Add(partyEvent);

            NikolayKuksov.SubscribedEvents.Add(laTomatina);
            NikolayKuksov.SubscribedEvents.Add(bycicleEvent);
            NikolayKuksov.SubscribedEvents.Add(partyEvent);

            VladislavCheliadin.SubscribedEvents.Add(laTomatina);
            VladislavCheliadin.SubscribedEvents.Add(bycicleEvent);
            VladislavCheliadin.SubscribedEvents.Add(footballEvent);

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

            sports.Events.Add(laTomatina);
            outdoor.Events.Add(bycicleEvent);
            online.Events.Add(footballEvent);
            games.Events.Add(footballEvent);
            party.Events.Add(partyEvent);
            #endregion

            #region add users and interstst to events
            laTomatina.Interests.Add(sports);
            bycicleEvent.Interests.Add(outdoor);
            footballEvent.Interests.Add(online);
            footballEvent.Interests.Add(games);
            partyEvent.Interests.Add(party);
            trainingEvent.Interests.Add(traning);
            musicEvent.Interests.Add(music);

            laTomatina.Attendees.Add(OlegTarusov);
            bycicleEvent.Attendees.Add(IvanIvanov);
            footballEvent.Attendees.Add(OlegTarusov);
            partyEvent.Attendees.Add(OlegTarusov);
            #endregion

            #region add data to db
            await dbContext.AddRangeAsync(sports, outdoor, games, party, movie, music, online, restarant, traning, classes);
            await dbContext.AddRangeAsync(laTomatina, bycicleEvent, footballEvent, partyEvent, musicEvent, trainingEvent);
            await dbContext.AddRangeAsync(friends1, friends2);
            await dbContext.SaveChangesAsync();
            #endregion
        }
    }
}