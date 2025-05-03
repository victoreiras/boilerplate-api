using Boilerplate.Domain.Entities;

namespace Boilerplate.Application.Usecases.GetProjectById;

public record GetProjectByIdOutput(
    Guid Id,
    string Name,
    string Description,
    DateOnly BeginDate,
    DateOnly EndDate,

    //TODO: Não utilizar entidade
    List<User>? Users
);
