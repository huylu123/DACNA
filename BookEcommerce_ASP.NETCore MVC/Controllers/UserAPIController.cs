using ClassLibrary_RepositoryDLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    [Authorize]
    [Route("api/login")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly BookEcommerceContext _context;
        //private readonly IUserRepository _repository;
        /*IUserRepository repository, */
        public UserAPIController(IConfiguration configuration, BookEcommerceContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account _user)
        {
            if (_user.Username != null && _user.Password != null)
            {
                var user = await GetUser(_user.Username, _user.Password);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("id", user.Id.ToString()),
                        new Claim("fullname", user.Fullname),
                        new Claim("role", user.RoleId.ToString()),
                        new Claim("phone", user.Phone),
                        new Claim("address", user.Address)
                    };

                    var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");/*{ StatusCode="404", Status= "Not sucess", Message="Wrong email or password" }*/
                }
            }
            else
            {
                return BadRequest();
            }
        }
        private async Task<Account> GetUser(string email, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(user => user.Username == email && user.Password == password);
        }
    }
}
