using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;

namespace CleanCode.Application.UseCase;

public class PlaceOrder
{
    private readonly IItemRepository _itemRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ICouponRepository _couponRepository;

    public PlaceOrder(IItemRepository itemRepository, IOrderRepository orderRepository, ICouponRepository couponRepository)
    {
        _itemRepository = itemRepository;
        _orderRepository = orderRepository;
        _couponRepository = couponRepository;
    }

    public async Task<PlaceOrderOutput> Execute(PlaceOrderInput input)
    {
        var order = new Order(input.Cpf, input.Date);
        foreach (var orderItem in input.OrderItems)
        {
            var item = await _itemRepository.FindById(orderItem.IdItem) 
                ?? throw new Exception("Item not found");
            order.AddItem(item, orderItem.Quantity);
        }

        if (!string.IsNullOrEmpty(input.Coupon))
        {
            var coupon = await _couponRepository.FindByCode(input.Coupon);
            if(coupon != null) order.AddCoupon(coupon);
        }

        await _orderRepository.Add(order);
        var total = order.GetTotal();
        var output = new PlaceOrderOutput(total);
        return output;
    }
}
