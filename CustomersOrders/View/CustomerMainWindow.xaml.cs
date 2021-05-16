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
    /// Interaction logic for CustomerMainWindow.xaml
    /// </summary>
    public partial class CustomerMainWindow : Window
    {
        public CustomerMainWindow(Shop shop, Customer customer) {
            InitializeComponent();

            DataContext = new CustomerMainViewModel(shop, customer);
        }
    }
}
