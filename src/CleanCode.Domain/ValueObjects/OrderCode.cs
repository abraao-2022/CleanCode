namespace CleanCode.Domain.ValueObjects;

public class OrderCode
{
    public OrderCode()
    {
    }

    public OrderCode(DateTime date, int sequence)
    {
        Value = GenerateCode(date, sequence);
    }

    public string Value { get; set; }

    public string GenerateCode(DateTime date, int sequence)
    {
        return $"{date.Year}{sequence.ToString().PadLeft(8, '0')}";
    }
}
