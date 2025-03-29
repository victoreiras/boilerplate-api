using Boilerplate.Domain.Enums;

namespace Boilerplate.Domain.Entities;

public class Project
{
    #region Ctors
    public Project(
        string name,
        string description,
        DateTime endDate
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        BeginDate = DateTime.UtcNow;
        EndDate = endDate;
        ProjectStatus = ProjectStatus.Active;
    }
    #endregion

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime BeginDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public ProjectStatus ProjectStatus { get; private set; }
}