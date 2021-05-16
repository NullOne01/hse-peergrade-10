using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace CustomersOrders.Model {
    [DataContract(IsReference = true), KnownType(typeof(Seller)), KnownType(typeof(Customer))]
    public class User : INotifyPropertyChanged{
        private string _email = "kek@kek.com";
        private string _password = "qwerty";

        public User() {
            
        }

        public User(string email, string password) {
            Email = email;
            Password = password;
        }
        
        [DataMember]
        public string Email {
            get => _email;
            set {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        [DataMember]
        public string Password {
            get => _password;
            set {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}