using System;
using PaymentMicroservice.Core.Abstractions;

namespace PaymentMicroservice.Core.Utils
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetLocalDate => DateTime.Now;
        public DateTime GetUtcDate => DateTime.UtcNow;
    }
}