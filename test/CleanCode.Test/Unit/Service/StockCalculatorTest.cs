using CleanCode.Domain.Entities;
using CleanCode.Domain.Service;

namespace CleanCode.Test.Unit.Service;

[TestClass]
public class StockCalculatorTest
{
    [TestMethod]
    public void Deve_Calcular_O_Estoque_Disponivel_Para_Um_Item()
    {
        var calculator = new StockCalculator();
        var entries = new List<StockEntry> 
        {
            new StockEntry(1, "in", 10, new DateTime(2024, 08, 07, 10, 00, 00)),
            new StockEntry(1, "out", 5, new DateTime(2024, 08, 08, 10, 00, 00))
        };
        var total = calculator.Calculate(entries);

        Assert.AreEqual(5, total);
    }
}
