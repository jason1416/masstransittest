namespace Repository
{
    using Sample.MessageTypes;
    public partial class OrderRepository : IOrderRepository
    {
       public  IOrderStatusResult Get(int orderId){
            return new OrderStatusResult{};
       }
        private OrderStatusResult:IOrderStatusResult
        {

        }
    }

}
