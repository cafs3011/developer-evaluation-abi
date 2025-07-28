using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, Guid>
{
    private readonly ISaleService _saleService;

    public CreateSaleHandler(ISaleService saleService)
    {
        _saleService = saleService;
    }

    public async Task<Guid> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            SaleNumber = $"SALE-{Guid.NewGuid().ToString()[..8]}",
            SaleDate = request.SaleDate,
            CustomerName = request.CustomerName,
            Branch = request.Branch,
            Items = request.Items.ConvertAll(i =>
            {
                if (i.Quantity > 20)
                    throw new ArgumentException($"Cannot sell more than 20 units of {i.ProductName}");

                decimal discount = i.Quantity switch
                {
                    >= 10 => i.Quantity * i.UnitPrice * 0.20m,
                    >= 4 => i.Quantity * i.UnitPrice * 0.10m,
                    _ => 0
                };
                return new SaleItem
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Discount = discount
                };
            })
        };

        sale.CalculateTotal();
        await _saleService.CreateSaleAsync(sale);

        return sale.Id;
    }
}
