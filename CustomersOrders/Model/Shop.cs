using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace CustomersOrders.Model {
    [DataContract]
    public class Shop : INotifyPropertyChanged {
        // Both sellers and customers can be here.
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        private ObservableCollection<Order> _orders = new ObservableCollection<Order>();

        [DataMember]
        public ObservableCollection<User> Users {
            get => _users;
            set {
                _users = value;
                OnPropertyChanged(nameof(Users));
                OnPropertyChanged(nameof(Sellers));
                OnPropertyChanged(nameof(Customers));
            }
        }

        [DataMember]
        public ObservableCollection<Product> Products {
            get => _products;
            set {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        [DataMember]
        public ObservableCollection<Order> Orders {
            get => _orders;
            set {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        // Possible bug here.
        public ObservableCollection<Seller> Sellers =>
            new ObservableCollection<Seller>(Users.Where(x => x is Seller).Cast<Seller>());
        public ObservableCollection<Customer> Customers => 
            new ObservableCollection<Customer>(Users.Where(x => !(x is Seller)).Cast<Customer>());

        private bool WasEmailTaken(string email) {
            return Users.Any(user => user.Email == email);
        }
        
        public User GetCustomerByEmailPassword(string email, string password) {
            return Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void AddOrder(Customer customer, Order order) {
            customer.Orders.Add(order);
            Orders.Add(order);
        }
        
        public bool RegisterUser(User user) {
            if (WasEmailTaken(user.Email))
                return false;
            Users.Add(user);
            return true;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}