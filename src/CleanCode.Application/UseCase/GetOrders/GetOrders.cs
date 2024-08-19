using CleanCode.Application.UseCase.GetOrder;
using CleanCode.Domain.Factory;
using CleanCode.Domain.Repositories;

namespace CleanCode.Application.UseCase.GetOrders;

public class GetOrders
{
    private readonly IRepositoryFactory _repositoryFactory;
    private readonly IOrderRepository _orderRepository;

    public GetOrders(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
        _orderRepository = _repositoryFactory.CreateOrderRepository();
    }

    public async Task<GetOrderOutput> Execute(string code)
    {
        var order = await _orderRepository.GetByCodeAsync(code);
        var getOrderOutput = new GetOrderOutput(order.Total, order.OrderCode.Value);

        return getOrderOutput;
    }
}
