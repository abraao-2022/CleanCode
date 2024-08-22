using CleanCode.Domain.Entities;

namespace CleanCode.Domain.DAO;

public interface IOrderDAO
{
    Task<Order> GetAsync(string code);
    Task<List<Order>> FindAllAsync();
}
