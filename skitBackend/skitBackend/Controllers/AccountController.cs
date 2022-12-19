using Microsoft.AspNetCore.Mvc;
using skitBackend.Data.Models.Dto;
using skitBackend.Services;

namespace skitBackend.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto registerUserDto)
        {
            _accountService.RegisterUser(registerUserDto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult LoginUser([FromBody]LoginUserDto loginUserDto)
        {
            var token = _accountService.LoginUser(loginUserDto);
            return Ok(token);
        }
    }
}
