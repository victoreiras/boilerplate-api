using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Project> Projects { get; set; }
}
