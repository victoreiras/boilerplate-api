namespace Boilerplate.Application.Usecases.GetActiveProjects;

public interface IGetActiveProjects
{   
    Task<List<OutputGetActiveProjects>> Execute();
}