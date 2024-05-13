using Demo.application.UserAdmin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.ui.Controllers
{
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private Register _registerUser;
        public UserController(Register reg)
        {
            _registerUser = reg;

        }

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] Register.Request request)
        {
            await _registerUser.Do(request);
            return Ok(request);
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] Register.Request request)
        {
            await _registerUser.Do(request);
            return Ok(request);
        }
    }
}
