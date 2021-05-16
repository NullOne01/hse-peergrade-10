using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace CustomersOrders.Model {
    [DataContract(IsReference = true)]
    public class Order : INotifyPropertyChanged {
        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        private DateTime _dateTimeOrderMade = DateTime.Now;
        private Customer _customer;
        private OrderStatus _orderStatus = OrderStatus.None;
        private uint _id;

        public Order() {
            
        }
        
        public Order(Customer customer, uint id) {
            Customer = customer;
            Id = id;
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
        public DateTime DateTimeOrderMade {
            get => _dateTimeOrderMade;
            set {
                _dateTimeOrderMade = value;
                OnPropertyChanged(nameof(DateTimeOrderMade));
            }
        }

        [DataMember]
        public Customer Customer {
            get => _customer;
            set {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        [DataMember]
        public OrderStatus OrderStatus {
            get => _orderStatus;
            set {
                _orderStatus = value;
                OnPropertyChanged(nameof(OrderStatus));
            }
        }

        public uint Id {
            get => _id;
            set {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}