using System.Runtime.Serialization;

namespace CustomersOrders.Model {
    [DataContract(IsReference = true)]
    public class Seller : User {
        public Seller(string email, string password) : base(email, password) { }
    }
}