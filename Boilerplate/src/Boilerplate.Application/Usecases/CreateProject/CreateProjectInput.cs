namespace Boilerplate.Application.Usecases.CreateProject;

public record CreateProjectInput(
    string Name,
    string Description,
    DateOnly EndDate
);