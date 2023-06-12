using System.Text.Json.Serialization;
using CommunityService.Core.Api.Services;
using CommunityService.DataAccessLayer.Context;
using CommunityService.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MemberDb");

//SERVICES
builder.Services.AddTransient<ICommunityService, CommunityService.Core.Api.Services.CommunityService>();
builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();

builder.Services.AddDbContext<CommunityDbContext>(x => x.UseSqlServer(connectionString));
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
    var y = scope.ServiceProvider.GetRequiredService<CommunityDbContext>();
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