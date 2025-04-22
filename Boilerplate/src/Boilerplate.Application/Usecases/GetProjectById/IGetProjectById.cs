using ErrorOr;

namespace Boilerplate.Application.Usecases.GetProjectById;

public interface IGetProjectById
{
    Task<ErrorOr<OutputGetProjectById>> Execute(Guid id);
}
