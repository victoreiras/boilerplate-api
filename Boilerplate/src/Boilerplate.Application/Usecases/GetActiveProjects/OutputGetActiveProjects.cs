
namespace Boilerplate.Application.Usecases.GetActiveProjects;

    public record OutputGetActiveProjects(
        string Name,
        string Description,
        string Status
    );