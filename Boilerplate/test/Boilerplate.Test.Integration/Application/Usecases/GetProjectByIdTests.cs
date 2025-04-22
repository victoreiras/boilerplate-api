using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Application.Usecases.GetProjectById;
using Boilerplate.Infrastructure.Persistence.Context;
using Boilerplate.Infrastructure.Persistence.Repositories;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Boilerplate.Test.Integration.Application.Usecases;

public class GetProjectByIdTests
{
    private readonly SqliteConnection _connection;
    private readonly ProjectRepository _projectRepository;

    public GetProjectByIdTests()
    {
        _connection = new SqliteConnection("DataSource=ProjetoDB.db");

        var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_connection)
            .Options;
        var dbContext = new AppDbContext(dbContextOptions);
        dbContext.Database.EnsureCreated();

        _projectRepository = new ProjectRepository(dbContext, new MemoryCache(new MemoryCacheOptions()));

    }

    [Fact(DisplayName = "Should get a project by id")]
    public async Task Should_Get_Project_By_Id()
    {                        
        var createProject = new CreateProject(_projectRepository);
        var inputCreateProject = new Input("Novo projeto teste", "Novo projeto teste", DateOnly.FromDateTime(DateTime.Now.AddDays(100)));
        var project = await createProject.Execute(inputCreateProject);
        if(project.IsError)
            Console.WriteLine(project.Errors.FirstOrDefault().Description);
        var projectId = project.Value.Id;

        var getProjectById = new GetProjectById(_projectRepository);        
        var result = await getProjectById.Execute(projectId);

        result.Value.Should().NotBeNull();
        result.Value.Id.Should().Be(projectId);
    }
}