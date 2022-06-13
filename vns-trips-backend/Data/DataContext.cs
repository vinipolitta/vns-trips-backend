using Microsoft.EntityFrameworkCore;
using vns_trips_backend.Models;

namespace vns_trips_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        //AQUI CRIAMOS AS TABELAS SE FOR CRIAR E AQUI
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Market> Markets { get; set; }

    }
}
