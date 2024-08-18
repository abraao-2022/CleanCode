using System.Text.Json.Serialization;

namespace CleanCode.Application.UseCase;

public class OrderItemInput
{
    [JsonPropertyName("iditem")]
    public int IdItem { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}
