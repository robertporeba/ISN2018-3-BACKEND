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

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            
        }
    }
}
