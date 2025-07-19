using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpGet("dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminDashboard()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            
            return Ok(new { 
                Message = "Welcome to the admin dashboard.",
                User = username,
                Role = role,
                Timestamp = DateTime.Now
            });
        }

        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            return Ok(new { 
                Message = "List of all users (Admin only)",
                Users = new[] { "admin", "user1", "user2" }
            });
        }

        [HttpGet("settings")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetSettings()
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            return Ok(new { 
                Message = "Settings accessible by Admin and User roles",
                YourRole = role
            });
        }
    }
}