using Dal;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Application.Services.Implementation
{
    public class FriendService : IFriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly IAsyncRepository<User> _genericRepository;

        public FriendService(ILogger<FriendService> logger, IAsyncRepository<User> genericRepository)
        {
            _logger = logger;
            _genericRepository = genericRepository;
        }

        public bool AddFriend(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFriend(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Guid> GetUserFriendsIds(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
