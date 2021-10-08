using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace EventinoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;

        public LoginController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginInfo loginInfo)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(loginInfo.Email);

            if (user is null)
            {
                return Unauthorized();
            }
            var a = await _signInManager.PasswordSignInAsync(user, loginInfo.Password, false, false);
            return a.Succeeded ? Ok() : Unauthorized();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("LoginInfo")]
        public ActionResult LoginInfo()
        {
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("SignOut")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}