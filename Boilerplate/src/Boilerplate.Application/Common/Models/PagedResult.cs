namespace Boilerplate.Application.Common.Models;

public class PagedResult<T> where T : class   
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int TotalItems { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}