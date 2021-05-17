using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CustomersOrders.Model;

namespace CustomersOrders.ViewModel {
    public partial class CustomerMainViewModel : ShopInteractionViewModel {
        private Customer _customer;
        private Order _orderInProcess = new Order();

        public Order OrderInProcess {
            get => _orderInProcess;
            set {
                _orderInProcess = value;
                OnPropertyChanged(nameof(OrderInProcess));
            }
        }

        public Customer Customer {
            get => _customer;
            set {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        public CustomerMainViewModel(Shop shop, Customer customer) {
            CurrentShop = shop;
            Customer = customer;
        }
    }
}