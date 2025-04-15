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

    /// <summary>
    /// Create a new project
    /// </summary>
    /// <param name="input">Project data to be created</param>
    /// <returns>201 Created if successful, 400 Bad Request if validation fails</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Output), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
    public async Task<IResult> Post(Input input)
    {
        var result = await _createProject.Execute(input);

        if (result.IsError)
            return Results.BadRequest(result.Errors);

        return Results.Created("api/project", result.Value);
    }
}