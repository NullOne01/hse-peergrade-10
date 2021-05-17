using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CustomersOrders.Model;
using CustomersOrders.ViewModel.Utilities;
using GalaSoft.MvvmLight.CommandWpf;

namespace CustomersOrders.ViewModel {
    /// <summary>
    /// Base class of Views which work with CurrentShop. Have commands which save/load app progress.
    /// </summary>
    public class ShopInteractionViewModel : INotifyPropertyChanged {
        private Shop _currentShop;

        public Shop CurrentShop {
            get => _currentShop;
            set {
                _currentShop = value;
                OnPropertyChanged(nameof(CurrentShop));
            }
        }

        protected RelayCommand _onAppCloseCommand;

        /// <summary>
        /// Command to save last session, when app is closing.
        /// </summary>
        public RelayCommand OnAppCloseCommand {
            get {
                _onAppCloseCommand = new RelayCommand(
                    () => {
                        try {
                            CurrentShop.Save("last_session.xml");
                        } catch {
                            MessageBox.Show("Не получилось сохранить прогресс");
                        }
                    });
                return _onAppCloseCommand;
            }
        }

        private RelayCommand _onAppLoadCommand;

        /// <summary>
        /// Command to load last session on program start.
        /// </summary>
        public RelayCommand OnAppLoadCommand {
            get {
                _onAppLoadCommand = new RelayCommand(
                    () => {
                        try {
                            CurrentShop = SaveLoadShop.Load("last_session.xml");
                        } catch {
                            // If can't load last session, then just load empty shop.
                            CurrentShop = new Shop();
                            
                            FillDebugShop(CurrentShop);
                        }
                    });
                return _onAppLoadCommand;
            }
        }

        /// <summary>
        /// Some debug values. Making ready XML is too boring.
        /// </summary>
        /// <param name="shop"> Shop to fill data into </param>
        private void FillDebugShop(Shop shop) {
            Customer newCustomer1 = new Customer("1", "1", 
                "Влад", "Бумага", "Попитович", "8-800-555-35-35", 
                "Улица Пушкина, дом Колотушкина");
            shop.RegisterUser(newCustomer1);
            
            Customer newCustomer2 = new Customer("3", "3", 
                "Невлад", "Камень", "КтоЯ", "8-800-555-35-35", 
                "Улица Колотушкина, дом Пушкина");
            shop.RegisterUser(newCustomer2);

            Seller newSeller = new Seller("2", "2");
            shop.RegisterUser(newSeller);

            CurrentShop.Products.Add(new Product()
            {
                Name = "Деньги", 
                CostPerStock = 1,
                VendorCode = "A4",
                Description = "Можно купить деньги за деньги"
            });
            CurrentShop.Products.Add(new Product()
            {
                Name = "Молочко", 
                CostPerStock = 2,
                VendorCode = "A1",
                Description = "Молоко - круто"
            });
            CurrentShop.Products.Add(new Product()
            {
                Name = "Симпл-димпл", 
                CostPerStock = 3,
                VendorCode = "eee_rock_1",
                Description = "До сих пор не понимаю, чё это"
            });

            Order newOrder1 = new Order();
            newOrder1.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[0], ProductNum = 1});
            newOrder1.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[1], ProductNum = 2});
            
            Order newOrder2 = new Order() {OrderStatus = OrderStatus.Processed};
            newOrder2.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[2], ProductNum = 1});
            newOrder2.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[1], ProductNum = 3});
            
            Order newOrder3 = new Order() {OrderStatus = OrderStatus.Executed};
            newOrder3.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[0], ProductNum = 1});
            newOrder3.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[1], ProductNum = 1});
            newOrder3.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[2], ProductNum = 1});
            
            shop.AddOrder(newCustomer1, newOrder1);
            shop.AddOrder(newCustomer1, newOrder2);
            shop.AddOrder(newCustomer1, newOrder3);
            
            Order newOrder4 = new Order();
            newOrder4.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[0], ProductNum = 3});
            newOrder4.Products.Add(new OrderProduct(){ Product = CurrentShop.Products[2], ProductNum = 1});
            shop.AddOrder(newCustomer2, newOrder4);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}