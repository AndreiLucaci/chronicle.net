using Microsoft.AspNetCore.Mvc;

namespace Chronicle.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
