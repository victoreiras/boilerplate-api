using Boilerplate.Application.Dtos;
using Boilerplate.Application.Usecases;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Repositories;
using Boilerplate.Infrastructure.Repositories;
using Moq;

namespace Boilerplate.Test.Unit.Application.Usecases;

public class CreateProjectTests
{
    [Fact(DisplayName = "Should create project")]
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
        
        Assert.NotNull(result);
        Assert.NotNull(result.Id);
        Assert.Equal(result.Name, input.Name);
        Assert.Equal(result.Description, input.Description);
        Assert.Equal(result.BeginDate, DateOnly.FromDateTime(DateTime.UtcNow));
        Assert.Equal(result.EndDate, DateOnly.FromDateTime(DateTime.UtcNow.AddDays(10)));
    }
}