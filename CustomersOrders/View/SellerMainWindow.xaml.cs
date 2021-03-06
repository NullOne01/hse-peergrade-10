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
    /// Interaction logic for SellerMainWindow.xaml
    /// </summary>
    public partial class SellerMainWindow : Window
    {
        public SellerMainWindow(Shop shop, Seller seller) {
            InitializeComponent();

            DataContext = new SellerMainViewModel(shop, seller);
        }
    }
}
