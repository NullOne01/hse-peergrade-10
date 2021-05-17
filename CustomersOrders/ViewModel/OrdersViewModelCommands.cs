using CustomersOrders.Model;
using CustomersOrders.View;
using GalaSoft.MvvmLight.CommandWpf;

namespace CustomersOrders.ViewModel {
    public partial class OrdersViewModel {
        private RelayCommand<Order> _showOrderCommand;

        /// <summary>
        /// Command to open window with information about some order.
        /// </summary>
        public RelayCommand<Order> ShowOrderCommand {
            get {
                _showOrderCommand = new RelayCommand<Order>(
                    (order) => {
                        OrderDataWindow orderDataWindow = new OrderDataWindow(order);
                        orderDataWindow.ShowDialog();
                    });

                return _showOrderCommand;
            }
        }
    }
}