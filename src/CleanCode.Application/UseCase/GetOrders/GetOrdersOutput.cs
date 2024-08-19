using System.Text.Json.Serialization;

namespace CleanCode.Application.UseCase.GetOrder;

public class GetOrdersOutput
{
    public GetOrdersOutput()
    {
    }

    [JsonPropertyName("orders")]
    public List<GetOrderOutput> Orders { get; set; }
}
