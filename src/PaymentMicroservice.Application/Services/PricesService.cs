using System.Globalization;
using Microsoft.Extensions.Options;
using PaymentMicroservice.Contracts.Enums;
using PaymentMicroservice.Contracts.Requests.Price;
using PaymentMicroservice.Core.Abstractions;
using PaymentMicroservice.Core.Dtos;
using PaymentMicroservice.Core.Enums;
using PaymentMicroservice.Core.Settings;
using PaymentMicroservice.Core.Utils;
using Stripe;

namespace PaymentMicroservice.Application.Services;

public class PricesService : IPricesService
{
    private const decimal CostMultiplier = 100;
    
    public PricesService(IOptions<StripeSettings> stripeSettings)
    {
        StripeConfiguration.ApiKey = stripeSettings.Value.ApiKey;
    }
    
    public async Task<PriceDto> CreatePriceAsync(CreatePriceRequest request)
    {
        var division = EnumHelpers.ConvertStringToEnum<DivisionEnum>(request.Division);
        var currency = GetCurrencyByDivision(division);
        
        var priceService = new PriceService();
        var priceOptions = new PriceCreateOptions
        {
            UnitAmountDecimal = request.Cost * CostMultiplier,
            Currency = currency,
            Product = request.ProductId,
            Metadata = new Dictionary<string, string>
            {
                {"TakenPlaces", "0"},
                {"TotalPlaces", request.TotalPlaces.ToString()},
                {"StartDate", request.StartDate.ToString(CultureInfo.InvariantCulture)}
            }
        };

        var price = await priceService.CreateAsync(priceOptions);

        return new PriceDto { PriceId = price.Id };
    }
    
    private string GetCurrencyByDivision(DivisionEnum division)
    {
        return division == DivisionEnum.ROI ? CurrencyEnum.EUR.ToString() : CurrencyEnum.GBP.ToString();
    }
}