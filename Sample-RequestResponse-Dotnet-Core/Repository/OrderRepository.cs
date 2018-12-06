using Sample.MessageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private static List<OrderStatusResult> _orderStatus;

        public async Task<IOrderStatusResult> Get(string orderId)
        {
            return _orderStatus.FirstOrDefault(x => x.OrderId == orderId);
        }

        public OrderRepository(int totalOrderNum)
        {
            if (_orderStatus == null)
            {
                _orderStatus = new List<OrderStatusResult>();
                var statusList = new string[] { "received", "confirmed", "approved", "shipped" };

                for (int i = 1; i <= totalOrderNum; i++)
                {
                    _orderStatus.Add(new OrderStatusResult()
                    {
                        OrderId = i.ToString(),
                        StatusCode = (short)i,
                        StatusText = statusList[i % 4],
                        Timestamp = new DateTime(2018, i, i, i, i, 0)
                    });
                }
            }
        }

        private class OrderStatusResult : IOrderStatusResult
        {
            public string OrderId { get; set; }

            public DateTime Timestamp { get; set; }

            public short StatusCode { get; set; }

            public string StatusText { get; set; }
        }
    }
}
