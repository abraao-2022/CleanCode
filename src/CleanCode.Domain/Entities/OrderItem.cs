namespace CleanCode.Domain.Entities;

public class OrderItem
{
    public OrderItem(int idItem, int price, int quantity)
    {
        IdItem = idItem;
        Price = price;
        Quantity = quantity;
    }

    public int IdItem { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public int GetTotal()
    {
        return Price * Quantity;
    }
}
