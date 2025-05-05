using ErrorOr;

namespace Boilerplate.Application.Usecases.Login;

public interface ILogin
{
    Task<ErrorOr<LoginOutput>> Execute(LoginInput input);
}
