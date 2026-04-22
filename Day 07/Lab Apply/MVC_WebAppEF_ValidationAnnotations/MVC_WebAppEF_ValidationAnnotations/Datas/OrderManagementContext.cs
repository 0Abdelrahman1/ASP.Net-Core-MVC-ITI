using Microsoft.EntityFrameworkCore;
using MVC_WebAppEF_ValidationAnnotations.Models;

namespace MVC_WebAppEF_ValidationAnnotations.Datas
{
    public class OrderManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OrderManagement;User=sa;Password=sa;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
