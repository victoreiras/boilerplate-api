using Boilerplate.Application.Repositories;
using ErrorOr;

namespace Boilerplate.Application.Usecases.GetProjectById;

public class GetProjectById : IGetProjectById
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectById(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<GetProjectByIdOutput>> Execute(Guid id)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if(project is null)
            return Error.Failure("Project not found");

        //TODO: Implementar retorno de Users
        var result = new GetProjectByIdOutput(project.Id, project.Name, project.Description, project.BeginDate, project.EndDate, null);

        return result;
    }
}
