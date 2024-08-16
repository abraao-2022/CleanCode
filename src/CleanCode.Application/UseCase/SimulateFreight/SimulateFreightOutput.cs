namespace CleanCode.Application.UseCase.SimulateFreight;

public class SimulateFreightOutput
{
    public SimulateFreightOutput(double amount)
    {
        Amount = amount;
    }

    public double Amount { get; set; }
}
