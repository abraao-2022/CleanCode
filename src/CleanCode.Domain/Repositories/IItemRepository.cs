using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Repositories;

public interface IItemRepository
{
    Task<Item> FindById(int idItem);
}
