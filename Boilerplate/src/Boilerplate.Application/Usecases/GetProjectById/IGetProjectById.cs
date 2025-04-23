using ErrorOr;

namespace Boilerplate.Application.Usecases.GetProjectById;

public interface IGetProjectById
{
    Task<ErrorOr<GetProjectByIdOutput>> Execute(Guid id);
}
