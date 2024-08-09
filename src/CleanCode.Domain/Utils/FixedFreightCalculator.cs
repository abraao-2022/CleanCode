using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Utils;

public class FixedFreightCalculator : IFreightCalculator
{
    public double Calculate(Item item)
    {
        return 10;
    }
}
