using Boilerplate.Domain.Entities;

namespace Boilerplate.Application.Repositories;

public interface IProjectRepository
{
    Task CreateAsync(Project project);

    Task<Project?> GetByIdAsync(Guid id);

    Task<(List<Project> projects, int total)> GetActivesAsync(int pageNumber, int pageSize);

    Task AddUserAsync(Project project);

    Task<User?> GetUserByIdAsync(Guid userId);
}