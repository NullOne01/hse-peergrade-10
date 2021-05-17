using System;

namespace CustomersOrders.Model {
    [Flags]
    public enum OrderStatus {
        None = 0,
        Processed = 1,
        Paid = 1 << 1,
        Shipped = 1 << 2,
        Executed = 1 << 3
    }
}