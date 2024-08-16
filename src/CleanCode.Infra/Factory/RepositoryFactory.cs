using CleanCode.Domain.Factory;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.CleanCodeContext;
using CleanCode.Infra.Repositories;

namespace CleanCode.Infra.Factory;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly DataContext _context;

    public RepositoryFactory(DataContext context)
    {
        _context = context;
    }

    public ICouponRepository CreateCouponRepository()
    {
        return new CouponRepository(_context);
    }

    public IItemRepository CreateItemRepository()
    {
        return new ItemRepository(_context);
    }

    public IOrderItemRepository CreateOrderItemRepository()
    {
        return new OrderItemRepository(_context);
    }

    public IOrderRepository CreateOrderRepository()
    {
        return new OrderRepository(_context);
    }
}
