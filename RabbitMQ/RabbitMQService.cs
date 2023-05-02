using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMQService : IRabbitMQService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;
    private readonly string _exchangeName;
    private EventingBasicConsumer _consumer;
    private string _consumerTag;

    public RabbitMQService(IConfiguration configuration)
    {
        var rabbitMQConfig = configuration.GetSection("RabbitMQ");
        var factory = new ConnectionFactory()
        {
            HostName = rabbitMQConfig["Hostname"],
            UserName = rabbitMQConfig["UserName"],
            Password = rabbitMQConfig["Password"],
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _queueName = rabbitMQConfig["QueueName"];
        _exchangeName = rabbitMQConfig["ExchangeName"];
        _channel.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
        _channel.ExchangeDeclare(_exchangeName, ExchangeType.Topic);
    }

    public void Subscribe<T>(string routingKey, Action<T> onMessageReceived)
    {
        _channel.QueueBind(_queueName, _exchangeName, routingKey);

        _consumer = new EventingBasicConsumer(_channel);
        _consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var deserializedMessage = JsonSerializer.Deserialize<T>(message);
            onMessageReceived(deserializedMessage);
        };

        _consumerTag = _channel.BasicConsume(_queueName, autoAck: true, _consumer);
    }

    public void Unsubscribe()
    {
        _channel.BasicCancel(_consumerTag);
        _channel.QueueUnbind(_queueName, _exchangeName, "#");
    }

    public void Dispose()
    {
        _channel.Dispose();
        _connection.Dispose();
    }
}