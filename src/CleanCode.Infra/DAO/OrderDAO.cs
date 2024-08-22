using CleanCode.Domain.DAO;
using CleanCode.Domain.Entities;
using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infra.DAO;

public class OrderDAO : IOrderDAO
{
    private readonly DataContext _context;

    public OrderDAO(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> FindAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetAsync(string code)
    {
        return await _context.Orders.FirstOrDefaultAsync(x => x.OrderCode.Value == code)
            ?? throw new Exception("Pedido não encontrado");
    }
}
