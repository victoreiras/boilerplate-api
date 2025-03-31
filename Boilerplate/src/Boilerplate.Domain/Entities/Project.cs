using Boilerplate.Domain.Enums;

namespace Boilerplate.Domain.Entities;

public class Project
{
    #region Ctors
    public Project(
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

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateOnly BeginDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public ProjectStatus ProjectStatus { get; private set; }
}