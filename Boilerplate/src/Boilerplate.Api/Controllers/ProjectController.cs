using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Application.Usecases.GetActiveProjects;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/projects")]
public class ProjectController : ControllerBase
{
    #region Ctors
    private readonly ICreateProject _createProject;
    private readonly IGetActiveProjects _getActiveProjects;
    public ProjectController(ICreateProject createProject, IGetActiveProjects getActiveProjects)
    {
        _createProject = createProject;
        _getActiveProjects = getActiveProjects;
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
    public async Task<IActionResult> Post(Input input)
    {
        var result = await _createProject.Execute(input);

        if (result.IsError)
            return BadRequest(result.Errors);

        return Created("api/project", result.Value);
    }
    
    /// <summary>
    /// Get all active projects
    /// </summary>
    /// <returns>200 Ok if successful</returns>    
    [HttpGet]
    [ProducesResponseType(typeof(OutputGetActiveProjects), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var result = await _getActiveProjects.Execute();
        return Ok(result);
    }
}