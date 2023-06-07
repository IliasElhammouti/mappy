using CommunityService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CommunityService.DataAccessLayer.Context;

public class CommunityDbContext: DbContext
{
    public DbSet<Community> Communities { get; set; }

    public CommunityDbContext()
    {
        
    }

    public CommunityDbContext(DbContextOptions<CommunityDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var connectionString = configuration.GetConnectionString("logDb");

        optionsBuilder.UseSqlServer(connectionString);
    }
}