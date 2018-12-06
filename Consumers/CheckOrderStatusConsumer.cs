using MassTransit;
using System;
using Sample.MessageTypes;
using Repository;
using System.Threading.Tasks;

namespace Consumers
{
    public class CheckOrderStatusConsumer : IConsumer<ICheckOrderStatus>
    {
       private readonly IOrderRepository _orderRepository;

        public CheckOrderStatusConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<ICheckOrderStatus> context)
        {
            var order = await _orderRepository.Get(context.Message.OrderId);
            if (order == null)
                throw new InvalidOperationException("Order not found");

            await context.RespondAsync<IOrderStatusResult>(
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
