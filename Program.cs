using Microsoft.EntityFrameworkCore;
using Nest;
using product_update_service.DataAccess;
using product_update_service.Entities;
using product_update_service.GraphQL;
using product_update_service.GraphQL.Types;
using product_update_service.Repositories;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader().WithMethods("GET", "POST");
        });
});

//Register Service
builder.Services.AddScoped<IProductService, ProductService>();

//builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();'

// Configure the database connection for MySQL
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")?
//    .Replace("MYSQL_USER", Environment.GetEnvironmentVariable("MYSQL_USER"))
//    .Replace("MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"))
//    .Replace("PORT", Environment.GetEnvironmentVariable("PORT"));
var connectionString = "server=127.0.0.1;port=3307;database=WineProductDB;user=NyBruger2;password=MinNyePw";

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configure GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<QueryType>();

// Configure Elasticsearch
var elasticSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("wine-category-index");

var elasticClient = new ElasticClient(elasticSettings);
builder.Services.AddSingleton<IElasticClient>(elasticClient);

//Build the app
var app = builder.Build();

app.UseCors();

app.MapGraphQL();

app.Run();
