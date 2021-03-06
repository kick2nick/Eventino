using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventinoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<string>))]
        public async Task<ActionResult> Register([FromBody] InputRegisterInfo registerInfo)
        {
            var user = new User()
            {
                Email = registerInfo.Email,
                UserName = registerInfo.UserName
            };

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded) return BadRequest(result.Errors.Select(s => s.Description));

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Register", new { userId = user.Id, token = token }, Request.Scheme);
            await EmailService.SendConfirmationEmailAsync(user.Email, confirmationLink);

            return Ok("Registration successful. Please confirm email to access app.");
        }

        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<string>))]
        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null) return NotFound();

            var confirmResult = await _userManager.ConfirmEmailAsync(user, token);

            if (confirmResult.Succeeded)
                await _signInManager.SignInAsync(user, false);
            return confirmResult.Succeeded is true ? Redirect("~/Home") : BadRequest(confirmResult.Errors.Select(s => s.Description));
        }
    }
}
