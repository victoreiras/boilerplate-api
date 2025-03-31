namespace Boilerplate.Application.Dtos;

public record ProjectDto(
    string Name,
    string Description,
    DateOnly EndDate
);