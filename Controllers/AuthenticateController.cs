using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.DTO;
using webapi.Interfaces;

namespace webapi.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly IAuthRepository _IauthRepository;

        public AuthenticateController(IAuthRepository authRepository)
        {
            _IauthRepository = authRepository; 
        }

        [HttpPost]
        public IActionResult PostAuth([FromBody] AuthDTO value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            return Ok(value);

        }
    }
}