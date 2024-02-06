using Microsoft.EntityFrameworkCore;
using DbContext = CollabProj.Infrastructure.TopicDbContext;
using Presentation = CollabProj.Server.DependencyInjection;
using Application = CollabProj.Application.DependencyInjection;
using Infrastructure = CollabProj.Infrastructure.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Initialization of Serilog Logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Application.DependencyInjector(builder.Services);
Presentation.DependencyInjector(builder.Services);
Infrastructure.DependencyInjector(builder.Services);

// Setting up database connection 
builder.Services.AddDbContext<DbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection"))
);

// Setting up Redis Distributed Cache connection
builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
    string? connection = builder.Configuration.GetConnectionString("Redis");

    redisOptions.Configuration = connection;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
