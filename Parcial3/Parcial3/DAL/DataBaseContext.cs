using Microsoft.EntityFrameworkCore;
using Parcial3.DAL.Entities;
using System.Net.Sockets;

namespace Parcial3.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext>options) : base(options)
        {

        }
        public DbSet<Service> Services  { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().HasIndex(v => v.NumberPlate).IsUnique();
            modelBuilder.Entity<Service>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<VehicleDetail>().HasIndex(d => d.VehiculeId).IsUnique();
        }


    }
}
