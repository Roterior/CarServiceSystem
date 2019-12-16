using CarServiceSystem.src.entity;
using System.Data.Entity;

namespace CarServiceSystem.src.util
{
    class Context : DbContext
    {
        public Context() : base("dbConnect") { }

        public DbSet<Client> Client { get; set; }

        public DbSet<CarClient> CarClient { get; set; }

        public DbSet<OrderRepair> OrderRepair { get; set; }
    }
}
