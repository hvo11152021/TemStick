using Microsoft.EntityFrameworkCore;
using ShippingMark.Models;

namespace ShippingMark.Data
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
