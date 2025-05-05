using Boilerplate.Application.Repositories;
using ErrorOr;

namespace Boilerplate.Application.Usecases.AddUserAProject;

public class AddUserAProject : IAddUserAProject
{
    private readonly IProjectRepository _projectRepository;

    public AddUserAProject(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<AddUserAProjectOutput>> Execute(AddUserAProjectInput input)
    {
        var project = await _projectRepository.GetByIdAsync(input.projectId);
        var user = await _projectRepository.GetUserByIdAsync(input.userId);

        if(project is null)
            return Error.Failure("Project not found");

        if(user is null)
            return Error.Failure("User not found");

        project.Users?.Add(user);

        await _projectRepository.AddUserAsync(project);

        return new AddUserAProjectOutput(input.projectId, input.userId);
    }
}
