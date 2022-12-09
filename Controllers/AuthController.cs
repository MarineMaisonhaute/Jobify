using AutoMapper;
using Jobify.DBContext;
using Jobify.Dto.User;
using Jobify.Models;
using Jobify.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jobify.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IOptionsSnapshot<JwtSettings> _jwtSettings;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, IOptionsSnapshot<JwtSettings> jwtSettings, IMapper mapper)        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings;
            _mapper = mapper;
        }
        [HttpPost("signup")]

        public async Task<ActionResult> SignUp([FromBody] UserSignUpDto userSignUpDto)
        {
            User user = _mapper.Map<User>(userSignUpDto);

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpDto.Password);
            if (userCreateResult.Succeeded)
            {
                if(userSignUpDto.Role == "Admin")
                {
                    return BadRequest("Admin can't be set");
                }
                var result = await _userManager.AddToRoleAsync(user, userSignUpDto.Role);

                if (result.Succeeded)
                {
                    return Created(string.Empty, string.Empty);
                }                
            }

            return Problem(userCreateResult.Errors.First().Description, null, 400);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == userLoginDto.Email);

            if (user is null)
            {
                return NotFound("L'utilisateur n'existe pas...");
            }
            var userLoginResult = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            if (userLoginResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(new
                {
                    token = GenerateJwt(user, roles)
                });
            }
            return BadRequest("Mot de pass incorrect.");
        }

        [HttpPost("Roles")]
        public async Task<ActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Le rôle doit avoir un nom");
            }

            var newRole = new Role
            {
                Name = roleName,
            };
            var roleResult = await _roleManager.CreateAsync(newRole);

            if (roleResult.Succeeded)
            {
                return Ok();
            }
            return Problem(roleResult.Errors.First().Description, null, 500);
        }

        private string GenerateJwt(User user, IList<string> roles)

        {

            var claims = new List<Claim>

                {

                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),

                    new Claim(ClaimTypes.Name, user.UserName),

                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())

                };



            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));

            claims.AddRange(roleClaims);



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.Value.ExpirationInDays));



            var token = new JwtSecurityToken(

                issuer: _jwtSettings.Value.Issuer,

                audience: _jwtSettings.Value.Issuer,

                claims,

                expires: expires,

                signingCredentials: creds

            );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
