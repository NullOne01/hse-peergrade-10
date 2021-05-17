using CustomersOrders.Model;

namespace CustomersOrders.ViewModel {
    public partial class SellerMainViewModel : ShopInteractionViewModel {
        private Seller _seller;

        public Seller Seller {
            get => _seller;
            set {
                _seller = value;
                OnPropertyChanged(nameof(Seller));
            }
        }
        
        public SellerMainViewModel(Shop shop, Seller seller) {
            CurrentShop = shop;
            Seller = seller;
        }
    }
}