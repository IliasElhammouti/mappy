
using System.Text.Json.Serialization;
using MemberService.Core.Api.Services;
using MemberService.DataAccessLayer.Context;
using MemberService.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MemberDb");

//SERVICES
builder.Services.AddTransient<IMemberService, MemberService.Core.Api.Services.MemberService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddDbContext<MemberDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("*")
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var y = scope.ServiceProvider.GetRequiredService<MemberDbContext>();
    y.Database.Migrate();
}

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
// Cors
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();