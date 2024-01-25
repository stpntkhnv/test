using System;

namespace PaymentMicroservice.Application.Exceptions;

public class PaymentException : Exception
{
    public int StatusCode { get; }

    protected PaymentException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}