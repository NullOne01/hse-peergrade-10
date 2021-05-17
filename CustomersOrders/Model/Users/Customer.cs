using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace CustomersOrders.Model {
    [DataContract(IsReference = true)]
    public class Customer : User {
        private string _firstName = "FirstName";
        private string _secondName = "SecondName";
        private string _middleName = "MiddleName";
        private string _phoneNumber = "8-800-555-35-35";
        private string _address = "Pushkina street, kolotushkina house";
        private ObservableCollection<Order> _orders = new ObservableCollection<Order>();

        public Customer(string email, string password, string firstName, 
            string secondName, string middleName, string phoneNumber, string address) : base(email, password) {
            // Should have used some factory pattern here, but no shit's given.
            FirstName = firstName;
            SecondName = secondName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        [DataMember]
        public ObservableCollection<Order> Orders {
            get => _orders;
            set {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        [DataMember]
        public string FirstName {
            get => _firstName;
            set {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        [DataMember]
        public string SecondName {
            get => _secondName;
            set {
                _secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }

        [DataMember]
        public string MiddleName {
            get => _middleName;
            set {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        [DataMember]
        public string PhoneNumber {
            get => _phoneNumber;
            set {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        [DataMember]
        public string Address {
            get => _address;
            set {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
    }
}