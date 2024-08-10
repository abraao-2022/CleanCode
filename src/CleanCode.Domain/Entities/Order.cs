using CleanCode.Domain.Utils;
using CleanCode.Domain.ValueObjects;

namespace CleanCode.Domain.Entities;

public class Order
{
    public Order(string cpf, DateTime date, IFreightCalculator? freightCalculator = null)
    {
        Cpf = new Cpf(cpf);
        Date = date;
        FreightCalculator = freightCalculator ?? new DefaultFreightCalculator();
    }

    public Order(string cpf, IFreightCalculator? freightCalculator = null)
    {
        Cpf = new Cpf(cpf);
        Date = new DateTime(2024, 08, 07);
        FreightCalculator = freightCalculator ?? new DefaultFreightCalculator();
    }

    public Cpf Cpf { get; set; }
    public Coupon? Coupon { get; set; }
    private List<OrderItem> OrderItems { get; set; } = new();
    public DateTime Date { get; set; }
    private double Freight { get; set; }
    private IFreightCalculator FreightCalculator { get; set; }

    public void AddItem(Item item, int quantity)
    {
        if (item.Width != 0 && item.Weight != 0 && item.Height != 0 && item.Length != 0)
        {
            Freight += FreightCalculator.Calculate(item) * quantity;
        }
        OrderItems.Add(new OrderItem(item.IdItem, item.Price, quantity));
    }

    public void AddCoupon(Coupon coupon)
    {
        if (coupon.IsValid(Date))
        {
            Coupon = coupon;
        }
    }

    public double GetFreight()
    {
        return Freight;
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
