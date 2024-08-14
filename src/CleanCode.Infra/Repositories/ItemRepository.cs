using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infra.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly DataContext _context;

    public ItemRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Add(Item item)
    {
        if (item == null) throw new ArgumentNullException("item nulo");

        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Item>> FindAll()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item> FindById(int idItem)
    {
        return await _context.Items.FirstOrDefaultAsync(x => x.IdItem == idItem) 
            ?? throw new Exception("item não encontrado");
    }
}
