using CleanCode.Domain.Entities;
using CleanCode.Domain.Factory;
using CleanCode.Domain.Repositories;
using CleanCode.Domain.Utils;

namespace CleanCode.Application.UseCase.PlaceOrder;

public class PlaceOrder
{
    private readonly IItemRepository _itemRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ICouponRepository _couponRepository;
    private readonly IRepositoryFactory _repositoryFactory;

    public PlaceOrder(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
        _itemRepository = repositoryFactory.CreateItemRepository();
        _orderRepository = repositoryFactory.CreateOrderRepository();
        _couponRepository = repositoryFactory.CreateCouponRepository();
    }

    public async Task<PlaceOrderOutput> Execute(PlaceOrderInput input)
    {
        var sequence = await _orderRepository.CountAsync() + 1;
        var order = new Order(input.Cpf, input.Date, new DefaultFreightCalculator(), sequence);
        foreach (var orderItem in input.OrderItems)
        {
            var item = await _itemRepository.FindByIdAsync(orderItem.IdItem)
                ?? throw new Exception("Item not found");
            order.AddItem(item, orderItem.Quantity);
        }

        if (!string.IsNullOrEmpty(input.Coupon))
        {
            var coupon = await _couponRepository.FindByCodeAsync(input.Coupon);
            if (coupon != null) order.AddCoupon(coupon);
        }

        await _orderRepository.AddAsync(order);
        var total = order.GetTotal();
        var output = new PlaceOrderOutput(order.GetCode(), total);
        return output;
    }
}
