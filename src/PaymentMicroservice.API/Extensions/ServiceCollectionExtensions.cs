using Microsoft.AspNetCore.Diagnostics;

namespace PaymentMicroservice.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionHandlerMiddleware>();
        return services;
    }
}