using Microsoft.EntityFrameworkCore;
using ProductsTestTask.Models;

namespace ProductsTestTask.database
{
    class ApplicationContext: DbContext
    {
        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
        }

        public DbSet<Cost> Price { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
    }
}
