using Boilerplate.Domain.Entities;
using Boilerplate.Application.Repositories;
using Boilerplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Boilerplate.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    #region Ctors
    private readonly AppDbContext _db;
    private readonly IMemoryCache _cache;
    private const string PROJECTS_KEY = "projects";

    public ProjectRepository(AppDbContext db, IMemoryCache cache)
    {
        _db = db;
        _cache = cache;
    }
    #endregion

    public async Task Create(Project project)
    {
        await _db.Projects.AddAsync(project);
        await _db.SaveChangesAsync();

        _cache.Set($"project-{project.Id}", project);
    }

    public async Task<List<Project>> GetActives()
    {
        if(_cache.TryGetValue(PROJECTS_KEY, out List<Project>? projects))
            return projects;
        
        projects =  await _db.Projects
            .Where(x => x.ProjectStatus == Domain.Enums.ProjectStatus.Active)
            .ToListAsync();

        _cache.Set(PROJECTS_KEY, projects, TimeSpan.FromHours(1));

        return projects;
    }

    public async Task<Project?> GetById(Guid id)
    {
        var key = $"project-{id}";

        if(_cache.TryGetValue(key, out Project? project))
            return project;

        project = await _db.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();

        _cache.Set(key, project, TimeSpan.FromHours(1));

        return project;
    }
}
