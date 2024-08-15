using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Repositories;

public interface IItemRepository
{
    Task<List<Item>> FindAllAsync();
    Task<Item> FindByIdAsync(int idItem);
    Task AddAsync(Item item);
}
