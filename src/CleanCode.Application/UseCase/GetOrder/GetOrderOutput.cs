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

    public double Total { get; set; }
    public string OrderCode { get; set; }
}
