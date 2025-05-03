using Boilerplate.Domain.Enums;
using ErrorOr;

namespace Boilerplate.Domain.Entities;

public class User
{
    private User(string name, int age, UserRole role)
    {
        Id = Guid.NewGuid();
        Name = Name;
        Age = age;
        Role = role;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public UserRole Role { get; private set; }
    public List<Project>? Projects { get; private set; } = new List<Project>();

    public static ErrorOr<User> Create(string name, int age, UserRole role)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Error.Failure("Name not valid");

        if(age == 0)
            return Error.Failure("Age not valid");

        return new User(name, age, role);
    }
}