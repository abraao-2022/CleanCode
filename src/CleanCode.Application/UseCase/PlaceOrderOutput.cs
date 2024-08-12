namespace CleanCode.Application.UseCase;

public class PlaceOrderOutput
{
    public PlaceOrderOutput(string code, double total)
    {
        Total = total;
        Code = code;
    }

    public double Total { get; set; }
    public string Code { get; set; }
}
