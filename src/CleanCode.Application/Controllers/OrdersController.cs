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
    public async Task<ActionResult> PlaceOrder()
    {
        var placeOrder = new PlaceOrder(_repositoryFactory);
        return Ok();
    }
}
