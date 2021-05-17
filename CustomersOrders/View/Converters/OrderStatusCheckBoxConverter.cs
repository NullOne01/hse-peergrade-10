using System;
using System.Globalization;
using System.Windows.Data;
using CustomersOrders.Model;

namespace CustomersOrders.View.Converters {
    public class OrderStatusCheckBoxConverter : IValueConverter {
        private OrderStatus target;

        public OrderStatusCheckBoxConverter() {
            
        }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            OrderStatus mask = (OrderStatus) parameter;
            target = (OrderStatus) value;
            return (mask & target) != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            target ^= (OrderStatus) parameter;
            return target;
        }
    }
}