using Boilerplate.Application.Usecases.AddUserAProject;
using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Application.Usecases.GetProjectById;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Enums;
using Boilerplate.Infrastructure.Persistence.Context;
using Boilerplate.Infrastructure.Persistence.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Boilerplate.Test.Integration.Application.Usecases;

public class AddUserAProjectTests
{
    private readonly ProjectRepository _projectRepository;
    private readonly User _user;
    public AddUserAProjectTests()
    {
        var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlite("DataSource=ProjetoDb").Options;        
        var db = new AppDbContext(dbContextOptions);
        db.Database.EnsureCreated();

        _user = User.Create(name: "Victor Eiras", age: 35, role: UserRole.Developer).Value;

        db.Users.Add(_user);
        db.SaveChanges();

        _projectRepository = new ProjectRepository(db, new MemoryCache(new MemoryCacheOptions()));
    }

    [Fact(DisplayName = "Should add a user to a project")]
    public async Task Should_Add_A_User_To_A_Project()
    {        
        var createProject = new CreateProject(_projectRepository);
        var createProjectInput = new CreateProjectInput("Projeto Victor", "Descrição do projeto", DateOnly.FromDateTime(DateTime.Now.AddYears(1)));
        var createProjectResult = await createProject.Execute(createProjectInput);
        
        var addUserAProjectInput = new AddUserAProjectInput(projectId: createProjectResult.Value.Id, userId: _user.Id);

        var addUserAProject = new AddUserAProject(_projectRepository);
        var addUserAProjectResult = await addUserAProject.Execute(addUserAProjectInput);

        var getProjectById = new GetProjectById(_projectRepository);
        var project = await getProjectById.Execute(createProjectResult.Value.Id);

        addUserAProjectResult.IsError.Should().BeFalse();
        project.Value.Id.Should().Be(createProjectResult.Value.Id);
        project.Value.Users.Should().Contain(user => user.Id == _user.Id);
    }
}