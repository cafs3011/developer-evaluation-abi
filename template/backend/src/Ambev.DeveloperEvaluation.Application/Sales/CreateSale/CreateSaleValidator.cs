﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty();
        RuleFor(x => x.SaleDate).LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(x => x.Branch).NotEmpty();
        RuleForEach(x => x.Items).SetValidator(new CreateSaleItemValidator());
    }
}
public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemDto>
{
    public CreateSaleItemValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitPrice).GreaterThan(0);
    }
}

