namespace Consumers{
public class CheckOrderStatusConsumer : IConsumer<CheckOrderStatus>
{
    readonly IOrderRepository _orderRepository;

    public CheckOrderStatusConsumer(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Consume(ConsumeContext<CheckOrderStatus> context)
    {
        var order = await _orderRepository.Get(context.Message.OrderId);
        if (order == null)
            throw new InvalidOperationException("Order not found");

        await context.RespondAsync<OrderStatusResult>(
            new 
            {
                OrderId = order.Id,
                Timestamp = order.Timestamp,
                StatusCode = order.StatusCode,
                StatusText = order.StatusText
            }
        )
    }
}
}
