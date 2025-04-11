using Boilerplate.Application.Dtos;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Repositories;
using ErrorOr;

namespace Boilerplate.Application.Usecases.CreateProject;

public class CreateProject : ICreateProject
{
    private readonly IProjectRepository _projectRepository;

    public CreateProject(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<Project>> Execute(ProjectDto input)
    {
        var project = Project.Create(
            input.Name,
            input.Description,
            endDate: input.EndDate
        );

        if (project.IsError)
            return project.Errors;

        await _projectRepository.Create(project.Value);

        return project;
    }
}