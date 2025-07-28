
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.SalesFeature;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;

    public SalesController(IMediator mediator, ISaleRepository repository, IMapper mapper)
    {
        _mediator = mediator;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSaleCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var sale = await _repository.GetByIdAsync(id);
        if (sale == null)
            return NotFound();

        var dto = _mapper.Map<SaleResponse>(sale);
        return Ok(new { dto, dto.IsCancelled });
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sales = await _repository.GetAllAsync();
        var dtos = _mapper.Map<List<SaleResponse>>(sales);
        return Ok(dtos);
    }
    [HttpPatch("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await _mediator.Publish(new CancelSaleCommand(id));
        return NoContent();
    }
    [HttpPatch("{saleId:guid}/items/{itemId:guid}/cancel")]
    public async Task<IActionResult> CancelItem(Guid saleId, Guid itemId)
    {
        await _mediator.Send(new CancelSaleItemCommand(saleId, itemId));
        return NoContent();
    }
}