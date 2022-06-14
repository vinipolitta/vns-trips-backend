namespace vns_trips_backend.Models
{
    public class MarketItem
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MarketId { get; set; }

    }
}
