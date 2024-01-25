using System;

namespace PaymentMicroservice.Contracts.Requests.Price
{
    public class CreatePriceRequest
    {
        public string ProductId { get; }
        public decimal Cost { get; }
        public DateTime StartDate { get; }
        public string Division { get; }
        public int TotalPlaces { get; }
        
        public CreatePriceRequest(string productId, decimal cost, DateTime startDate, int totalPlaces, string division)
        {
            ProductId = productId;
            Cost = cost;
            StartDate = startDate;
            Division = division;
            TotalPlaces = totalPlaces;
        }
    }
}