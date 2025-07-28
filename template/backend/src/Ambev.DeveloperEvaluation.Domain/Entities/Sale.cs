using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Branch { get; set; } = string.Empty;
    public List<SaleItem> Items { get; set; } = new();
    public bool IsCancelled { get; set; } = false;
    public void CalculateTotal()
    {
        TotalAmount = 0;
        foreach (var item in Items)
            TotalAmount += item.GetTotal();
    }
}