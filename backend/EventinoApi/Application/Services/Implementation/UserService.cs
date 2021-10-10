using Dal;
using Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUserByIdAsync(Guid id)
            => _userRepository.GetById(id);

        public async Task<User> UpdateUserAsync(User userToUpdate)
        {
            var updatedUser = await UpdateFullUserInfoAsync(userToUpdate);

            await _userRepository.Update(updatedUser);
            await _userRepository.SetUserInterests(userToUpdate.Interests.Select(s => s.Name).ToList(), userToUpdate.Id);

            return updatedUser;
        }

        private async Task<User> UpdateFullUserInfoAsync(User updatedUser)
        {
            var user = await _userRepository.GetById(updatedUser.Id);

            user.PhotoUrl = updatedUser.PhotoUrl ?? user.PhotoUrl;
            user.UserName = updatedUser.UserName ?? user.UserName;
            user.NormalizedUserName = updatedUser.UserName?.ToUpper() ?? user.NormalizedUserName;
            user.Email = updatedUser.Email ?? user.Email;
            user.NormalizedEmail = updatedUser.Email?.ToUpper() ?? user.NormalizedEmail;

            return user;
        }
    }
}