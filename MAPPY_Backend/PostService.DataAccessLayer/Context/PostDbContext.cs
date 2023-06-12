using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostService.DataAccessLayer.Models;

namespace PostService.DataAccessLayer.Context;

public class PostDbContext: DbContext
{
    public DbSet<Post> Posts { get; set; }

    public PostDbContext()
    {
        
    }

    public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("postDb");

        optionsBuilder.UseSqlServer(connectionString);
    }
}