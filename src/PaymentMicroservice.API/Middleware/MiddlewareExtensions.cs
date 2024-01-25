using Microsoft.AspNetCore.Builder;

namespace PaymentMicroservice.API.Middleware;

/// <summary>
/// 
/// </summary>
public static class MiddlewareExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}