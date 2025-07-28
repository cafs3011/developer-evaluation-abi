using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleHandler : IRequestHandler<CancelSaleCommand>
{
    private readonly ISaleService _saleService;

    public CancelSaleHandler(ISaleService saleService)
    {
        _saleService = saleService;
    }

    public async Task Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        await _saleService.CancelSaleAsync(request.SaleId);
    }
}