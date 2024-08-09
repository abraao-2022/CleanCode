namespace CleanCode.Domain.Entities;

public class Coupon
{
    public Coupon(string code, int percentage, DateTime expireDate)
    {
        Code = code;
        Percentage = percentage;
        ExpireDate = expireDate;
    }

    public Coupon(string code, int percentage)
    {
        Code = code;
        Percentage = percentage;
    }

    public string Code { get; set; }
    public int Percentage { get; set; }
    public DateTime ExpireDate { get; set; }

    public bool IsValid(DateTime date = default)
    {
        if(ExpireDate == new DateTime()) return true;

        var isDefaultDate = date == default;
        var today = isDefaultDate ? new DateTime(2024, 08, 07) : date;
        return ExpireDate >= today;
        
    }

    public bool IsExpired(DateTime date = default)
    {
        return !IsValid(date);
    }

    public double CalculateDiscount(double amount, DateTime date)
    {
        if (IsExpired(date)) return 0;
        return (amount * Percentage) / 100;
    }
}
