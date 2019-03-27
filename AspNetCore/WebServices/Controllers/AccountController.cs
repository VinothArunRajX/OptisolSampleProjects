using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebAppServices.DTO;

namespace WebAppServices.Controllers
{
    [EnableCors("WebCorsPolicy")]
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        protected readonly ILogger<AccountController> _logger;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            ILogger<AccountController> logger = null
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

            if (null != logger)
            {
                _logger = logger;
            }
        }

        [HttpPost]
        public async Task<object> Login([FromBody] DtoLogin model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation(string.Format("Login Failed {0}", ModelState));
                return BadRequest(ModelState);
            }
            _logger.LogInformation(string.Format("Login for {0}/{1}", model.Email, model.Password));

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            { 
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                _logger.LogInformation(string.Format("Login Succeed for {0}/{1}", model.Email, model.Password));
                return await GenerateJwtToken(model.Email, appUser);
            }
            else
                _logger.LogInformation(string.Format("Login faild for {0}/{1}", model.Email, model.Password));

            return StatusCode(StatusCodes.Status501NotImplemented, string.Format("Login faild for {0}", model.Email));
         }

        [HttpPost]
        public async Task<object> Register([FromBody] DtoRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return await GenerateJwtToken(model.Email, user);
            }
            if (result.Errors.Count() > 0)
            {
                IdentityError error = result.Errors.FirstOrDefault();
                return StatusCode(StatusCodes.Status501NotImplemented, error.Description);
            }

            throw new ApplicationException("INVALID_REGISTER_ATTEMPT");
        }

        private async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            DtoLoginResponse response = new DtoLoginResponse() { token = new JwtSecurityTokenHandler().WriteToken(token) };
        
            return response;
        }

       
    }
}