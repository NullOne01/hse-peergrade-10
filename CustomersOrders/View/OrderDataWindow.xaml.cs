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
    /// Interaction logic for OrderDataWindow.xaml
    /// </summary>
    public partial class OrderDataWindow : Window
    {
        public OrderDataWindow(Order order) {
            InitializeComponent();

            DataContext = new OrderDataViewModel(order);
        }
    }
}
