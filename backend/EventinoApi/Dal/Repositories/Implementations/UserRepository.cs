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
        private readonly DbSet<User> _users;
        public UserRepository(EventinoDbContext context) : base(context)
        {
            _users = Context.Users;
        }

        public async Task AddFriendAsync(Guid userId, Guid friendId)
        {
            var user1 = await Context.Users.Include(s => s.Friendships).FirstOrDefaultAsync(s => s.Id == userId);
            var user2 = await Context.Users.Include(s => s.Friendships).FirstOrDefaultAsync(s => s.Id == friendId);
            _ = user1 ?? throw new UserNotFoundException(userId.ToString());
            _ = user2 ?? throw new UserNotFoundException(friendId.ToString());

            if (user1.Friendships.Any(s => s.User2.Id == friendId) || user2.Friendships.Any(s => s.User2.Id == userId))
            {
                throw new NotImplementedException();
            }

            Context.Set<Friendship>().Add(new Friendship() { User1 = user1, User2 = user2 });
            Context.Set<Friendship>().Add(new Friendship() { User1 = user2, User2 = user1 });
            await Context.SaveChangesAsync();
        }

        public async Task DeleteFriendAsync(Guid userId, Guid friendId)
        {
            var user = await Context.Users.Include(s => s.Friendships).FirstOrDefaultAsync(s => s.Id == userId);
            var friend = await Context.Users.Include(s => s.Friendships).FirstOrDefaultAsync(s => s.Id == friendId);
            _ = user ?? throw new UserNotFoundException(userId.ToString());
            _ = friend ?? throw new UserNotFoundException(friendId.ToString());

            if (!user.Friendships.Any(s => s.User2.Id == friendId) || !friend.Friendships.Any(s => s.User2.Id == userId))
            {
                throw new NotImplementedException();
            }

            Context.Set<Friendship>().Remove(user.Friendships.First(s => s.User2.Id == friend.Id));
            Context.Set<Friendship>().Remove(friend.Friendships.First(s => s.User2.Id == user.Id));
            Context.SaveChanges();
        }

        public async Task<IReadOnlyCollection<Guid>> GetUserFriendsAsync(Guid userId)
        {
            return await Context.Set<Friendship>()
                .Where(s => s.User1.Id == userId)
                .Select(s => s.User2.Id)
                .ToListAsync();
        }
    }
}
