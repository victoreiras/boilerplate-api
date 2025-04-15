using ErrorOr;

namespace Boilerplate.Application.Usecases.CreateProject;

public interface ICreateProject
{
    Task<ErrorOr<Output>> Execute(Input input);
}