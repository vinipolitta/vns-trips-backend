using System.Collections.Generic;

namespace vns_trips_backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string OptionalAddress { get; set; }
        public string PaymentOption { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
