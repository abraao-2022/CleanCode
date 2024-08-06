using CleanCode.Domain.ValueObjects;

namespace CleanCode.Domain.Entities;

public class Order
{
    public Order(string cpf)
    {
        Cpf = new Cpf(cpf);
    }

    public Cpf Cpf { get; set; }
    public Coupon? Coupon { get; set; }
    public List<OrderItem> OrderItems { get; set; } =  new();

    public void AddItem(Item item, int quantity)
    {
        OrderItems.Add(new OrderItem(item.IdItem, item.Price, quantity));
    }

    public void AddCoupon(Coupon coupon)
    {
        Coupon = coupon;
    }

    public int GetTotal()
    {
        if (OrderItems.Count < 1) return 0;

        var total = 0;
        foreach (var orderItem in OrderItems)
        {
            total += orderItem.GetTotal();
        }

        if (Coupon != null)
        {
            total -= (total * Coupon.Percentage) / 100;
        }

        return total;
    }
}
