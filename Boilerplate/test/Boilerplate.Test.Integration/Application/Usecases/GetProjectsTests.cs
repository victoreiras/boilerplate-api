using Boilerplate.Application.Usecases.GetActiveProjects;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Enums;
using Boilerplate.Infrastructure.Persistence.Context;
using Boilerplate.Infrastructure.Persistence.Repositories;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Test.Integration.Application.Usecases;

public class GetProjectsTests : IDisposable
{
    #region Ctors
    private readonly ProjectRepository projectRepository;
    private readonly AppDbContext _context;
    private readonly SqliteConnection _connection;

    public GetProjectsTests()
    {
        _connection = new SqliteConnection("DataSource=ProjetoDB.db");

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new AppDbContext(options);
        _context.Database.EnsureCreated();

        var project1 = Project.Create("Projeto 1", "Descrição do projeto 1", new DateOnly(2026, 05, 01)).Value;

        _context.Projects.AddRange(project1);
        _context.SaveChangesAsync();

        projectRepository = new ProjectRepository(_context);
    }
    #endregion

    [Fact(DisplayName = "Should get active projects")]
    public async Task Should_Get_Active_Projects()
    {
        var getActiveProjects = new GetActiveProjects(projectRepository);

        var result = await getActiveProjects.Execute();

        result.Should().NotBeNull();
        result.Should().OnlyContain(x => x.Status == ProjectStatus.Active.ToString());
    }

    public void Dispose()
    {
        _context.Dispose();
        _connection.Dispose();
        _connection.Close();
    }
}