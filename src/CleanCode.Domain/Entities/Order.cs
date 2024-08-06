using CleanCode.Domain.ValueObjects;

namespace CleanCode.Domain.Entities;

public class Order
{
    public Order(string cpf)
    {
        Cpf = new Cpf(cpf);
    }

    public Cpf Cpf { get; set; }

    public int GetTotal()
    {
        return 0;
    }
}
