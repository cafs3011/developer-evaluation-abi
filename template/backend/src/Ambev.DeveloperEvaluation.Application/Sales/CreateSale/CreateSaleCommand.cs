using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<Guid>
{
    public string CustomerName { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string Branch { get; set; } = string.Empty;
    public List<CreateSaleItemDto> Items { get; set; } = new();
}
public class CreateSaleItemDto
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
