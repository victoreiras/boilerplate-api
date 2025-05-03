using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers;

[Route("api/v1/users")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {

    }
}
