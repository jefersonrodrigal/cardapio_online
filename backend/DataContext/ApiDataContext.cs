using LanchoneteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteAPI.DataContext
{
    public class ApiDataContext(DbContextOptions<ApiDataContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
