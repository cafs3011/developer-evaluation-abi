using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.ORM.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _repository;

    public SaleService(ISaleRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateSaleAsync(Sale sale)
    {
        await _repository.AddAsync(sale);
    }
    public async Task CancelSaleAsync(Guid id)
    {
        var sale = await _repository.GetByIdAsync(id);
        if (sale == null) return;

        sale.IsCancelled = true;
        await _repository.UpdateAsync(sale);

        Console.WriteLine($"[Event] SaleCancelled: {sale.Id}");
    }
}