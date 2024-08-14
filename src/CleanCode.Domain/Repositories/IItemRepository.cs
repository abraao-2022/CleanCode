using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Repositories;

public interface IItemRepository
{
    Task<List<Item>> FindAll();
    Task<Item> FindById(int idItem);
    Task Add(Item item);
}
