using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            return Ok(new { 
                Message = "This is protected data.",
                User = username,
                Timestamp = DateTime.Now
            });
        }

        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok(new { 
                Message = "This is public data - no authentication required",
                Timestamp = DateTime.Now
            });
        }
    }
}