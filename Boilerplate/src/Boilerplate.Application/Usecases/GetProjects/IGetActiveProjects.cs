using Boilerplate.Application.Common.Models;
using ErrorOr;

namespace Boilerplate.Application.Usecases.GetProjects;

public interface IGetProjects
{   
    Task<ErrorOr<PagedResult<GetProjectsOutput>>> Execute(int pageNumber, int pageSize);
}