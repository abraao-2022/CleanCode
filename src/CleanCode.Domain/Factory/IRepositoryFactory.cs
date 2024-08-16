using CleanCode.Domain.Repositories;

namespace CleanCode.Domain.Factory;

public interface IRepositoryFactory
{
    IItemRepository CreateItemRepository();
    ICouponRepository CreateCouponRepository();
    IOrderRepository CreateOrderRepository();
    IOrderItemRepository CreateOrderItemRepository();
}
