using Boilerplate.Application.Repositories;
using Boilerplate.Application.Common.Models;

namespace Boilerplate.Application.Usecases.GetProjects;

public class GetProjects : IGetProjects
{
    #region Ctors
    private readonly IProjectRepository _projectRepository;

    public GetProjects(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    #endregion

    public async Task<PagedResult<GetProjectsOutput>> Execute(int pageNumber, int pageSize)
    {        
        var (projects, total) = await _projectRepository.GetActives(pageNumber, pageSize);        

        return new PagedResult<GetProjectsOutput>
        {
            Items = projects.Select(p => new GetProjectsOutput(
                p.Name,
                p.Description,
                p.ProjectStatus.ToString()
            )),
            TotalItems = total,
            Page = pageNumber,
            Size = pageSize
        };
    }
}
