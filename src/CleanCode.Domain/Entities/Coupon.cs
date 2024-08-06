namespace CleanCode.Domain.Entities;

public class Coupon
{
    public Coupon(string code, int percentage)
    {
        Code = code;
        Percentage = percentage;
    }

    public string Code { get; set; }
    public int Percentage { get; set; }
}
