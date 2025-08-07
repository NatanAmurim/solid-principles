using IntegrationTestLab.Application.DTOs;
using IntegrationTestLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestLab.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRequest user)
        {
            _userService.Register(user.Name, user.Email);

            return Created();
        }
    }
}
