using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Repositories;

public interface IOrderItemRepository
{
    Task<OrderItem> FindByIdAsync(int idOrderItem);
    Task AddAsync(OrderItem orderItem);
}
