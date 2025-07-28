using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand>
{
    private readonly ISaleRepository _repository;

    public CancelSaleItemHandler(ISaleRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(request.SaleId);

        var item = sale?.Items.FirstOrDefault(i => i.Id == request.ItemId);
        if (item != null)
        {
            item.IsCancelled = true;
            await _repository.UpdateAsync(sale);
            Console.WriteLine($"[Event] ItemCancelled: Sale={request.SaleId}, Item={request.ItemId}");
        }

    }
}
