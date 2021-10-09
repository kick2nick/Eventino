using Application.Services;
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

        [HttpGet("TestLogin")]
        public async Task<ActionResult> TestLogin(string email, string password)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user is null) return NotFound();
            await _signInManager.SignInAsync(user, false);
            return Ok();
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] InputLoginInfo loginInfo)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(loginInfo.Email);

            if (user is null)
            {
                return Unauthorized();
            }
            var token =  await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Login", new { userId = user.Id, token = token }, Request.Scheme);

            await EmailService.SendConfirmationEmailAsync(user.Email, confirmationLink);
            return Ok("Email with authorization link was sended.");
        }

        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index");
            }

            var user = await _signInManager.UserManager.FindByIdAsync(userId);

            if (user is null) return NotFound();

            await _signInManager.SignInAsync(user, false);

            return Ok("Success login.");
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
