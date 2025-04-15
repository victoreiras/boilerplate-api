using Boilerplate.Application.Dtos;
using Boilerplate.Application.Usecases.CreateProject;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers;

[ApiController]
[Route("api/project")]
public class ProjectController : ControllerBase
{
    #region Ctors
    private readonly ICreateProject _createProject;

    public ProjectController(ICreateProject createProject)
    {
        _createProject = createProject;
    }
    #endregion

    [HttpPost]
    public async Task<IResult> Post(ProjectDto request)
    {
        var result = await _createProject.Execute(request);

        if (result.IsError)
            return Results.BadRequest(result.Errors);

        return Results.Created("api/project", result.Value);
    }
}