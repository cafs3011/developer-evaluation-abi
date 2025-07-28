﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.SalesFeature
{
    public class SaleResponse
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItemResponse> Items { get; set; } = new();
    }
}
