using System;
using FluentValidation;
using PaymentMicroservice.Contracts.Requests.Price;
using PaymentMicroservice.Core.Utils;

namespace PaymentMicroservice.API.Validators;

/// <summary>
/// 
/// </summary>
public class CreatePriceRequestValidator : AbstractValidator<CreatePriceRequest>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    
    /// <summary>
    /// 
    /// </summary>
    public CreatePriceRequestValidator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
        
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required.");

        RuleFor(x => x.Cost)
            .GreaterThan(0)
            .WithMessage("Cost must be greater than zero.");

        RuleFor(x => x.Division)
            .NotEmpty()
            .WithMessage("Division is required.");

        RuleFor(x => x.StartDate)
            .Must(BeAValidDate)
            .WithMessage("Start date must be in the future.");

        RuleFor(x => x.TotalPlaces)
            .GreaterThan(0)
            .WithMessage("Places must be at least 1.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return date > _dateTimeProvider.GetUtcDate;
    }
}