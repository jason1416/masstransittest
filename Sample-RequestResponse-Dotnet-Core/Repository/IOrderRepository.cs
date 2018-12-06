using Sample.MessageTypes;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
      Task<IOrderStatusResult> Get(string orderId);
    }
}
