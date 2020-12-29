using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PruebaBCP.Models;

namespace PruebaBCP.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasKey(x => x.Code);
            modelBuilder.Entity<CurrencyExchange>().HasKey(x => new { x.FromCurrencyCode, x.ToCurrencyCode });
            modelBuilder.Entity<CurrencyExchange>().Property(x => x.Rate).HasColumnType("decimal(8,4)");
            modelBuilder.Entity<CurrencyExchange>()
                .HasOne(x => x.FromCurrency)
                .WithMany().HasForeignKey(x => x.FromCurrencyCode)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CurrencyExchange>()
                .HasOne(x => x.ToCurrency).WithMany().HasForeignKey(x => x.ToCurrencyCode)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
