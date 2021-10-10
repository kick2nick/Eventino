using Dal;
using Dal.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        private readonly IInterestRepository _interestRepository;
        private readonly UserManager<User> _userManager;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository, IInterestRepository interestRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _userRepository = userRepository;
            _interestRepository = interestRepository;
            _userManager = userManager;
        }

        public Task<User> GetUserByIdAsync(Guid id)
            => _userRepository.GetById(id);

        public async Task<User> UpdateUserAsync(User updatedUser)
        {
            await PopulateUserInterestsAsyncAsync(updatedUser);

            updatedUser = await UpdateFullUserInfoAsync(updatedUser);

            await _userManager.UpdateAsync(updatedUser);

            return updatedUser;
        }

        private async Task PopulateUserInterestsAsyncAsync(User user)
        {
            var userInterestIds = user.Interests.Select(i => i.Id).ToArray();
            var interests = await _interestRepository.GetWhere(x => userInterestIds.Contains(x.Id));

            user.Interests = (ICollection<Interest>)interests;
        }

        private async Task<User> UpdateFullUserInfoAsync(User updatedUser)
        {
            var user = await _userRepository.GetById(updatedUser.Id);

            user.PhotoUrl = updatedUser.PhotoUrl ?? user.PhotoUrl;
            user.UserName = updatedUser.UserName ?? user.UserName;
            user.NormalizedUserName = updatedUser.UserName?.ToUpper() ?? user.NormalizedUserName;
            user.Email = updatedUser.Email ?? user.Email;
            user.NormalizedEmail = updatedUser.Email?.ToUpper() ?? user.NormalizedEmail;
            user.Interests = updatedUser.Interests ?? user.Interests;

            return user;
        }
    }
}
