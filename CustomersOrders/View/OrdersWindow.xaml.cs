using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CustomersOrders.Model;
using CustomersOrders.ViewModel;

namespace CustomersOrders.View
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow(Shop shop, Customer customer, bool IsActiveOnly = false) {
            InitializeComponent();

            DataContext = new OrdersViewModel(shop, customer, IsActiveOnly);
        }
    }
}
