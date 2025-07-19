using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtMicroservice.Models;

namespace JwtMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("short-token")]
        public IActionResult GenerateShortToken([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "password123")
            {
                var token = GenerateShortJwtToken(model.Username);
                return Ok(new { 
                    Token = token, 
                    Message = "Token valid for 1 minute only",
                    ExpiresAt = DateTime.Now.AddMinutes(1)
                });
            }
            return Unauthorized();
        }

        [HttpGet("protected")]
        [Authorize]
        public IActionResult GetProtectedData()
        {
            return Ok(new { 
                Message = "Access granted!",
                User = User.FindFirst(ClaimTypes.Name)?.Value,
                Timestamp = DateTime.Now
            });
        }

        private string GenerateShortJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1), // 1 minute expiry
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}