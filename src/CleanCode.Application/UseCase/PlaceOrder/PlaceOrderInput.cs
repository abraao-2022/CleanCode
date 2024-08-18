using System.Text.Json.Serialization;

namespace CleanCode.Application.UseCase.PlaceOrder;

public class PlaceOrderInput
{
    public PlaceOrderInput()
    {
    }

    public PlaceOrderInput(string cpf, string? coupon, List<OrderItemInput> orderItems, DateTime date)
    {
        Cpf = cpf;
        Coupon = coupon;
        OrderItems = orderItems;
        Date = date;
    }

    [JsonPropertyName("cpf")]
    public string Cpf { get; set; } = "";

    [JsonPropertyName("coupon")]
    public string? Coupon { get; set; }

    [JsonPropertyName("orderitems")]
    public List<OrderItemInput> OrderItems { get; set; } = new();

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
}
