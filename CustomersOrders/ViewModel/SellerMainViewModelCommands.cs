using CustomersOrders.Model;
using CustomersOrders.View;
using GalaSoft.MvvmLight.Command;

namespace CustomersOrders.ViewModel {
    public partial class SellerMainViewModel {
        private RelayCommand<Customer> _showOrdersCommand;

        public RelayCommand<Customer> ShowOrdersCommand {
            get {
                _showOrdersCommand = new RelayCommand<Customer>(
                    (customer) => {
                        OrdersWindow customerOrdersWindow = new OrdersWindow(CurrentShop, customer);
                        customerOrdersWindow.ShowDialog();
                    });

                return _showOrdersCommand;
            }
        }
        
        private RelayCommand _showAllOrdersCommand;

        public RelayCommand ShowAllOrdersCommand {
            get {
                _showAllOrdersCommand = new RelayCommand(
                    () => {
                        OrdersWindow customerOrdersWindow = new OrdersWindow(CurrentShop, null);
                        customerOrdersWindow.ShowDialog();
                    });

                return _showAllOrdersCommand;
            }
        }
        
        private RelayCommand _showAllActiveOrdersCommand;

        public RelayCommand ShowAllActiveOrdersCommand {
            get {
                _showAllActiveOrdersCommand = new RelayCommand(
                    () => {
                        OrdersWindow customerOrdersWindow = new OrdersWindow(CurrentShop, null, true);
                        customerOrdersWindow.ShowDialog();
                    });

                return _showAllActiveOrdersCommand;
            }
        }
    }
}