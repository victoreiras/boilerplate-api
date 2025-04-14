using Boilerplate.Domain.Enums;
using ErrorOr;

namespace Boilerplate.Domain.Entities;

public class Project
{
    #region Ctors

    public Project(){}

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
    #endregion

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly BeginDate { get; set; }
    public DateOnly EndDate { get; set; }
    public ProjectStatus ProjectStatus { get; set; }

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
}