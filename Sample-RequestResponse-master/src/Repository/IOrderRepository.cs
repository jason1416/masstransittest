namespace Repository
{
    using Sample.MessageTypes;
    public interface IOrderRepository
    {
        IOrderStatusResult Get(int orderId);
    }
}
