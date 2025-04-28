using System.Net;
using Boilerplate.Api.Extensions;
using Boilerplate.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers.Shared;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected IActionResult ResponseOk() =>
        Response(HttpStatusCode.OK);

    protected IActionResult ResponseOk(object data) =>
        Response(HttpStatusCode.OK, data);

    protected IActionResult ResponseCreated() =>
        Response(HttpStatusCode.Created);

    protected IActionResult ResponseCreated(object data) =>
        Response(HttpStatusCode.Created, data);

    protected IActionResult ResponseNoContent() =>
        Response(HttpStatusCode.NoContent);

    protected IActionResult ResponseNotModified() =>
        Response(HttpStatusCode.NotModified);

    protected IActionResult ResponseBadRequest() =>
        Response(HttpStatusCode.BadRequest);
    
    protected IActionResult ResponseBadRequest(string errorMessage) =>
        Response(HttpStatusCode.BadRequest, errorMessage);

    protected new JsonResult Response(HttpStatusCode statusCode, object? data, string? errorMessage)
    {
        CustonResult? result = null;

        if(string.IsNullOrWhiteSpace(errorMessage))
        {
            var success = statusCode.IsSuccess();

            if (data != null)
                result = new CustonResult(statusCode, success, data);
            else
                result = new CustonResult(statusCode, success);
        }
        else
        {
            var errors = new List<string>();

            if(!string.IsNullOrWhiteSpace(errorMessage))
                errors.Add(errorMessage);

            result = new CustonResult(statusCode, false, errors);
        }

        return new JsonResult(result) { StatusCode = (int)result.HttpStatusCode}; 
    }

    protected new JsonResult Response(HttpStatusCode statusCode, object data) =>
        Response(statusCode, data, null);

    protected new JsonResult Response(HttpStatusCode statusCode, string errorMessage) =>
        Response(statusCode, null, errorMessage);

    protected new JsonResult Response(HttpStatusCode statusCode) => 
        Response(statusCode, null, null);
}