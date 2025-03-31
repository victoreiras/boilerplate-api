using Boilerplate.Application.Dtos;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Repositories;

namespace Boilerplate.Application.Usecases;

public class CreateProject
{
    private readonly IProjectRepository _projectRepository;

    public CreateProject(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project> Execute(ProjectDto input)
    {
        var project = new Project(
            input.Name,
            input.Description,            
            endDate: input.EndDate            
        );

        await _projectRepository.Create(project);

        return project;
    }
}