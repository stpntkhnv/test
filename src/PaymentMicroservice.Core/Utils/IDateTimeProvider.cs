using System;

namespace PaymentMicroservice.Core.Utils
{
    public interface IDateTimeProvider
    {
        DateTime GetLocalDate { get; }
        DateTime GetUtcDate { get; }
    }
}