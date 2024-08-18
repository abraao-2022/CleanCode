using System.Text.Json.Serialization;

namespace CleanCode.Application.UseCase.SimulateFreight;

public class SimulateFreightInput
{
    [JsonPropertyName("items")]
    public List<OrderItemInput> Items { get; set; } = new List<OrderItemInput>();
}
