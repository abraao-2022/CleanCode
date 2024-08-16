using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;

namespace CleanCode.Infra.Repositories.Memory;

public class OrderItemRepositoryMemory : IOrderItemRepository
{
    public async Task AddAsync(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderItem> FindByIdAsync(int idOrderItem)
    {
        throw new NotImplementedException();
    }
}
