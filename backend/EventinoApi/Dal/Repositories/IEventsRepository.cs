using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public interface IEventsRepository : IAsyncRepository<Event>
    {
        public Task<Event> GetFullEventAsync(Guid id);
        public Task<IReadOnlyCollection<Event>> GetFullEventsHostedByUserId(Guid userId);
        public Task<IReadOnlyCollection<Event>> GetFullEventsSubscribedByUserId(Guid userId);
        public Task<IReadOnlyCollection<Guid>> GetFriendsSubscribedToEvent(Guid userId, Guid eventId);
        public Task UpdateInterestsAsync(Guid eventId, IReadOnlyCollection<string> interests);
    }
}
