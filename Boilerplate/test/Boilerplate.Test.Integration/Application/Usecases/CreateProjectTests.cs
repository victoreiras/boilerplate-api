using Boilerplate.Application.Dtos;
using Boilerplate.Application.Usecases;
using Boilerplate.Domain.Entities;
using Boilerplate.Infrastructure.Repositories;
using FluentAssertions;
using Boilerplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace Boilerplate.Test.Integration.Application.Usecases;

public class CreateProjectTests : IDisposable
{
    #region Ctor
    private readonly SqliteConnection _connection;
    private readonly AppDbContext _context;
    private readonly CreateProject _createProject;
    private readonly ProjectRepository _projectRepository;

    public CreateProjectTests()
    {
        _connection = new SqliteConnection("DataSource=ProjetoDB.db");

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new AppDbContext(options);
        _context.Database.EnsureCreated();

        _context.Projects.AddRange(
            new Project()
            {
                Id = Guid.NewGuid(),
                Name = "Projeto 1",
                Description = "Descrição do projeto 1",
                BeginDate = new DateOnly(2025, 05, 01),
                EndDate = new DateOnly(2026, 05, 01),
                ProjectStatus = Domain.Enums.ProjectStatus.Active
            },
            new Project()
            {
                Id = Guid.NewGuid(),
                Name = "Projeto 2",
                Description = "Descrição do projeto 2",
                BeginDate = new DateOnly(2025, 05, 01),
                EndDate = new DateOnly(2027, 01, 03),
                ProjectStatus = Domain.Enums.ProjectStatus.Active
            }
        );

        _projectRepository = new ProjectRepository(_context);
        _createProject = new CreateProject(_projectRepository);
    }
    #endregion

    [Fact(DisplayName = "Should create a project")]
    public async Task Should_Create_Project()
    {
        var input = new ProjectDto(
            Name: "Nome do Projeto",
            Description: "Descrição do Projeto",
            EndDate: DateOnly.FromDateTime(DateTime.Now.AddDays(10))
        );

        var result = await _createProject.Execute(input);

        var projectCreated = await _projectRepository.GetById(result.Value.Id);

        result.IsError.Should().BeFalse();
        projectCreated?.Id.Should().NotBeEmpty();
        projectCreated?.Name.Should().Be(input.Name);
        projectCreated?.Description.Should().Be(input.Description);
        projectCreated?.BeginDate.Should().Be(DateOnly.FromDateTime(DateTime.UtcNow));
        projectCreated?.EndDate.Should().Be(DateOnly.FromDateTime(DateTime.UtcNow.AddDays(10)));

    }

    public void Dispose()
    {
        _context.Dispose();
        _connection.Close();
        _connection.Dispose();
    }
}