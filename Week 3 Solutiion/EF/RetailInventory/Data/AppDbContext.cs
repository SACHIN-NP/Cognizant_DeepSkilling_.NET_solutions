using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string for LocalDB
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=RetailInventoryDB;Trusted_Connection=true;MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
                
            // Add indexes for better performance
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}