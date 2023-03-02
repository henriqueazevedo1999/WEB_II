using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Conventions;
using System.Reflection;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext() { }
    public RepositoryContext(DbContextOptions options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(connectionString: @"Data Source=localhost;Initial Catalog=RestAPIFurbDatabase;Persist Security Info=True;
    //                                                    User ID=sa;Password=batatinhaSenhaSegura!;Connect Timeout=5;Encrypt=false"
    //    , x => x.EnableRetryOnFailure(3));

    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new PrefixConvention());
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Comanda> Comandas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
