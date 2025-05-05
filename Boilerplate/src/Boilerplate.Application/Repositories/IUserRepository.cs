using Boilerplate.Domain.Entities;

namespace Boilerplate.Application.Repositories;

public interface IUserRepository
{
    Task<User?> GetAsync(string username, string password);
}
