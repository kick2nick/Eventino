using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Dal
{
    public interface IUserRepository
    {
        Task<User> GetUserWithFriendsAsync(Guid userId);
        Task AddFriendAsync(Guid userId, Guid friendId);
        Task DeleteFriendAsync(Guid userId, Guid friendId);
    }
}
