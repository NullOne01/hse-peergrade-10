using System.Windows;
using CustomersOrders.Model;
using GalaSoft.MvvmLight.CommandWpf;

namespace CustomersOrders.ViewModel {
    public partial class RegistrationViewModel {
        private RelayCommand _registerCustomerCommand;

        public RelayCommand RegisterCustomerCommand {
            get {
                _registerCustomerCommand = new RelayCommand(() => {
                    var newCustomer =
                        new Customer(Email, Password, FirstName, SecondName, MiddleName, Phone, Address);

                    if (FirstName == "" || SecondName == "" || MiddleName == "" || Phone == "" || Address == "" ||
                        Email == "" || Password == "") {
                        MessageBox.Show("Введите все данные");
                        return;
                    }

                    if (CurrentShop.RegisterUser(newCustomer))
                        MessageBox.Show("Покупатель зарегистрирован");
                    else
                        MessageBox.Show("Такой Email уже зарегистрирован :c");
                });

                return _registerCustomerCommand;
            }
        }

        private RelayCommand _registerSellerCommand;

        public RelayCommand RegisterSellerCommand {
            get {
                _registerSellerCommand = new RelayCommand(() => {
                    var newSeller =
                        new Seller(Email, Password);

                    if (Email == "" || Password == "") {
                        MessageBox.Show("Введите все данные");
                        return;
                    }

                    if (CurrentShop.RegisterUser(newSeller))
                        MessageBox.Show("Продавец зарегистрирован");
                    else
                        MessageBox.Show("Такой Email уже зарегистрирован :c");
                });

                return _registerSellerCommand;
            }
        }
    }
}