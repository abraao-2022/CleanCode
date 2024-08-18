using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<int> CountAsync();
    Task<Order> GetByCodeAsync(string code);
}
