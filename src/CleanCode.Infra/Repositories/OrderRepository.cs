using CleanCode.Domain.DAO;
using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infra.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IOrderDAO _orderDAO;
    private readonly DataContext _context;

    public OrderRepository(IOrderDAO orderDAO, DataContext context)
    {
        _orderDAO = orderDAO;
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

    public async Task<List<Order>> FindAllAsync()
    {
        return await _orderDAO.FindAllAsync();
    }

    public async Task<Order> GetByCodeAsync(string code)
    {
        return await _orderDAO.GetAsync(code);
    }
}
