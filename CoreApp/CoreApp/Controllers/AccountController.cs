using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers;
[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
}