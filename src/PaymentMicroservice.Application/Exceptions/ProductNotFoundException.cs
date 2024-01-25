using Microsoft.AspNetCore.Http;

namespace PaymentMicroservice.Application.Exceptions;

public class ProductNotFoundException : PaymentException
{
    public ProductNotFoundException(string s) : base(StatusCodes.Status404NotFound, s)
    {
    }
}