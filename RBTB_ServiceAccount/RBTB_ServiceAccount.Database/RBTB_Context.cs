using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Domains.Entities;

namespace RBTB_ServiceAccount.Database;

public class RBTB_Context:DbContext
{
    public DbSet <Users> Users { get; set; } 
    public DbSet <Trades> Trades { get; set; } 
    public DbSet <Positions> Positions { get; set; }
    public DbSet <Wallet> Wallet { get; set; }
    public RBTB_Context(DbContextOptions<RBTB_Context> options) :base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        
    }
}