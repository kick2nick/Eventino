using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IEventsService
    {
        public Task<Event> GetFullEventAsync(Guid id);
        public Task<IReadOnlyCollection<Event>> GetEventsHostedByCurrentUserIdAsync();
        public Task<IReadOnlyCollection<Event>> GetEventsSubscribedByCurrentUserAsync();
        public Task<IReadOnlyCollection<Guid>> GetCurrentUserFriendsSubscribedToEventAsync(Guid eventId);
        public ValueTask<Guid> CreateEventAsync(Event eventToCreate);
        public Task UpdateEventAsync(Event eventToUpdate);
        public Task SetInterestsAsync(Guid eventId,  IReadOnlyCollection<string> interests);
    }
}
