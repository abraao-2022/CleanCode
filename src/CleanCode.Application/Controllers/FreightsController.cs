using CleanCode.Application.UseCase.SimulateFreight;
using CleanCode.Domain.Factory;
using CleanCode.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CleanCode.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FreightsController : ControllerBase
{
    private readonly IRepositoryFactory _repositoryFactory;

    public FreightsController(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
    }

    [HttpPost("simulateFreight")]
    public async Task<ActionResult> SimulateFreight(SimulateFreightInput input)
    {
        var itemRepository = _repositoryFactory.CreateItemRepository();
        var freightCalculator = new DefaultFreightCalculator();
        var simulateFreight = new SimulateFreight(itemRepository, freightCalculator);
        var output = await simulateFreight.Execute(input);

        return Ok(output);
    }
}
