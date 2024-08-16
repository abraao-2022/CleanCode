using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infra.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Orders.CountAsync();
    }
}
