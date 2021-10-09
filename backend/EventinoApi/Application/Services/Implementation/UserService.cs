using Dal;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public Task<User> GetUserByIdAsync(Guid id)
            => _userRepository.GetById(id);

        public async Task<User> GetUserWithPopulatedInfoAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
