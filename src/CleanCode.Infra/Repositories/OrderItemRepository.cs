using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infra.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly DataContext _context;

    public OrderItemRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(OrderItem orderItem)
    {
        if (orderItem == null) throw new ArgumentNullException(nameof(orderItem));

        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task<OrderItem> FindByIdAsync(int idOrderItem)
    {
        return await _context.OrderItems.FirstOrDefaultAsync(o => o.IdOrderItem == idOrderItem) 
            ?? throw new Exception("item do pedido não encontrado");
    }
}
