using System.Text.Json.Serialization;

namespace CleanCode.Application.UseCase.PlaceOrder;

public class PlaceOrderOutput
{
    public PlaceOrderOutput(string code, double total)
    {
        Total = total;
        Code = code;
    }

    [JsonPropertyName("total")]
    public double Total { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }
}
