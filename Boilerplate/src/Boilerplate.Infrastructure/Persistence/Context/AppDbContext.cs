using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = User.Create("Victor Eiras", "victor.eiras@gmail.com", "123456", Domain.Enums.UserRole.Developer).Value;
        user.Id = Guid.Parse("0b5254be-d8ff-45e0-8341-ea2a854f99cf");

        modelBuilder.Entity<User>().HasData(user);

        base.OnModelCreating(modelBuilder);
    }
}
