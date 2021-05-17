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

        /// <summary>
        /// Gets user by their email and password if possible.
        /// </summary>
        /// <returns> User if email and password are correct. Null if not. </returns>
        public User GetCustomerByEmailPassword(string email, string password) {
            // Salt right here. No fucks given.
            return Users.FirstOrDefault(x => x.Email == email && User.VerifyHash(password + email, x.Password));
        }

        /// <summary>
        /// Adds customer's order into order list. Checks order and remove some zero values.
        /// </summary>
        /// <returns> True if order was added. Otherwise, false. </returns>
        public bool AddOrder(Customer customer, Order order) {
            if (order.Products.Count <= 0)
                return false;
            if (order.Products.Sum(product => product.ProductNum) <= 0)
                return false;

            // Removing zero-products from the order.
            for (int i = 0; i < order.Products.Count; i++) {
                if (order.Products[i].ProductNum <= 0)
                    order.Products.RemoveAt(i);
            }

            order.DateTimeOrderMade = DateTime.Now;
            order.Id = CurrentID++;
            order.Customer = customer;
            customer.Orders.Add(order);
            Orders.Add(order);

            return true;
        }

        /// <summary>
        /// Registers new user. Check if it is possible.
        /// </summary>
        /// <param name="user"></param>
        /// <returns> True if user was registered. Otherwise, false. </returns>
        public bool RegisterUser(User user) {
            if (WasEmailTaken(user.Email))
                return false;
            // Salt right here. No fucks given.
            user.Password = User.GetHash(user.Password + user.Email);
            Users.Add(user);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}