using Boilerplate.Application.Repositories;

namespace Boilerplate.Application.Usecases.GetActiveProjects;

public class GetActiveProjects : IGetActiveProjects
{
    #region Ctors
    private readonly IProjectRepository _projectRepository;

    public GetActiveProjects(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    #endregion

    public async Task<List<OutputGetActiveProjects>> Execute()
    {
        var output = new List<OutputGetActiveProjects>();
        
        var projects = await _projectRepository.GetActives();

        foreach (var item in projects)
        {
            output.Add(new OutputGetActiveProjects(item.Name, item.Description, item.ProjectStatus.ToString()));
        }

        return output;
    }
}
