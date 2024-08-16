using CleanCode.Application.UseCase;
using CleanCode.Application.UseCase.PlaceOrder;
using CleanCode.Domain.Factory;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.Factory;
using CleanCode.Infra.Repositories.Memory;

namespace CleanCode.Test.Integration;

[TestClass]
public class PlaceOrderTest
{
    private readonly IRepositoryFactory _repositoryFactory = new MemoryRepositoryFactory();

    [TestMethod]
    public async Task Deve_Fazer_Um_Pedido()
    {
        var placeOrder = new PlaceOrder(_repositoryFactory);
        var input = new PlaceOrderInput
        {
            Cpf = "839.435.452-10",
            OrderItems = new List<OrderItemInput>
            {
                new OrderItemInput{IdItem = 1, Quantity = 1},
                new OrderItemInput{IdItem = 2, Quantity = 1},
                new OrderItemInput{IdItem = 3, Quantity = 3},
            },
            Date = new DateTime(2024, 08, 07),
            Coupon = "VALE20"

        };
        var output = await placeOrder.Execute(input);
        Assert.AreEqual(88, output.Total);
    }

    [TestMethod]
    public async Task Deve_Fazer_Um_Pedido_Com_Calculo_De_Frete()
    {
        var placeOrder = new PlaceOrder(_repositoryFactory);
        var input = new PlaceOrderInput
        {
            Cpf = "839.435.452-10",
            OrderItems = new List<OrderItemInput>
            {
                new OrderItemInput{IdItem = 4, Quantity = 1},
                new OrderItemInput{IdItem = 5, Quantity = 1},
                new OrderItemInput{IdItem = 6, Quantity = 3},
            },
            Date = new DateTime(2024, 08, 07)

        };
        var output = await placeOrder.Execute(input);
        Assert.AreEqual(6350, output.Total);
    }

    [TestMethod]
    public async Task Deve_Fazer_Um_Pedido_Com_Codigo()
    {
        var placeOrder = new PlaceOrder(_repositoryFactory);
        var input = new PlaceOrderInput
        {
            Cpf = "839.435.452-10",
            OrderItems = new List<OrderItemInput>
            {
                new OrderItemInput{IdItem = 4, Quantity = 1},
                new OrderItemInput{IdItem = 5, Quantity = 1},
                new OrderItemInput{IdItem = 6, Quantity = 3},
            },
            Date = new DateTime(2024, 08, 07)

        };
        var output = await placeOrder.Execute(input);
        Assert.AreEqual("202400000001", output.Code);
    }
}
