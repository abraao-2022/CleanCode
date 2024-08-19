using CleanCode.Domain.Utils;
using CleanCode.Domain.ValueObjects;

namespace CleanCode.Domain.Entities;

public class Order
{
    public Order()
    {
    }

    public Order(string cpf, DateTime date, IFreightCalculator? freightCalculator = null, int sequence = 1)
    {
        Cpf = new Cpf(cpf);
        Date = date;
        FreightCalculator = freightCalculator ?? new DefaultFreightCalculator();
        OrderCode = new OrderCode(Date, sequence);
    }

    public Order(string cpf, IFreightCalculator? freightCalculator = null, int sequence = 1)
    {
        Cpf = new Cpf(cpf);
        Date = new DateTime(2024, 08, 07);
        FreightCalculator = freightCalculator ?? new DefaultFreightCalculator();
        OrderCode = new OrderCode(Date, sequence);
    }

    public int Id { get; set; }
    //public string Code { get; set; }
    public Cpf Cpf { get; set; }
    public Coupon? Coupon { get; set; }
    public string? CouponCode { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
    public DateTime Date { get; set; }
    public double Freight { get; set; }
    public double Total { get; set; }
    public IFreightCalculator? FreightCalculator { get; set; } = new DefaultFreightCalculator();
    public OrderCode? OrderCode { get; set; }
    public int Sequence { get; set; } = 1;

    public void AddItem(Item item, int quantity)
    {
        if (item.Width != 0 && item.Weight != 0 && item.Height != 0 && item.Length != 0)
        {
            Freight += FreightCalculator.Calculate(item) * quantity;
        }
        OrderItems.Add(new OrderItem(item.Id, item.Price, quantity));
        Total = GetTotal();
    }

    public void AddCoupon(Coupon coupon)
    {
        if (coupon.IsValid(Date))
        {
            Coupon = coupon;
            CouponCode = coupon.Code;
        }
    }

    public double GetFreight()
    {
        return Freight;
    }

    public string GetCode()
    {
        return OrderCode.Value;
    }

    public double GetTotal()
    {
        if (OrderItems.Count < 1) return 0;

        double total = 0;
        foreach (var orderItem in OrderItems)
        {
            total += orderItem.GetTotal();
        }

        if (Coupon != null)
        {
            total -= Coupon.CalculateDiscount(total, Date);
        }

        total += GetFreight();

        return total;
    }
}
