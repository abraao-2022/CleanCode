namespace CleanCode.Domain.Entities;

public class Item
{
    public Item()
    {
    }
    public Item(int idItem, string category, string description, int price)
    {
        IdItem = idItem;
        Category = category;
        Description = description;
        Price = price;
    }

    public Item(int idItem, string category, string description, int price, int width, int height, int length, double weight) : this(idItem, category, description, price)
    {
        IdItem = idItem;
        Category = category;
        Description = description;
        Price = price;
        Width = width;
        Height = height;
        Length = length;
        Weight = weight;
    }


    public int IdItem { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Width { get; set; } = 0;
    public double Height { get; set; } = 0;
    public double Length { get; set; } = 0;
    public double Weight { get; set; } = 0;

    public double GetVolume()
    {
        return Width / 100 * Height / 100 * Length / 100;
    }

    public double GetDensity()
    {
        return Weight / GetVolume();
    }

    public double CalculateFreight()
    {
        var freight =  1000 * GetVolume() * (GetDensity() / 100);
        var minFreight = 10;
        return Math.Max(minFreight, freight);
    }
}
