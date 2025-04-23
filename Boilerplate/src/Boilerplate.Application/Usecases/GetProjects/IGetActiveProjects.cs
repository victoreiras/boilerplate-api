using Boilerplate.Application.Common.Models;

namespace Boilerplate.Application.Usecases.GetProjects;

public interface IGetProjects
{   
    Task<PagedResult<GetProjectsOutput>> Execute(int pageNumber, int pageSize);
}