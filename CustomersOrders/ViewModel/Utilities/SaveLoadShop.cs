using System.IO;
using System.Runtime.Serialization;
using CustomersOrders.Model;

namespace CustomersOrders.ViewModel.Utilities {
    public static class SaveLoadShop {
        public static void Save(this Shop shop, string path) {
            var serializer = new DataContractSerializer(typeof(Shop));

            using (FileStream stream = new FileStream(path, FileMode.Create)) {
                serializer.WriteObject(stream, shop);
            }
        }

        public static Shop Load(string path) {
            var serializer = new DataContractSerializer(typeof(Shop));
            using (FileStream stream = new FileStream(path, FileMode.Open)) {
                return (Shop) serializer.ReadObject(stream);
            }
        }
    }
}