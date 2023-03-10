using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Domains.Entities;

namespace RBTB_ServiceAccount.Database;

public class RBTB_Context:DbContext
{
    public Users Users { get; set; }

    public RBTB_Context(DbContextOptions<RBTB_Context> options) :base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(/*"Host=localhost;Port=5432;Database=postgresql;Username=postgres;Password=123456789"*/);
    }
}