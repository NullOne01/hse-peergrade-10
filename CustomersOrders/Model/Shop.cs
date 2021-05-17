using System;
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
        private uint _currentId = 0;

        [DataMember]
        public uint CurrentID {
            get => _currentId;
            set {
                _currentId = value;
                OnPropertyChanged(nameof(CurrentID));
            }
        }

        [DataMember]
        public ObservableCollection<User> Users {
            get => _users;
            set {
                _users = value;
                OnPropertyChanged(nameof(Users));
                // Some bug possible?
                Users.CollectionChanged += (sender, args) => {
                    OnPropertyChanged(nameof(Sellers));
                    OnPropertyChanged(nameof(Customers));
                };
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
                OnPropertyChanged(nameof(ActiveOrders));
            }
        }

        public ObservableCollection<Seller> Sellers =>
            new ObservableCollection<Seller>(Users.Where(x => x is Seller).Cast<Seller>());

        public ObservableCollection<Customer> Customers =>
            new ObservableCollection<Customer>(Users.Where(x => !(x is Seller)).Cast<Customer>());

        public ObservableCollection<Order> ActiveOrders =>
            new ObservableCollection<Order>(Orders.Where(x => !x.OrderStatus.HasFlag(OrderStatus.Executed)));

        private bool WasEmailTaken(string email) {
            return Users.Any(user => user.Email == email);
        }

        public User GetCustomerByEmailPassword(string email, string password) {
            return Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public bool AddOrder(Customer customer, Order order) {
            if (order.Products.Count <= 0)
                return false;
            if (order.Products.Sum(product => product.ProductNum) <= 0)
                return false;
            order.DateTimeOrderMade = DateTime.Now;
            order.Id = CurrentID++;
            order.Customer = customer;
            customer.Orders.Add(order);
            Orders.Add(order);

            return true;
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