namespace CleanCode.Domain.Entities;

public class OrderItem
{
    public OrderItem()
    {
    }

    public OrderItem(int itemId, double price, double quantity)
    {
        ItemId = itemId;
        Price = price;
        Quantity = quantity;
    }

    public int Id { get; set; }
    public int ItemId { get; set; }
    public int OrderId { get; set; }
    public double Price { get; set; }
    public double Quantity { get; set; }

    public double GetTotal()
    {
        return Price * Quantity;
    }
}
