using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using product_update_service;
using product_update_service.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();

// Configure the database connection for MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")?
    .Replace("MYSQL_USER", Environment.GetEnvironmentVariable("MYSQL_USER"))
    .Replace("MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<WineType>();

var app = builder.Build();

app.UseRouting();

app.MapGraphQL();

app.Run();
