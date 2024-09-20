using Microsoft.EntityFrameworkCore;
using CarDropDownMenu.Models;

namespace CarDropDownMenu.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options) { }

        public DbSet<CarBrand> Carbrands { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Additional model configuration can go here if needed
        }
    }
}
