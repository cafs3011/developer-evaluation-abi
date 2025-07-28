using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.Sales;

public class CreateSaleIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CreateSaleIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Create_Sale_And_Return_201()
    {
        var command = new CreateSaleCommand
        {
            CustomerName = "Integration Test Customer",
            SaleDate = DateTime.UtcNow,
            Branch = "Online",
            Items =
            [
                new CreateSaleItemDto
                {
                    ProductName = "Mouse",
                    Quantity = 5,
                    UnitPrice = 100,
                    Discount = 0
                }
            ]
        };

        var response = await _client.PostAsJsonAsync("/api/sales", command);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var result = await response.Content.ReadFromJsonAsync<Dictionary<string, Guid>>();
        result.Should().ContainKey("id");
        result["id"].Should().NotBeEmpty();
    }
}