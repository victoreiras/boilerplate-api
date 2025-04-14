using Boilerplate.Application.Dtos;
using Boilerplate.Application.Usecases.CreateProject;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly ICreateProject _createProject;

    public ProjectController(ICreateProject createProject)
    {
        _createProject = createProject;
    }

    [HttpPost]
    public async Task<IResult> Post(ProjectDto request)
    {
        var result = await _createProject.Execute(request);
        return Results.Created("", result.Value);
    }

    [HttpGet]
    [Route("health")]
    public async Task<IActionResult> Get()
    {
        return Ok("OK");
    }
}