using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Application.Usecases.GetProjects;
using Boilerplate.Application.Usecases.GetProjectById;
using Microsoft.AspNetCore.Mvc;
using Boilerplate.Api.Controllers.Shared;
using Boilerplate.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Boilerplate.Api.Controllers;

[Authorize]
[ApiVersion("1.0")]
[Route("api/v1/projects")]
public class ProjectController : ApiController
{
    #region Ctors
    private readonly ICreateProject _createProject;
    private readonly IGetProjects _getProjects;
    private readonly IGetProjectById _getProjectById;
    public ProjectController(
        ICreateProject createProject, 
        IGetProjects getProjects, 
        IGetProjectById getProjectById)
    {
        _createProject = createProject;
        _getProjects = getProjects;
        _getProjectById = getProjectById;
    }
    #endregion

    /// <summary>
    /// Create a new project
    /// </summary>
    /// <param name="CreateProjectOutput">Project data to be created</param>
    /// <returns>201 Created if successful, 400 Bad Request if validation fails</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CustonResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CustonResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateProjectInput input)
    {
        var result = await _createProject.Execute(input);

        if (result.IsError)
            return ResponseBadRequest(result.FirstError.ToString());

        return ResponseCreated(result.Value);
    }
    
    /// <summary>
    /// Get all active projects
    /// </summary>
    /// <returns>200 Ok if successful</returns>    
    [HttpGet]
    [Route("pageNumber/{pageNumber:int}/pageSize/{pageSize:int}")]
    [ProducesResponseType(typeof(CustonResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int pageNumber, int pageSize)
    {
        var result = await _getProjects.Execute(pageNumber, pageSize);
        return ResponseOk(result.Value);
    }

    /// <summary>
    /// Get a project by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>200 Ok if successful</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(CustonResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CustonResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getProjectById.Execute(id);

        if(result.IsError)
            return ResponseBadRequest(result.FirstError.ToString());

        return ResponseOk(result.Value);
    }
}