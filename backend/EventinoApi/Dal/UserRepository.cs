using Dal.DbContext;
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

        public Task AddFriendAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFriendAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserWithFriendsAsync(Guid userId) =>
            await Context.Set<User>().Include(x => x.Friends).AsNoTracking()
                                     .Where(x => x.Id.Equals(userId))
                                     .FirstOrDefaultAsync();
    }
}
