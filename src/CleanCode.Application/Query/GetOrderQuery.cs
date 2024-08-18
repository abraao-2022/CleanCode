using CleanCode.Application.UseCase.GetOrder;
using CleanCode.Domain.Factory;

namespace CleanCode.Application.Query;

public class GetOrderQuery
{
    private readonly IRepositoryFactory _repositoryFactory;

    public GetOrderQuery(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
    }

    public async Task<GetOrderOutput> Execute(string code)
    {
        var orderRepository = _repositoryFactory.CreateOrderRepository();
        var order = await orderRepository.GetByCodeAsync(code);
        var getOrderOutput = new GetOrderOutput(order.GetTotal(), order.OrderCode.Value);

        return getOrderOutput;
    }
}
