using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateSaleHandlerTests
{
    private readonly ISaleService _saleService = Substitute.For<ISaleService>();
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _handler = new CreateSaleHandler(_saleService);
    }

    [Fact]
    public async Task Handle_Should_Create_Sale_And_Return_Id()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            CustomerName = "Cliente Teste",
            SaleDate = DateTime.UtcNow,
            Branch = "Matriz",
            Items =
            [
                new CreateSaleItemDto
                {
                    ProductName = "Produto A",
                    Quantity = 2,
                    UnitPrice = 10,
                    Discount = 0
                }
            ]
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeEmpty();
        await _saleService.Received(1).CreateSaleAsync(Arg.Is<Sale>(s =>
            s.CustomerName == command.CustomerName &&
            s.Items.Count == 1 &&
            s.TotalAmount == 20));
    }
}