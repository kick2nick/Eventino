using Dal.DbContext;
using Dal.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private DbSet<User> Users { get => _context.Users; }
        public UserRepository(EventinoDbContext context) : base(context)
        {
            
        }

        public new Task<User> GetById(Guid id)
            => Users.AsNoTracking().Include(u => u.Interests).Where(x => id.Equals(x.Id)).FirstOrDefaultAsync();

        public async Task AddFriendAsync(Guid userId, Guid friendId)
        {
            var user1 = await _context.Users.Include(s => s.Friendships).FirstOrDefaultAsync(s => s.Id == userId);
            var user2 = await _context.Users.Include(s => s.Friendships).FirstOrDefaultAsync(s => s.Id == friendId);
            _ = user1 ?? throw new UserNotFoundException(userId.ToString());
            _ = user2 ?? throw new UserNotFoundException(friendId.ToString());

            if (user1.Friendships.Any(s => s.User2.Id == friendId) || user2.Friendships.Any(s => s.User2.Id == userId))
            {
                throw new NotImplementedException();
            }

            _context.Set<Friendship>().Add(new Friendship() { User1 = user1, User2 = user2 });
            _context.Set<Friendship>().Add(new Friendship() { User1 = user2, User2 = user1 });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFriendAsync(Guid userId, Guid friendId)
        {
            var user = await _context.Users.Include(s => s.Friendships).FirstOrDefaultAsync(s => s.Id == userId);
            var friend = await _context.Users.Include(s => s.Friendships).FirstOrDefaultAsync(s => s.Id == friendId);
            _ = user ?? throw new UserNotFoundException(userId.ToString());
            _ = friend ?? throw new UserNotFoundException(friendId.ToString());

            if (!user.Friendships.Any(s => s.User2.Id == friendId) || !friend.Friendships.Any(s => s.User2.Id == userId))
            {
                throw new NotImplementedException();
            }

            _context.Set<Friendship>().Remove(user.Friendships.First(s => s.User2.Id == friend.Id));
            _context.Set<Friendship>().Remove(friend.Friendships.First(s => s.User2.Id == user.Id));
            _context.SaveChanges();
        }

        public async Task<IReadOnlyCollection<Guid>> GetUserFriendsAsync(Guid userId)
        {
            return await _context.Set<Friendship>()
                .Where(s => s.User1.Id == userId)
                .Select(s => s.User2.Id)
                .ToListAsync();
        }
    }
}
