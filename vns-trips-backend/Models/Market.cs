using System.Collections.Generic;

namespace vns_trips_backend.Models
{
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string DeliveryEstimate { get; set; }
        public double Rating{ get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }
        public string Hours { get; set; }
    }
}
