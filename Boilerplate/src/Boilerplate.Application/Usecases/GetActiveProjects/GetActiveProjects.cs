using Boilerplate.Application.Repositories;
using Boilerplate.Application.Common.Models;

namespace Boilerplate.Application.Usecases.GetActiveProjects;

public class GetActiveProjects : IGetActiveProjects
{
    #region Ctors
    private readonly IProjectRepository _projectRepository;

    public GetActiveProjects(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    #endregion

    public async Task<PagedResult<OutputGetActiveProjects>> Execute(int pageNumber, int pageSize)
    {        
        var (projects, total) = await _projectRepository.GetActives(pageNumber, pageSize);        

        return new PagedResult<OutputGetActiveProjects>
        {
            Items = projects.Select(p => new OutputGetActiveProjects(
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
