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

    public async Task CreateAsync(Project project)
    {
        await _db.Projects.AddAsync(project);
        await _db.SaveChangesAsync();

        _cache.Set($"project-{project.Id}", project);
    }

    public async Task<(List<Project> projects, int total)> GetActivesAsync(int pageNumber, int pageSize)
    {        
        var query = _db.Projects
            .AsNoTracking()
            .Where(x => x.ProjectStatus == Domain.Enums.ProjectStatus.Active);

        var total = await query.CountAsync();

        var projects =  await query
            .OrderBy(p => p.BeginDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (projects, total);
    }

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        var key = $"project-{id}";

        if(_cache.TryGetValue(key, out Project? project))
            return project;

        project = await _db.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();

        _cache.Set(key, project, TimeSpan.FromHours(1));

        return project;
    }

    public async Task AddUserAsync(Project project)
    {
        _db.Projects.Update(project);
        await _db.SaveChangesAsync();        
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);
    }
}
