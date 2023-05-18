using Microsoft.EntityFrameworkCore;
using Nest;
using product_update_service;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();

// Configure the database connection for MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")?
    .Replace("MYSQL_USER", Environment.GetEnvironmentVariable("MYSQL_USER"))
    .Replace("MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Configure GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<WineType>();

// Configure Elasticsearch
var elasticSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("wine-category-index");

var elasticClient = new ElasticClient(elasticSettings);
builder.Services.AddSingleton<IElasticClient>(elasticClient);

//Build the app
var app = builder.Build();

app.UseRouting();

app.MapGraphQL();

app.Run();
