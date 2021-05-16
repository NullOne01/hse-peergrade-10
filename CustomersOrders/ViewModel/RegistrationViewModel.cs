using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomersOrders.Model;

namespace CustomersOrders.ViewModel {
    public partial class RegistrationViewModel : ShopInteractionViewModel {
        // eto trash
        private string _firstName;
        private string _secondName;
        private string _middleName;
        private string _phone;
        private string _address;
        private string _email;
        private string _password;

        public string FirstName {
            get => _firstName;
            set {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string SecondName {
            get => _secondName;
            set {
                _secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }

        public string MiddleName {
            get => _middleName;
            set {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        public string Phone {
            get => _phone;
            set {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Address {
            get => _address;
            set {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string Email {
            get => _email;
            set {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password {
            get => _password;
            set {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public RegistrationViewModel(Shop shop) {
            CurrentShop = shop;
        }
    }
}