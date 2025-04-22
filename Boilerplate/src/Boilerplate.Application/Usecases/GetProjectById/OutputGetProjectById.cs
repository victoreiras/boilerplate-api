namespace Boilerplate.Application.Usecases.GetProjectById;

public record OutputGetProjectById(
    Guid Id,
    string Name,
    string Description,
    DateOnly BeginDate,
    DateOnly EndDate
);
