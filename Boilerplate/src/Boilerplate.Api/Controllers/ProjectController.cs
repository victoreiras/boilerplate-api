using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Application.Usecases.GetActiveProjects;
using Boilerplate.Application.Usecases.GetProjectById;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v1/projects")]
public class ProjectController : ControllerBase
{
    #region Ctors
    private readonly ICreateProject _createProject;
    private readonly IGetActiveProjects _getActiveProjects;
    private readonly IGetProjectById _getProjectById;
    public ProjectController(
        ICreateProject createProject, 
        IGetActiveProjects getActiveProjects, 
        IGetProjectById getProjectById)
    {
        _createProject = createProject;
        _getActiveProjects = getActiveProjects;
        _getProjectById = getProjectById;
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
    [Route("pageNumber/{pageNumber:int}/pageSize/{pageSize:int}")]
    [ProducesResponseType(typeof(OutputGetActiveProjects), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int pageNumber, int pageSize)
    {
        var result = await _getActiveProjects.Execute(pageNumber, pageSize);
        return Ok(result);
    }

    /// <summary>
    /// Get a project by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>200 Ok if successful</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(OutputGetProjectById), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getProjectById.Execute(id);

        if(result.IsError)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }
}