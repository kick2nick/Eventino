using Dal.DbContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class EventsRepository : GenericRepository<Event>, IEventsRepository
    {
        private readonly IUserRepository _userRepository;

        public EventsRepository(EventinoDbContext dbContext, IUserRepository userRepository) : base(dbContext)
        {
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<Event>> GetFullEventsHostedByUserId(Guid userId)
        {
            return await _context.Set<Event>()
                .Include(s => s.Interests)
                .Include(s => s.Attendees)
                .Where(s => s.HostId == userId).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Event>> GetFullEventsSubscribedByUserId(Guid userId)
        {
            return await _context.Set<Event>()
                .Include(s => s.Interests)
                .Include(s => s.Attendees)
                .Where(s => s.Attendees.Any(s => s.Id == userId))
                .ToListAsync();
        }

        public Task<Event> GetFullEventAsync(Guid id)
        {
            return _context.Set<Event>()
                .Include(s => s.Interests)
                .Include(s => s.Interests)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IReadOnlyCollection<Guid>> GetFriendsSubscribedToEvent(Guid userId, Guid eventId)
        {
            var friends = await _userRepository.GetUserFriendsAsync(userId);

            var subcribers = (await _context.Set<Event>()
                .Include(s => s.Attendees)
                .FirstOrDefaultAsync(s => s.Id == eventId)).Attendees;

            var subscribedFriends = from friend in friends
                                    from subscriber in subcribers
                                    where friend == subscriber.Id
                                    select friend;
            return subscribedFriends.ToList();
        }

        public async Task UpdateInterestsAsync(Guid eventId, IReadOnlyCollection<string> interests)
        {
            var eventToUpdate = await GetFullEventAsync(eventId);

            if (eventToUpdate.Interests is null)
                eventToUpdate.Interests = new Collection<Interest>();
            else
                eventToUpdate.Interests.Clear();

            foreach (var interest in interests)
            {
                var interestEntity = _context.Set<Interest>().FirstOrDefault(s => s.Name == interest);
      
                eventToUpdate.Interests.Add(interestEntity);
            }
            await _context.SaveChangesAsync();
        }
    }
}