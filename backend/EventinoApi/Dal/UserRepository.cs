using Dal.DbContext;
using Dal.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dal
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EventinoDbContext context) : base(context) { }

        public async Task AddFriendAsync(Guid userId, Guid friendId)
        {
            var user = await GetUserWithFriendsAsync(userId);
            var friend = await GetUserWithFriendsAsync(friendId);

            if (user == null || friend == null) throw new UserNotFoundException();

            user.Friends.Add(friend);
            Context.Update(user);

            await Context.SaveChangesAsync();
        }

        public async Task DeleteFriendAsync(Guid userId, Guid friendId)
        {
            var user = await Context.Set<User>().Include(x => x.Friends).Where(x => x.Id.Equals(userId)).AsNoTracking().FirstOrDefaultAsync();
            var friend = await Context.Set<User>().Include(x => x.Friends).Where(x => x.Id.Equals(friendId)).AsNoTracking().FirstOrDefaultAsync();

            if (user == null || friend == null) throw new UserNotFoundException();

            user.Friends.Remove(friend);
            Context.Update(user);

            await Context.SaveChangesAsync();
        }

        public async Task<User> GetUserWithFriendsAsync(Guid userId) =>
            await Context.Set<User>().Include(x => x.Friends)
                                     .Where(x => x.Id.Equals(userId))
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync();
    }
}
