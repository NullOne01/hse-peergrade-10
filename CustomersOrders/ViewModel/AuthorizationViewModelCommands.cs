using System.Windows;
using CustomersOrders.Model;
using CustomersOrders.View;
using CustomersOrders.ViewModel.Utilities;
using GalaSoft.MvvmLight.CommandWpf;

namespace CustomersOrders.ViewModel {
    public partial class AuthorizationViewModel {
        private RelayCommand _authorizationCommand;

        public RelayCommand AuthorizationCommand {
            get {
                _authorizationCommand = new RelayCommand(() => {
                    User user = CurrentShop.GetCustomerByEmailPassword(Email, Password);
                    if (user == null) {
                        MessageBox.Show("Такого юзера нет");
                    }

                    // TODO: close
                    if (user is Customer customer) {
                        CustomerMainWindow customerMainWindow = new CustomerMainWindow(CurrentShop, customer);
                        customerMainWindow.Show();
                    }

                    if (user is Seller seller) {
                        SellerMainWindow sellerMainWindow = new SellerMainWindow(CurrentShop, seller);
                        sellerMainWindow.Show();
                    }
                });

                return _authorizationCommand;
            }
        }

        private RelayCommand _registrationCommand;

        public RelayCommand RegistrationCommand {
            get {
                _registrationCommand = new RelayCommand(() => {
                    var registrationWindow = new RegistrationWindow(CurrentShop);
                    registrationWindow.ShowDialog();
                });
                return _registrationCommand;
            }
        }
    }
}