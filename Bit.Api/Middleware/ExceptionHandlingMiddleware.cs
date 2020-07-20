using Bit.Api.Helpers.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Bit.Api.Middleware
{
    public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (Exception e)
        {
            await HandleException(httpContext.Response, e);
            throw;
        }
    }

    private static async Task HandleException(HttpResponse httpResponse, Exception exception)
    {
        httpResponse.Headers.Add("Exception-Type", exception.GetType().Name);
        if (exception is NotFoundException)
        {
            httpResponse.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Found";
            httpResponse.StatusCode = (int)HttpStatusCode.NotFound;
        }
        else
        {
            httpResponse.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Bad Request";
            httpResponse.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        await httpResponse.WriteAsync(exception.Message).ConfigureAwait(false);
    }
}

public static class AppBuilderExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
}
