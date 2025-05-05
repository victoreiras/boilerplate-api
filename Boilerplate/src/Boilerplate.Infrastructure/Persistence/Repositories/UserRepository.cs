using Boilerplate.Application.Repositories;
using Boilerplate.Domain.Entities;
using Boilerplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetAsync(string username, string password)
    {
        return await _db.Users.FirstOrDefaultAsync(user => user.Email == username && user.Password  == password);
    }
}
