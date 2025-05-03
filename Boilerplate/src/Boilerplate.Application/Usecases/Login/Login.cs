
using ErrorOr;

namespace Boilerplate.Application.Usecases.Login;

public class Login : ILogin
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public Login(IJwtService jwtService, IUserRepository userRepository)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<LoginOutput>> Login(LoginInput input)
    {
        var user = await _userRepository.Get(input.email, input.password);

        if (user == null)
            return Error.Failure("User Not Found");

        var token = await _jwtService.GenerateTokenAsync(user);

        return new LoginOutput(token);
    }
}
