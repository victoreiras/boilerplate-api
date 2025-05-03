using ErrorOr;

namespace Boilerplate.Application.Usecases.AddUserAProject;

public interface IAddUserAProject
{
    Task<ErrorOr<AddUserAProjectOutput>> Execute(AddUserAProjectInput input);
}
