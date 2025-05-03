using Boilerplate.Domain.Enums;
using ErrorOr;

namespace Boilerplate.Domain.Entities;

public class Project
{
    #region Ctors
    private Project(
        string name,
        string description,
        DateOnly endDate
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        BeginDate = DateOnly.FromDateTime(DateTime.Now);
        EndDate = endDate;
        ProjectStatus = ProjectStatus.Active;
    }

    private Project(
        string name,
        string description,
        DateOnly endDate,
        List<User> users
    ) : this(name, description, endDate)
    {
        Users = users;
    }
    #endregion

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateOnly BeginDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public ProjectStatus ProjectStatus { get; private set; }
    public List<User>? Users { get; private set; } = new List<User>();

    public static ErrorOr<Project> Create(string name, string description, DateOnly endDate)
    {
        if(string.IsNullOrEmpty(name))
            return Error.Validation("Project.Name", "Name is required");

        if(string.IsNullOrEmpty(description))
            return Error.Validation("Project.Description", "Description is required");

        if(endDate <= DateOnly.FromDateTime(DateTime.Now))
            return Error.Validation("Project.EndDate", "The end date has to be greater than today");

        return new Project(name, description, endDate);
    }

    public static ErrorOr<Project> Create(string name, string description, DateOnly endDate, List<User> users)
    {
        //TODO: Refatorar código de validação duplicado
        if(string.IsNullOrEmpty(name))
            return Error.Validation("Project.Name", "Name is required");

        if(string.IsNullOrEmpty(description))
            return Error.Validation("Project.Description", "Description is required");

        if(endDate <= DateOnly.FromDateTime(DateTime.Now))
            return Error.Validation("Project.EndDate", "The end date has to be greater than today");            

        return new Project(name, description, endDate, users);
    }
}