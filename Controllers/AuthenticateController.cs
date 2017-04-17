using Microsoft.AspNetCore.Mvc;
using webapi.DTO;
using webapi.Interfaces;
using webapi.Repository;

namespace webapi.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly AuthRepository _AuthRepository;
        private readonly UserRepository _UserRepository;

        public AuthenticateController(AuthRepository AuthRepository, UserRepository UserRepository)
        {
            _AuthRepository = AuthRepository; 
            _UserRepository = UserRepository;
        }

        [HttpPost]
        public IActionResult PostAuth([FromBody] AuthDTO value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            User user = _UserRepository.Find();

            _AuthRepository.Authenticate();

            return Ok(value);

        }
    }
}