using Microsoft.AspNetCore.Mvc;
using PaymentMicroservice.Contracts.Requests.Price;
using PaymentMicroservice.Contracts.Responses.Price;
using PaymentMicroservice.Core.Abstractions;

namespace PaymentMicroservice.API.Controllers;

/// <summary>
/// Controller for managing prices.
/// </summary>
[ApiController]
[Route("[controller]")]
public class PricesController(IPricesService pricesService) : ControllerBase
{
    /// <summary>
    /// Creates a new price based on provided data.
    /// </summary>
    /// <param name="request">The request data for creating a price.</param>
    /// <returns>The response containing the ID of the created price.</returns>
    /// <response code="200">Price successfully created.</response>
    /// <response code="400">Invalid input data.</response>
    [HttpPost]
    public async Task<ActionResult<CreatePriceResponse>> CreatePrice([FromBody] CreatePriceRequest request)
    {
        var dto = await pricesService.CreatePriceAsync(request);
        return Ok(new CreatePriceResponse
        {
            PriceId = dto.PriceId
        });
    }
}