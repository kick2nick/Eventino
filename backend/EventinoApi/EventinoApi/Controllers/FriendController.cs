using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventinoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet]
        [AllowAnonymous] // for testing
        public async Task<IReadOnlyCollection<User>> GetUserFriends(Guid userId)
        {
            return await _friendService.GetUserFriendsAsync(userId);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task AddFriend(Guid userId, Guid friendId)
        {
            await _friendService.AddFriendAsync(userId, friendId);
        }
    }
}
