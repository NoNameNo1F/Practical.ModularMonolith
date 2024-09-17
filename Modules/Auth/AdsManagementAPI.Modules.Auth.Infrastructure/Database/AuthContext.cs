using AdsManagementAPI.Modules.Auth.Domain.Entities;
using AdsManagementAPI.Modules.Auth.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Database;

public class AuthContext : DbContext
{
    public DbSet<Officer> Officers { get; set; }
    
    private readonly ILoggerFactory _loggerFactory;

    public AuthContext(DbContextOptions options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OfficerConfiguration());
    }
}

// Currently add straight like this.
public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext>
{
    public AuthContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuthModuleDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");

        return new AuthContext(optionsBuilder.Options, null);
    }
}