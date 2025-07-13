using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyFirstWebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyFirstWebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("generate-token")]
        public ActionResult<LoginResponse> GenerateToken()
        {
            var token = GenerateJSONWebToken(1, "Admin");
            return Ok(new LoginResponse
            {
                Token = token,
                Username = "admin",
                Role = "Admin",
                ExpiresAt = DateTime.Now.AddMinutes(10)
            });
        }

        [HttpGet("generate-token-short")]
        public ActionResult<LoginResponse> GenerateTokenShort()
        {
            var token = GenerateJSONWebToken(1, "Admin", 2);
            return Ok(new LoginResponse
            {
                Token = token,
                Username = "admin",
                Role = "Admin",
                ExpiresAt = DateTime.Now.AddMinutes(2)
            });
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            // Simple, hardcoded authentication for demonstration
            if (request.Username == "admin" && request.Password == "admin123")
            {
                var token = GenerateJSONWebToken(1, "Admin");
                return Ok(new LoginResponse
                {
                    Token = token,
                    Username = "admin",
                    Role = "Admin",
                    ExpiresAt = DateTime.Now.AddMinutes(10)
                });
            }
            return Unauthorized("Invalid username or password");
        }

        // ====== POC Token Generator ======
        // Uncomment the method below to enable the POC token generator endpoint.
        // Comment it out to disable access to this endpoint.

        [HttpGet("generate-token-poc")]
        public ActionResult<LoginResponse> GenerateTokenPOC()
        {
            var token = GenerateJSONWebToken(2, "POC");
            return Ok(new LoginResponse
            {
                Token = token,
                Username = "poc_user",
                Role = "POC",
                ExpiresAt = DateTime.Now.AddMinutes(10)
            });
        }

        // ==================================

        private string GenerateJSONWebToken(int userId, string userRole, int expirationMinutes = 10)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret_that_is_long_enough_for_security"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
