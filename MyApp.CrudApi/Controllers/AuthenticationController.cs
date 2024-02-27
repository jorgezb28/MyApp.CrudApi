using Microsoft.AspNetCore.Mvc;
using MyApp.CrudApi.Services.DTOs;
using MyApp.CrudApi.Services.IServices;

namespace MyApp.CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationServices;

        public AuthenticationController(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }


        [HttpPost("register-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register(RegisterUserDto newUser)
        {
            if (newUser is not null)
            {
                _authenticationServices.RegisterNewUser(newUser);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public IActionResult Login(LoginUserDto loginUser)
        {
            if (loginUser is not null)
            {
                var loggedUser = _authenticationServices.Login(loginUser);
                if (loggedUser is not null)
                {
                    return Ok();
                }
                return Unauthorized();
            }

            return BadRequest();
        }
    }
}
