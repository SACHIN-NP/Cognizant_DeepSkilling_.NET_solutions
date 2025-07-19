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
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (IsValidUser(model))
            {
                var token = GenerateJwtToken(model.Username);
                return Ok(new { Token = token, Message = "Login successful" });
            }
            return Unauthorized(new { Message = "Invalid username or password" });
        }

        private bool IsValidUser(LoginModel model)
{
    // Support multiple users
    var validUsers = new Dictionary<string, string>
    {
        { "admin", "password123" },
        { "user", "userpass" }
    };
    
    return validUsers.ContainsKey(model.Username) && 
           validUsers[model.Username] == model.Password;
}

private string GenerateJwtToken(string username)
{
    var role = GetUserRole(username); // Get role based on username
    
    var claims = new[]
    {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.NameIdentifier, "1"),
        new Claim(ClaimTypes.Role, role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(
            Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
        signingCredentials: creds);

    return new JwtSecurityTokenHandler().WriteToken(token);
}

private string GetUserRole(string username)
{
    // Simple role assignment - in real app, get from database
    return username switch
    {
        "admin" => "Admin",
        "user" => "User",
        _ => "User"
    };
}
    }
}