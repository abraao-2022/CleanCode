using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Repositories;

public interface IOrderRepository
{
    Task Add(Order order);
    Task<int> Count();
}
