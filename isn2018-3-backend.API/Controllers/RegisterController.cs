using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly UserManager<IdentityUser> _userManager;
        public RegisterController(SignInManager<IdentityUser> signInManager, IConfiguration config, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _config = config;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserModel registerModel)
        {
            IActionResult response = BadRequest(new { Error = "Undefined error" });
            var existingUser = await _userManager.FindByEmailAsync(registerModel.Email);

            if (existingUser != null)
            {
                response = BadRequest(new { Error = "User already exist" });
                return response;
            }

            var newUser = new IdentityUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Email,
            };

            var createdUser = await _userManager.CreateAsync(newUser, registerModel.Password);

            if (!createdUser.Succeeded)
            {
                response = BadRequest(new { Error = createdUser.Errors.Select(x => x.Description)});
                return response;
            }

            existingUser = await _userManager.FindByEmailAsync(registerModel.Email);
            var userRole = await _userManager.AddToRoleAsync(existingUser, registerModel.Type);

            if (!userRole.Succeeded)
            {
                response = BadRequest(new { Error = "Can't create user with role "+ registerModel.Type});
                return response;
            }

            return Ok("User created");
        }
    }
}
