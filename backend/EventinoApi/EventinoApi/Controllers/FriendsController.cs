using Application.Services;
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
    public class FriendsController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("{userId}")]
        public async Task<IReadOnlyCollection<Guid>> GetUserFriends([FromRoute] Guid userId)
        {
            return await _friendService.GetUserFriendsAsync(userId);
        }

        [HttpPost("{userId}/{friendId}")]
        public async Task AddFriend([FromRoute] Guid userId, [FromRoute] Guid friendId)
        {
            await _friendService.AddFriendAsync(userId, friendId);
        }

        [HttpDelete("{userId}/{friendId}")]
        public async Task RemoveFriend([FromRoute] Guid userId, [FromRoute] Guid friendId)
        {
            await _friendService.DeleteFriendAsync(userId, friendId);
        }
    }
}