using CleanCode.Application.UseCase;
using CleanCode.Application.UseCase.SimulateFreight;
using CleanCode.Domain.Utils;
using CleanCode.Infra.Repositories.Memory;

namespace CleanCode.Test.Integration;

[TestClass]
public class SimulateFreghtTest
{
    [TestMethod]
    public async Task Deve_Simular_O_Frete()
    {
        var itemRepository = new ItemRepositoryMemory();
        var freightCalculator = new DefaultFreightCalculator();
        var simulateFreight = new SimulateFreight(itemRepository, freightCalculator);
        var input = new SimulateFreightInput
        {
            Items = new List<OrderItemInput>
            {
                new() { IdItem = 4, Quantity = 1},
                new() { IdItem = 5, Quantity = 1},
                new() { IdItem = 6, Quantity = 3},
            }
        };
        var output = await simulateFreight.Execute(input);
        Assert.AreEqual(260, output.Amount);
    }
}
