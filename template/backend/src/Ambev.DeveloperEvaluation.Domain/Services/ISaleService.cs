using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface ISaleService
{
    Task CreateSaleAsync(Sale sale);
    Task CancelSaleAsync(Guid id);
}