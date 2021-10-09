using Dal;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class FriendService : IFriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly IUserRepository _genericRepository;

        public FriendService(ILogger<FriendService> logger, IUserRepository genericRepository)
        {
            _logger = logger;
            _genericRepository = genericRepository;
        }

        public async Task AddFriendAsync(Guid userId, Guid friendId) =>
            await _genericRepository.AddFriendAsync(userId, friendId);

        public async Task DeleteFriendAsync(Guid userId, Guid friendId) =>
            await _genericRepository.DeleteFriendAsync(userId, friendId);

        public async Task<IReadOnlyCollection<Guid>> GetUserFriendsAsync(Guid userId)
        {
            var user = await _genericRepository.GetUserWithFriendsAsync(userId);

            return user.FriendIds.ToList().AsReadOnly();
        }
    }
}
