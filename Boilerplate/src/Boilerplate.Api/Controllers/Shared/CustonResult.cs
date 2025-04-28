using System.Net;

namespace Boilerplate.Api.Controllers.Shared;

public class CustonResult
{
    public CustonResult(HttpStatusCode httpStatusCode, bool success)
    {
        HttpStatusCode = httpStatusCode;
        Success = success;
    }

    public CustonResult(HttpStatusCode httpStatusCode, bool success, object data) 
        : this(httpStatusCode, success) =>
        Data = data;

    public CustonResult(HttpStatusCode httpStatusCode, bool success, IEnumerable<string> errors)
        : this(httpStatusCode, success) =>
        Errors = errors;

    public HttpStatusCode HttpStatusCode { get; private set; }
    public bool Success { get; private set; }
    public object? Data { get; private set; }
    public IEnumerable<string> Errors { get; private set; } = Enumerable.Empty<string>();    
}
