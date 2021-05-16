using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CustomersOrders.Model;

namespace CustomersOrders.ViewModel
{
    public partial class AuthorizationViewModel : ShopInteractionViewModel
    {
        private string _email;
        private string _password;

        public string Email {
            get => _email;
            set {
                _email = value; 
                OnPropertyChanged(nameof(Email));
            }
        }

        // RIP security :c
        public string Password {
            get => _password;
            set {
                _password = value;
                OnPropertyChanged(nameof(Password));

            }
        }
    }
}
