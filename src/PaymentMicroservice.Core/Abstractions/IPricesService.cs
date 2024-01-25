using System.Threading.Tasks;
using PaymentMicroservice.Contracts.Requests.Price;
using PaymentMicroservice.Core.Dtos;

namespace PaymentMicroservice.Core.Abstractions
{
    public interface IPricesService
    {
        Task<PriceDto> CreatePriceAsync(CreatePriceRequest request);
    }
}