using System;

namespace PaymentMicroservice.Contracts.Requests.Price
{
    public class UpdatePriceRequest
    {
        public decimal Cost { get; }
        public DateTime StartDate { get; }
        public string Division { get; }
        public int TotalPlaces { get; }
        public int TakenPlaces { get; }

        public UpdatePriceRequest(decimal cost, DateTime startDate, string division, int totalPlaces, int takenPlaces)
        {
            Cost = cost;
            StartDate = startDate;
            Division = division;
            TotalPlaces = totalPlaces;
            TakenPlaces = takenPlaces;
        }
    }
}