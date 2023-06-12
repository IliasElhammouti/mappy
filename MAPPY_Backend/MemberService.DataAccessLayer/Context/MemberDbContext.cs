using MemberService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MemberService.DataAccessLayer.Context;

public class MemberDbContext : DbContext
{
    public DbSet<Member> Members { get; set; }

    public MemberDbContext()
    {
        
    }

    public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var connectionString = configuration.GetConnectionString("memberDb");

        optionsBuilder.UseSqlServer(connectionString);
    }
}