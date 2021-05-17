using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomersOrders.Model;

namespace CustomersOrders.ViewModel {
    public class OrderDataViewModel : INotifyPropertyChanged {
        private Order _order;

        public OrderDataViewModel(Order order) {
            Order = order;
        }
        
        public Order Order {
            get => _order;
            set {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}