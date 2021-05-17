using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace CustomersOrders.Model {
    [DataContract(IsReference = true)]
    public class OrderProduct : INotifyPropertyChanged {
        private Product _product = new Product();
        private uint _productNum = 1;

        [DataMember]
        public Product Product {
            get => _product;
            set {
                _product = value;
                OnPropertyChanged(nameof(Product));
                OnPropertyChanged(nameof(FullCost));
            }
        }

        [DataMember]
        public uint ProductNum {
            get => _productNum;
            set {
                _productNum = value;
                OnPropertyChanged(nameof(ProductNum));
                OnPropertyChanged(nameof(FullCost));
            }
        }
        
        public uint FullCost => ProductNum * Product.CostPerStock;

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}