using CleanCode.Domain.Repositories;
using CleanCode.Domain.Utils;

namespace CleanCode.Application.UseCase.SimulateFreight;

public class SimulateFreight
{
    private readonly IItemRepository _itemRepository;
    private readonly IFreightCalculator _freightCalculator;

    public SimulateFreight(IItemRepository itemRepository, IFreightCalculator freightCalculator)
    {
        _itemRepository = itemRepository;
        _freightCalculator = freightCalculator;
    }

    public async Task<SimulateFreightOutput> Execute(SimulateFreightInput input)
    {
        double amount = 0;
        foreach (var inputItem in input.Items)
        {
            var item = await _itemRepository.FindByIdAsync(inputItem.IdItem);
            if (item == null) throw new Exception("item não encontrado");
            amount += _freightCalculator.Calculate(item) * inputItem.Quantity;
        }
        return new SimulateFreightOutput(amount);
    }
}
