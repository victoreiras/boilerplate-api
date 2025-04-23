namespace Boilerplate.Application.Usecases.GetProjects;

    public record GetProjectsOutput(
        string Name,
        string Description,
        string Status
    );