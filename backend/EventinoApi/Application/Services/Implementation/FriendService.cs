using Dal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class FriendService : IFriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly IUserRepository _userRepository;

        public FriendService(ILogger<FriendService> logger, IUserRepository genericRepository)
        {
            _logger = logger;
            _userRepository = genericRepository;
        }

        public Task AddFriendAsync(Guid userId, Guid friendId) => _userRepository.AddFriendAsync(userId, friendId);

        public Task DeleteFriendAsync(Guid userId, Guid friendId) => _userRepository.DeleteFriendAsync(userId, friendId);

        public Task<IReadOnlyCollection<Guid>> GetUserFriendsAsync(Guid userId) => _userRepository.GetUserFriendsAsync(userId);
    }
}