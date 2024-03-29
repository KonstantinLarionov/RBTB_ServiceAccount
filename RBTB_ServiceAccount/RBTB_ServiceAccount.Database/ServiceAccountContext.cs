using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Abstractions.Entities;

namespace RBTB_ServiceAccount.Database;

public class ServiceAccountContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TradeEntity> Trades { get; set; }
    public DbSet<PositionEntity> Positions { get; set; }
    public DbSet<WalletEntity> Wallet { get; set; }

    public ServiceAccountContext(DbContextOptions<ServiceAccountContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ServiceAccounts;Username=postgres;Password=q1w2e3r4");
    }
}