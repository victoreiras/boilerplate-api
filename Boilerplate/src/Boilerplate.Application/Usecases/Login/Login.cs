using Boilerplate.Application.ExternalServices;
using Boilerplate.Application.Repositories;
using ErrorOr;

namespace Boilerplate.Application.Usecases.Login;

public class Login : ILogin
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public Login(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;        
    }

    public async Task<ErrorOr<LoginOutput>> Execute(LoginInput input)
    {
        var user = await _userRepository.GetAsync(input.email, input.password);

        if (user == null)
            return Error.Failure("User Not Found");

        var token = _jwtService.Create(user);

        return new LoginOutput(token);
    }
}
