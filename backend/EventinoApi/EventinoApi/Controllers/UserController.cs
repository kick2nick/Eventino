using Application.Services;
using AutoMapper;
using Domain.Entities;
using EventinoApi.Models.Input;
using EventinoApi.Models.Out;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventinoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<OutUser>> GetCurrentUser()
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            return Ok(_mapper.Map<OutUser>(await _userService.GetUserByIdAsync(userId)));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<OutUser>> GetUserById(Guid id)
        {
            return Ok(_mapper.Map<OutUser>(await _userService.GetUserByIdAsync(id)));
        }

        [HttpPut]
        public async Task<ActionResult<OutUser>> UpdateUserData([FromBody] InputUserDto inputUser)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            if(userId != inputUser.Id)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(inputUser);
            var updatedUser = _mapper.Map<OutUser>(await _userService.UpdateUserAsync(user));
            return Ok(updatedUser);
        }
    }
}
