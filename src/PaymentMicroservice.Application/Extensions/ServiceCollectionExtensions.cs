using Microsoft.Extensions.DependencyInjection;
using PaymentMicroservice.Application.Services;
using PaymentMicroservice.Core.Abstractions;
using PaymentMicroservice.Core.Utils;

namespace PaymentMicroservice.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPricesService, PricesService>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}