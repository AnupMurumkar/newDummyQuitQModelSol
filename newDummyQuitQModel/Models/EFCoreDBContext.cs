using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace newDummyQuitQModel.Models
{
    public class EFCoreDBContext :DbContext
    {
        public EFCoreDBContext() { }

        public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var configSection = configBuilder.GetSection("ConnectionStrings");
            var conString = configSection["ConStr"] ?? null;
            //optionsBuilder.UseSqlServer("Server=KHUSHI\\SQLEXPRESS,Databse=EFCoreDemo;" + "Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(conString);

        }

        //Data Source=LAPTOP-8JT18MT0;Initial Catalog=TicketBookingSystem;Integrated Security=True;Encrypt=True;Trust Server Certificate=True

        public DbSet<User> Users { get; set; }
        public DbSet<Seller> SellerDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
