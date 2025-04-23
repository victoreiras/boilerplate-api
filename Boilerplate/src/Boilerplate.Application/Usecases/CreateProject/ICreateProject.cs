using ErrorOr;

namespace Boilerplate.Application.Usecases.CreateProject;

public interface ICreateProject
{
    Task<ErrorOr<CreateProjectOutput>> Execute(CreateProjectInput input);
}