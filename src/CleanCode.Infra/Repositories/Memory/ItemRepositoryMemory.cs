using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;

namespace CleanCode.Infra.Repositories.Memory;

public class ItemRepositoryMemory : IItemRepository
{
    public List<Item> Items { get; set; } = new()
    {
        new Item(1, "Música", "CD", 30),
        new Item(2, "Vídeo", "DVD", 50),
        new Item(3, "Vídeo", "VHS", 10),
        new Item(4, "Instrumentos Musicais", "Guitarra", 1000, 100, 30, 10, 3),
        new Item(5, "Instrumentos Musicais", "Amplificador", 5000, 100, 50, 50, 20),
        new Item(6, "Acessórios", "Cabo", 30, 10, 10, 10, 0.9)
};

    public async Task<Item> FindById(int idItem)
    {
        return Items.FirstOrDefault(item => item.IdItem == idItem) 
            ?? throw new Exception("item not found");
    }
}
