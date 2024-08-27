namespace CleanCode.Domain.Entities;

public class StockEntry
{
    public StockEntry(int itemId, string operation, int quantity, DateTime date = default)
    {
        ItemId = itemId;
        Operation = operation;
        Quantity = quantity;
        Date = date == default ? new DateTime(2024, 08, 07) : date;
    }

    public StockEntry(int itemId, string operation, int quantity)
    {
        ItemId = itemId;
        Operation = operation;
        Quantity = quantity;
        Date = new DateTime(2024, 08, 07);
    }

    public int Id { get; set; }
    public int ItemId { get; set; }
    public string Operation { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
}
