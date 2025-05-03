using Boilerplate.Domain.Entities;

namespace Boilerplate.Application.Repositories;

public interface IProjectRepository
{
    Task Create(Project project);

    Task<Project?> GetById(Guid id);

    Task<(List<Project> projects, int total)> GetActives(int pageNumber, int pageSize);

    Task AddUser(Project project);

    Task<User?> GetUserById(Guid userId);
}