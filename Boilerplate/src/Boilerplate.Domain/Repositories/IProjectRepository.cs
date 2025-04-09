using Boilerplate.Domain.Entities;

namespace Boilerplate.Domain.Repositories;

public interface IProjectRepository
{
    Task Create(Entities.Project project);

    Task<Project> GetById(Guid id);
}