using CleanCode.Domain.ValueObjects;

namespace CleanCode.Test.Unit.OrderTests;

[TestClass]
public class OrderCodeTest
{
    [TestMethod]
    public void Deve_Gerar_O_Codigo_Do_Pedido()
    {
        var date = new DateTime(2024, 08, 10);
        var sequence = 1;
        var orderCode = new OrderCode(date, sequence);
        Assert.AreEqual("202400000001", orderCode.Value);
    }
}
