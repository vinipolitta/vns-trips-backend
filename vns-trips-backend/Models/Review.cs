using System;

namespace vns_trips_backend.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string comments { get; set; }
        public decimal rating { get; set; }
        public int MarketId { get; set; }
    }
  
}
