using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventinoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("TestLogin")]
        [AllowAnonymous]
        public async Task<ActionResult> TestLogin(string email, string password)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user is null) return NotFound();
            await _signInManager.SignInAsync(user, false);
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("google")]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Login");
            var authenticationScheme = GoogleDefaults.AuthenticationScheme;

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(authenticationScheme, redirectUrl);

            return new ChallengeResult(authenticationScheme, properties);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, info.AuthenticationProperties.IsPersistent);
            string[] userInfo =
            {
                info.Principal.FindFirst(ClaimTypes.Name).Value,
                info.Principal.FindFirst(ClaimTypes.Email).Value
            };

            if (result.Succeeded)
            {
                return Ok(userInfo);
            }
            else
            {
                User user = new()
                {
                    Id = Guid.NewGuid(),
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Name).Value,
                };

                IdentityResult identResult = await _userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return Ok(userInfo);
                    }
                }
                return BadRequest();
            }
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
            var token = await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Login", new { userId = user.Id, token = token }, Request.Scheme);

            await EmailService.SendConfirmationEmailAsync(user.Email, confirmationLink);
            return Ok("Email with authorization link was sent.");
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
