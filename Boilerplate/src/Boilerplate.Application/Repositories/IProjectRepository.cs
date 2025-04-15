using Boilerplate.Domain.Entities;

namespace Boilerplate.Application.Repositories;

public interface IProjectRepository
{
    Task Create(Project project);

    Task<Project> GetById(Guid id);
}