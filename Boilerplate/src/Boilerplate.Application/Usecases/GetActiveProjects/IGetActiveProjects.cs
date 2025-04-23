using Boilerplate.Application.Common.Models;

namespace Boilerplate.Application.Usecases.GetActiveProjects;

public interface IGetActiveProjects
{   
    Task<PagedResult<OutputGetActiveProjects>> Execute(int pageNumber, int pageSize);
}