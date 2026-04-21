using Microsoft.EntityFrameworkCore;

namespace JCL_Website.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    productID = 1,
                    name = "JCL Headset",
                    price = 59.99f,
                    category = "Headphones",
                    imageSrc = "JCL_Headset.png"
                }
                
            );
        }
        */
    }
}
