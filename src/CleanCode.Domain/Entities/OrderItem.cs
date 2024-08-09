namespace CleanCode.Domain.Entities;

public class OrderItem
{
    public OrderItem(int idItem, double price, double quantity)
    {
        IdItem = idItem;
        Price = price;
        Quantity = quantity;
    }

    public int IdItem { get; set; }
    public double Price { get; set; }
    public double Quantity { get; set; }

    public double GetTotal()
    {
        return Price * Quantity;
    }
}
