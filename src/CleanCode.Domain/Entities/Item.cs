namespace CleanCode.Domain.Entities;

public class Item
{
    public Item(int idItem, string category, string description, int price)
    {
        IdItem = idItem;
        Category = category;
        Description = description;
        Price = price;
    }


    public int IdItem { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}
