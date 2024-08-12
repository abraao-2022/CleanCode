using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;

namespace CleanCode.Infra.Repositories.Memory;

public class OrderRepositoryMemory : IOrderRepository
{
    public List<Order> Orders { get; set; } = new();

    public async Task Add(Order order)
    {
        Orders.Add(order);
    }

    public async Task<int> Count()
    {
        return Orders.Count();
    }
}
