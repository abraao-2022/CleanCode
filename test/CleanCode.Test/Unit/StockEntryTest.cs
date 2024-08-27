using CleanCode.Domain.Entities;

namespace CleanCode.Test.Unit;

[TestClass]
public class StockEntryTest
{
    [TestMethod]
    public void Deve_Criar_Uma_Entrada_No_Estoque()
    {
        var stockEntry = new StockEntry(1, "in", 10, new DateTime(2024, 08, 07, 10, 00, 00));
        Assert.AreEqual(1, stockEntry.ItemId);
        Assert.AreEqual("in", stockEntry.Operation);
        Assert.AreEqual(10, stockEntry.Quantity);
        Assert.AreEqual(new DateTime(2024, 08, 07, 10, 00, 00), stockEntry.Date);
    }
}
