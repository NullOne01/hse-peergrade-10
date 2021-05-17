using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using CustomersOrders.ViewModel.Utilities;

namespace CustomersOrders.Model {
    [DataContract(IsReference = true)]
    public class Product : INotifyPropertyChanged {
        private string _name;
        private string _vendorCode;
        private uint _costPerStock;
        private string _description;

        [DataMember]
        public string Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [DataMember]
        public string VendorCode {
            get => _vendorCode;
            set {
                _vendorCode = value;
                OnPropertyChanged(nameof(VendorCode));
            }
        }

        [DataMember]
        public uint CostPerStock {
            get => _costPerStock;
            set {
                _costPerStock = value;
                OnPropertyChanged(nameof(CostPerStock));
            }
        }

        [DataMember]
        public string Description {
            get => _description;
            set {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}