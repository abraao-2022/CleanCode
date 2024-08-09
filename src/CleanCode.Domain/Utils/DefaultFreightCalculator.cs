using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Utils;

public class DefaultFreightCalculator : IFreightCalculator
{
    public double Calculate(Item item)
    {
        var freight = 1000 * item.GetVolume() * (item.GetDensity() / 100);
        var minFreight = 10;
        return Math.Max(minFreight, freight);
    }
}
