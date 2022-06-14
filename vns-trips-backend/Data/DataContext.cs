using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using vns_trips_backend.Models;

namespace vns_trips_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        //AQUI CRIAMOS AS TABELAS SE FOR CRIAR E AQUI
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketItem> MarketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //CURSO
        public DbSet<Evento> Eventos { get; set; }
    }
}
