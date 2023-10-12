using AkademiPlusMicroService.Services.Payment.DAL;
using Microsoft.EntityFrameworkCore;

namespace AkademiPlusMicroService.Services.Payment.Context
{
    public class PaymentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1433;database=PaymentDb;user=sa;password=123456aA*");
        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
