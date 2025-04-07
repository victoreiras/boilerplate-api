using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Enums;
using FluentAssertions;

namespace Boilerplate.Test.Unit.Domain;

public class ProjectTests
{
    [Fact(DisplayName = "Should create a project")]
    public void Should_Create_Project()
    {
        var project = Project.Create(
            name: "IndependÊncia Financeira",
            description: "Projeto para se aposentar",
            endDate: new DateOnly(2040, 12, 31)
        );

        project.IsError.Should().BeFalse();    
        project.Value.Id.Should().NotBeEmpty();
        project.Value.Name.Should().Be("IndependÊncia Financeira");
        project.Value.Description.Should().Be("Projeto para se aposentar");
        project.Value.BeginDate.Should().Be(DateOnly.FromDateTime(DateTime.Now));
        project.Value.EndDate.Should().Be(new DateOnly(2040, 12, 31));
        project.Value.ProjectStatus.Should().Be(ProjectStatus.Active);        
    }
}