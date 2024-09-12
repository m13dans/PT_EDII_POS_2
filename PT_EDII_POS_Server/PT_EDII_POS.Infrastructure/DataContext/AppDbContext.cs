using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.Domain.Items;
using PT_EDII_POS.Domain.Transactions;
using PT_EDII_POS.Domain.Users;

namespace PT_EDII_POS.Infrastructure.DataContext;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
