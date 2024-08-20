using CleanCode.Application.Query;
using CleanCode.Application.UseCase.GetOrders;
using CleanCode.Application.UseCase.PlaceOrder;
using CleanCode.Domain.Factory;
using Microsoft.AspNetCore.Mvc;

namespace CleanCode.Application.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IRepositoryFactory _repositoryFactory;

    public OrdersController(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
    }

    [HttpPost]
    public async Task<ActionResult> PlaceOrder(PlaceOrderInput input)
    {
        var placeOrder = new PlaceOrder(_repositoryFactory);
        var output = await placeOrder.Execute(input);

        return Ok(output);
    }
    
    [HttpGet("{code}")]
    public async Task<ActionResult> GetOrder(string code)
    {
        var getOrder = new GetOrderQuery(_repositoryFactory);
        var output = await getOrder.Execute(code);

        return Ok(output);
    }
    
    [HttpGet("")]
    public async Task<ActionResult> GetOrders()
    {
        var getOrders = new GetOrders(_repositoryFactory);
        var output = await getOrders.Execute();

        return Ok(output);
    }
}
