using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<IReadOnlyCollection<Guid>> GetUserFriendsAsync(Guid userId);
        Task AddFriendAsync(Guid userId, Guid friendId);
        Task DeleteFriendAsync(Guid userId, Guid friendId);
        Task SetUserInterests(IReadOnlyCollection<string> interests, Guid userId);
    }
}
