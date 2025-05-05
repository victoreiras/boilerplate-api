using Boilerplate.Api.Controllers.Shared;
using Boilerplate.Api.Models;
using Boilerplate.Application.Usecases.Login;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers;

[Route("api/v1/users")]
[ApiController]
public class UserController : ApiController
{
    private readonly ILogin _login;

    public UserController(ILogin login)
    {
        _login = login;
    }

    /// <summary>
    /// Return a token
    /// </summary>
    /// <param name="input"></param>
    /// <returns>201 Created if successful, 400 Bad Request if validation fails</returns>
    [ProducesResponseType(typeof(CustonResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CustonResult), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> Login(LoginInput input)
    {
        var result = await _login.Execute(input);

        if (result.IsError)
            return ResponseBadRequest(result.FirstError.ToString());

        return ResponseCreated(result.Value);
    }
}
