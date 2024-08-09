using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Utils;

public interface IFreightCalculator
{
    double Calculate(Item item);
}
