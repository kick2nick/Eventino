using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        public Task<User> GetUserByIdAsync(Guid id);
        public Task<User> UpdateUserAsync(User user);
    }
}
