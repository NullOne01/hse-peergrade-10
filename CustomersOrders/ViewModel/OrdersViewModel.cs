using System.Collections.ObjectModel;
using CustomersOrders.Model;

namespace CustomersOrders.ViewModel {
    public partial class OrdersViewModel : ShopInteractionViewModel {
        private ObservableCollection<Order> _orders;

        public OrdersViewModel(Shop shop, Customer customer = null, bool isActiveOnly = false) {
            CurrentShop = shop;
            if (customer != null) {
                Orders = customer.Orders;
            } else {
                Orders = isActiveOnly ? shop.ActiveOrders : shop.Orders;
            }
        }
        
        public ObservableCollection<Order> Orders {
            get => _orders;
            set {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
    }
}