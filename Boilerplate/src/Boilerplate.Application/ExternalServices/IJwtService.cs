using Boilerplate.Domain.Entities;

namespace Boilerplate.Application.ExternalServices;

public interface IJwtService
{
    string Create(User user);
}
