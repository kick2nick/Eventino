using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IFriendService
    {
        Task<IReadOnlyCollection<User>> GetUserFriendsAsync(Guid userId);
        Task AddFriendAsync(Guid userId);
        Task DeleteFriendAsync(Guid userId);
    }
}
