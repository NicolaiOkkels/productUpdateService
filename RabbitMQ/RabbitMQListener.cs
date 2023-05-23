using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using product_update_service.Entities;
using product_update_service.Repositories;

namespace product_update_service.RabbitMQ
{
public class RabbitMQListenerService : BackgroundService
{
    private readonly IConnection connection;
    private readonly IModel channel;
    private readonly IServiceProvider services;

    public RabbitMQListenerService(IServiceProvider services)
    {
        this.services = services;
        var factory = new ConnectionFactory() { HostName = "localhost" }; // or your RabbitMQ host
        connection = factory.CreateConnection();
        channel = connection.CreateModel();
        channel.QueueDeclare(queue: "wineQueue",
                             durable: false,
                             exclusive: false,
                             autoDelete: true);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            var wine = JsonConvert.DeserializeObject<Wine>(message);

            // Scope the service provider to the ProductService
            using var scope = services.CreateScope();
            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
            productService.CreateWineAsync(wine).GetAwaiter().GetResult();
        };

        channel.BasicConsume(queue: "wineQueue",
                             autoAck: true,
                             consumer: consumer);
        
        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        channel.Close();
        connection.Close();
        base.Dispose();
    }
}
}