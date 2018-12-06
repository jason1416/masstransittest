using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.MessageTypes
{
    public interface IOrderStatusResult
    {
        string OrderId { get; }
        DateTime Timestamp { get; }
        short StatusCode { get; }
        string StatusText { get; }
    }
}
