using BARandResto_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//For Connection string 
IConfiguration configuration;
configuration=new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();
builder.Services.AddDbContext<BarandRestoDbContext>(option=>option.UseSqlServer(configuration.GetConnectionString("AppDbConnection")));

//For Cors - Cross origin resource sharing
var allowedOrigins = "_allowedOrigins";
builder.Services.AddCors(options => options.AddPolicy(name: allowedOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost", "http://localhost:5173") //frontend url
              .AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowedToAllowWildcardSubdomains();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
