using Microsoft.EntityFrameworkCore;

namespace WalutyAPI;

public class AppDbContext : DbContext
{
    public DbSet<CurrencyRequest> CurrencyRequests { get; set; }
    public DbSet<RateValue> RateValues { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=waluty.db");
}