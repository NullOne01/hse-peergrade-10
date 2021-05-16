using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CustomersOrders.Model;
using CustomersOrders.ViewModel.Utilities;
using GalaSoft.MvvmLight.CommandWpf;

namespace CustomersOrders.ViewModel {
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

        private void FillDebugShop(Shop shop) {
            Customer newCustomer = new Customer("1", "1", "1", "1", "1", "1", "1");
            shop.Users.Add(newCustomer);

            Order newOrder = new Order(newCustomer, 1);
            shop.AddOrder(newCustomer, newOrder);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}