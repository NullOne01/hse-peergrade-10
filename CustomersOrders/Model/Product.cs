using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using CustomersOrders.ViewModel.Utilities;

namespace CustomersOrders.Model {
    [DataContract]
    public class Product : INotifyPropertyChanged {
        private string _name;
        private string _vendorCode;
        private uint _costPerStock;
        private string _description;

        /// <summary>
        /// Generates Product with random property values.
        /// </summary>
        /// <param name="random"> Random object. </param>
        /// <returns> Randomized product. </returns>
        public static Product CreateRandomProduct(Random random) {
            return new Product()
            {
                Name = random.RandomString(10),
                VendorCode = random.RandomString(5),
                CostPerStock = (uint) random.Next(1, 101),
                Description = random.RandomString(15)
            };
        }

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

        // Additional functionality.
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