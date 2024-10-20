using Microsoft.EntityFrameworkCore;
using TemStick.Models;

namespace TemStick.Data
{
    public class ShippingContext : DbContext
    {
        public ShippingContext(DbContextOptions<ShippingContext> options) : base(options)
        {
        }

        public DbSet<CartonLabel> CartonLabels { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
