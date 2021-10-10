using Dal.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Services.Implementation
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly Guid _currentUserId;
        public EventsService(IEventsRepository eventsRepository, IHttpContextAccessor context)
        {
            _eventsRepository = eventsRepository;
            _currentUserId = Guid.Parse(context.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }

        public Task<Event> GetFullEventAsync(Guid id) => 
            _eventsRepository.GetFullEventAsync(id);

        public Task<IReadOnlyCollection<Event>> GetEventsHostedByCurrentUserIdAsync() => 
            _eventsRepository.GetFullEventsHostedByUserId(_currentUserId);

        public Task<IReadOnlyCollection<Event>> GetEventsSubscribedByCurrentUserAsync() => 
            _eventsRepository.GetFullEventsSubscribedByUserId(_currentUserId);

        public Task<IReadOnlyCollection<Guid>> GetCurrentUserFriendsSubscribedToEventAsync(Guid eventId) =>
            _eventsRepository.GetFriendsSubscribedToEvent(_currentUserId, eventId);

        public async ValueTask<Guid> CreateEventAsync(Event eventToCreate)
        {
            await _eventsRepository.Add(eventToCreate);
            var a = await _eventsRepository.FirstOrDefaultAsync(e => e.Created == eventToCreate.Created && e.Title == eventToCreate.Title && e.Description == eventToCreate.Description);
            return a.Id;
        }

        public Task UpdateEventAsync(Event eventToUpdate) =>
            _eventsRepository.Update(eventToUpdate);

        public Task SetInterestsAsync(Guid eventId, IReadOnlyCollection<string> interests) => 
            _eventsRepository.UpdateInterestsAsync(eventId, interests);
    }
}
