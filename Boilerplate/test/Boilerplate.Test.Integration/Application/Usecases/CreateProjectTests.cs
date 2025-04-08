using Boilerplate.Application.Dtos;
using Boilerplate.Application.Usecases;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Repositories;
using Boilerplate.Infrastructure.Repositories;
using Moq;
using FluentAssertions;

namespace Boilerplate.Test.Integration.Application.Usecases;

public class CreateProjectTests
{
    [Fact(DisplayName = "Should create a project")]
    public async Task Should_Create_Project()
    {      
        var input = new ProjectDto(
            Name: "Nome do Projeto",
            Description: "Descrição do Projeto",
            EndDate: DateOnly.FromDateTime(DateTime.Now.AddDays(10))
        );

        var projectRepositoryMock = new Mock<IProjectRepository>();
        projectRepositoryMock.Setup(x => x.Create(It.IsAny<Project>()));            

        var createProject = new CreateProject(projectRepositoryMock.Object);

        var result = await createProject.Execute(input);
        
        result.IsError.Should().BeFalse();
        result.Value.Id.Should().NotBeEmpty();
        result.Value.Name.Should().Be(input.Name);
        result.Value.Description.Should().Be(input.Description);
        result.Value.BeginDate.Should().Be(DateOnly.FromDateTime(DateTime.UtcNow));
        result.Value.EndDate.Should().Be(DateOnly.FromDateTime(DateTime.UtcNow.AddDays(10)));
    }

    [Fact(DisplayName = "Should not create a project with end date less than today")]
    public async Task ShouldNotCreateAProjectWithEndDateInvalid()
    {
        var projectRepository = new ProjectRepository();
        var createProject = new CreateProject(projectRepository);

        var input = new ProjectDto(
            Name: "Nome do Projeto",
            Description: "Descrição do Projeto",
            EndDate: DateOnly.FromDateTime(DateTime.Now.AddDays(-1))
        );

        var result = await createProject.Execute(input);

        result.IsError.Should().BeTrue();        
    }
}