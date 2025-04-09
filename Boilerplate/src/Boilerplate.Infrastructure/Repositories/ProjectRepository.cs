using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Repositories;
using Boilerplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _db;

    public ProjectRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task Create(Project project)
    {
        await _db.Projects.AddAsync(project);
        await _db.SaveChangesAsync();
    }

    public async Task<Project?> GetById(Guid id)
    {
        return await _db.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}
