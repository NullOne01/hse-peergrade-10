using System.Windows;
using CustomersOrders.Model;
using CustomersOrders.View;
using CustomersOrders.ViewModel.Utilities;
using GalaSoft.MvvmLight.CommandWpf;

namespace CustomersOrders.ViewModel {
    public partial class CustomerMainViewModel {
        private RelayCommand _makeOrderCommand;

        public RelayCommand MakeOrderCommand {
            get {
                _makeOrderCommand = new RelayCommand(() => {
                    if (!CurrentShop.AddOrder(Customer, OrderInProcess)) {
                        MessageBox.Show("Ваш заказ пустой");
                    }

                    OrderInProcess = new Order();
                });

                return _makeOrderCommand;
            }
        }

        private RelayCommand _addProductCommand;

        public RelayCommand AddProductCommand {
            get {
                _addProductCommand = new RelayCommand(() => {
                    OrderInProcess.Products.Add(new OrderProduct() {Product = CurrentShop.Products[0]});
                });

                return _addProductCommand;
            }
        }

        private RelayCommand<Order> _payOrderCommand;

        public RelayCommand<Order> PayOrderCommand {
            get {
                _payOrderCommand = new RelayCommand<Order>((order) => { order.OrderStatus |= OrderStatus.Paid; },
                    (order) =>
                        order != null &&
                        !order.OrderStatus.HasFlag(OrderStatus.Paid) &&
                        order.OrderStatus.HasFlag(OrderStatus.Processed));

                return _payOrderCommand;
            }
        }
        
        private RelayCommand<Order> _showOrderCommand;

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