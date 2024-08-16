using CleanCode.Domain.Factory;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.Repositories.Memory;

namespace CleanCode.Infra.Factory;

public class MemoryRepositoryFactory : IRepositoryFactory
{
    public ICouponRepository CreateCouponRepository()
    {
        return new CouponRepositoryMemory();
    }

    public IItemRepository CreateItemRepository()
    {
        return new ItemRepositoryMemory();
    }

    public IOrderItemRepository CreateOrderItemRepository()
    {
        return new OrderItemRepositoryMemory();
    }

    public IOrderRepository CreateOrderRepository()
    {
        return new OrderRepositoryMemory();
    }
}
