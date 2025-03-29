namespace Boilerplate.Domain.Repositories;

public interface IProjectRepository
{
    Task Create(Entities.Project project);
}