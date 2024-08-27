using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Service;

public class StockCalculator
{
    public int Calculate(List<StockEntry> stockEntries)
    {
        var total = 0;
        foreach (var stockEntry in stockEntries)
        {
            if (stockEntry.Operation == "in") total += stockEntry.Quantity;
            if (stockEntry.Operation == "out") total -= stockEntry.Quantity;
        }

        return total;
    }
}
