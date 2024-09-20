using Microsoft.EntityFrameworkCore;
using CarDropDownMenu.Models;

namespace CarDropDownMenu.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {
        }

        // DbSets representing the tables in the database
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarBrandCarMakeMatrix> CarBrandCarMakeMatrix { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the many-to-many relationship between CarBrand and CarMake via CarBrandCarMakeMatrix
            modelBuilder.Entity<CarBrandCarMakeMatrix>()
                .HasKey(cm => new { cm.CarBrandId, cm.CarMakeId }); // Composite primary key

            modelBuilder.Entity<CarBrandCarMakeMatrix>()
                .HasOne(cm => cm.CarBrand)
                .WithMany(b => b.CarBrandCarMakeMatrix)
                .HasForeignKey(cm => cm.CarBrandId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: specify how deletions are handled

            modelBuilder.Entity<CarBrandCarMakeMatrix>()
                .HasOne(cm => cm.CarMake)
                .WithMany(m => m.CarBrandCarMakeMatrix)
                .HasForeignKey(cm => cm.CarMakeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
