using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;
using System.Reflection;

namespace RestAPIFurb.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        //iconfiguration?
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                //alterar
                .AddJsonFile("appsettings.Development.json")
                .Build();

        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"), x =>
            {
                x.EnableRetryOnFailure(3);
                x.MigrationsAssembly("RestAPIFurb");
            });

        return new RepositoryContext(builder.Options);
    }
}