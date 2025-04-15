namespace Boilerplate.Application.Usecases.CreateProject;

public record Input(
    string Name,
    string Description,
    DateOnly EndDate
);