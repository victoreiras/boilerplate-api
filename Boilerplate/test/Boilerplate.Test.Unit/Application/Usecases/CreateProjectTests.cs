using Boilerplate.Application.Dtos;
using Boilerplate.Application.Usecases;
using Boilerplate.Infrastructure.Repositories;

namespace Boilerplate.Test.Unit.Application.Usecases;

public class CreateProjectTests
{
    [Fact(DisplayName = "Should create project")]
    public async Task Should_Create_Project()
    {
        var projectRepository = new ProjectRepository();
        var createProject = new CreateProject(projectRepository);

        var input = new ProjectDto(
            Name: "Nome do Projeto",
            Description: "Descrição do Projeto",
            EndDate: DateTime.Now.AddDays(10)
        );

        var result = await createProject.Execute(input);
        
        Assert.NotNull(result);
        Assert.NotNull(result.Id);
    }
}