using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;

namespace CleanCode.Infra.Repositories.Memory;

public class OrderRepositoryMemory : IOrderRepository
{
    public List<Order> Orders { get; set; } = new();

    public async Task AddAsync(Order order)
    {
        Orders.Add(order);
    }

    public async Task<int> CountAsync()
    {
        return Orders.Count();
    }

    public Task<List<Order>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }
}
