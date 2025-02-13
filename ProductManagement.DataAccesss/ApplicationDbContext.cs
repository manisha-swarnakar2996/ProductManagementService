using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

namespace ProductManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ProductDbModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDbModel>().HasIndex(p => p.UniqueNumber).IsUnique();
        }
    }
}