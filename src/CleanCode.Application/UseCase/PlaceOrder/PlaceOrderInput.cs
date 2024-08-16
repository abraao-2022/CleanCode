namespace CleanCode.Application.UseCase.PlaceOrder;

public class PlaceOrderInput
{
    public string Cpf { get; set; }
    public string? Coupon { get; set; }
    public List<OrderItemInput> OrderItems { get; set; } = new();
    public DateTime Date { get; set; }
}
