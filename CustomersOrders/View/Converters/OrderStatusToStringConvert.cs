using CustomersOrders.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace CustomersOrders.View.Converters {
    class OrderStatusToStringConvert : IValueConverter {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) {
            try {
                string enumString = string.Empty;
                OrderStatus orderStatus = (OrderStatus) value;
                //обработан, оплачен, отгружен, исполнен
                if (orderStatus.HasFlag(OrderStatus.Processed)) {
                    enumString += "обработан ";
                }
                if (orderStatus.HasFlag(OrderStatus.Paid)) {
                    enumString += "оплачен ";
                }
                if (orderStatus.HasFlag(OrderStatus.Shipped)) {
                    enumString += "отгружен ";
                }
                if (orderStatus.HasFlag(OrderStatus.Executed)) {
                    enumString += "исполнен ";
                }

                return enumString;
            } catch {
                return string.Empty;
            }
        }

        // No need to implement converting back on a one-way binding 
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) {
            return null;
        }
    }
}