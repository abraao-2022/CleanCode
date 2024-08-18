using System.Text.Json.Serialization;

namespace CleanCode.Application.UseCase.SimulateFreight;

public class SimulateFreightOutput
{
    public SimulateFreightOutput(double amount)
    {
        Amount = amount;
    }

    [JsonPropertyName("amount")]
    public double Amount { get; set; }
}
