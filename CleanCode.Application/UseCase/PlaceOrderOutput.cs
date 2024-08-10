namespace CleanCode.Application.UseCase;

public class PlaceOrderOutput
{
    public PlaceOrderOutput(double total)
    {
        Total = total;
    }

    public double Total { get; set; }
}
