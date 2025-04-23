using Boilerplate.Domain.Entities;
using Boilerplate.Application.Repositories;
using ErrorOr;

namespace Boilerplate.Application.Usecases.CreateProject;

public class CreateProject : ICreateProject
{
    #region Ctors
    private readonly IProjectRepository _projectRepository;

    public CreateProject(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    #endregion

    public async Task<ErrorOr<CreateProjectOutput>> Execute(CreateProjectInput input)
    {
        var project = Project.Create(
            input.Name,
            input.Description,
            endDate: input.EndDate
        );

        if (project.IsError)
            return project.Errors;

        await _projectRepository.Create(project.Value);

        return new CreateProjectOutput(project.Value.Id);
    }
}