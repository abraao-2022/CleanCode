using System.Text.Json.Serialization;

namespace CleanCode.Application.UseCase.GetOrder;

public class GetOrderOutput
{
    public GetOrderOutput()
    {
    }

    public GetOrderOutput(double total, string orderCode)
    {
        Total = total;
        OrderCode = orderCode;
    }

    [JsonPropertyName("total")]
    public double Total { get; set; }

    [JsonPropertyName("orderCode")]
    public string OrderCode { get; set; }
}
