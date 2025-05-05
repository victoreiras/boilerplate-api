using Boilerplate.Domain.Enums;
using ErrorOr;

namespace Boilerplate.Domain.Entities;

public class User
{
    private User(string name, string email, string password, UserRole role)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserRole Role { get; private set; }
    public List<Project>? Projects { get; private set; } = new List<Project>();

    public static ErrorOr<User> Create(string name, string email, string password, UserRole role)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Error.Failure("Name not valid");

        if(string.IsNullOrWhiteSpace(email))
            return Error.Failure("Email not valid");

        if (string.IsNullOrWhiteSpace(password))
            return Error.Failure("Password not valid");

        return new User(name, email, password, role);
    }
}