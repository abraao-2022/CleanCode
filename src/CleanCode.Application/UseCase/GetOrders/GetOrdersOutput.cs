using CleanCode.Domain.Entities;
using System.Text.Json.Serialization;

namespace CleanCode.Application.UseCase.GetOrder;

public class GetOrdersOutput
{
    public GetOrdersOutput()
    {
    }

    public GetOrdersOutput(List<Order> orders)
    {
        foreach (var order in orders)
        {
            var getOrderOutput = new GetOrderOutput(order.Total, order.OrderCode.Value);
            Orders.Add(getOrderOutput);
        }
    }

    [JsonPropertyName("orders")]
    public List<GetOrderOutput> Orders { get; set; } = new List<GetOrderOutput>();
}
