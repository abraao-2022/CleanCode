
using CleanCode.Domain.Entities;

namespace CleanCode.Test.OrderTests;

[TestClass]
public class OrderItemTest
{

    [TestMethod]
    public void Deve_Criar_Um_Item_Do_Pedido()
    {
        var orderItem = new OrderItem(1, 1000, 10);
        var total = orderItem.GetTotal();

        Assert.AreEqual(10000, total);
    }
}
