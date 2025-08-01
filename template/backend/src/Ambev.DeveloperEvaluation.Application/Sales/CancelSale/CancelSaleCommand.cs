﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleCommand : IRequest
{
    public Guid SaleId { get; }

    public CancelSaleCommand(Guid saleId)
    {
        SaleId = saleId;
    }
}


