using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentMicroservice.Application.Exceptions;

namespace PaymentMicroservice.API.Middleware;

public class ExceptionHandlerMiddleware(IWebHostEnvironment env, ILogger<ExceptionHandlerMiddleware> logger)
    : IMiddleware
{
    private static readonly ConcurrentDictionary<Type, string> Codes = new();

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context).ConfigureAwait(false);
        }
        catch (PaymentException ex)
        {
            var errorCode = GetErrorCode(ex);
            await WriteErrorAsync(context, new ErrorView(errorCode, ex.Message), ex.StatusCode);
        }
        catch (Exception ex)
        {
            if (env.IsDevelopment())
            {
                throw;
            }

            logger.LogError(ex, $"Exception: {ex.Message}");

            await WriteErrorAsync(context, new ErrorView(
                    "internal_server_error",
                    "An unexpected error occurred."),
                StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task WriteErrorAsync(HttpContext context, ErrorView error, int statusCode)
    {
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }

    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        return Codes.GetOrAdd(type, type.Name.Underscore().Replace("_exception", string.Empty));
    }
}