using Boilerplate.Domain.Enums;

namespace Boilerplate.Application.Dtos;

public record ProjectDto(
    string Name,
    string Description,
    DateTime EndDate
);