using Microsoft.EntityFrameworkCore;
using TaskOneFinance.Models;

namespace TaskOneFinance.Context
{
    public class ProductDbContext:DbContext

    {
        public ProductDbContext(DbContextOptions<ProductDbContext> context):base(context)
        {
                
        }

       

        public DbSet<User> Users { get; set; }

        public DbSet<Product>Products { get; set; }

        public DbSet<Category>Categories { get; set; }

    }
}
