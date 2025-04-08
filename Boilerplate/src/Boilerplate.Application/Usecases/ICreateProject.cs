using Boilerplate.Application.Dtos;
using Boilerplate.Domain.Entities;
using ErrorOr;

namespace Boilerplate.Application.Usecases;

public interface ICreateProject
{
    Task<ErrorOr<Project>> Execute(ProjectDto input);
}