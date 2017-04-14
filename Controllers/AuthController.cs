using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Interfaces;

namespace webapi.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _IauthRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _IauthRepository = authRepository; 
        }

        [HttpPost("token")]
        public IActionResult NewToken(Auth value)
        {
            return Ok(value);
        }
    }
}