﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.SalesFeature;

public class SaleItemResponse
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Total => (UnitPrice * Quantity) - Discount;
}
