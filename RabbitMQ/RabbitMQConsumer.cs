using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using product_update_service.RabbitMQ;

namespace product_update_service.RabbitMQ
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        private readonly RabbitMQConfiguration _rabbitMQConfig;
        public RabbitMQConsumer(RabbitMQConfiguration rabbitMQConfig)
        {
            _rabbitMQConfig = rabbitMQConfig;
        }


        public void Subscribe<T>(T message)
        {

            var factory = new ConnectionFactory()
            {
                HostName = _rabbitMQConfig.Hostname,
                UserName = _rabbitMQConfig.UserName,
                Password = _rabbitMQConfig.Password,
            };

            var conn = factory.CreateConnection();

            using var channel = conn.CreateModel();

            channel.QueueDeclare("wines", durable: true, exclusive: false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, eventArgs) =>
            {
                // getting my byte[]
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"New ticket processing is initiated - {message}");

            };

            channel.BasicConsume("wines", true, consumer);
        }
    }
}




/* 
private readonly IConnection _connection;
private readonly IModel _channel;
private readonly string _queueName;
private readonly string _exchangeName;
private EventingBasicConsumer _consumer;
private string _consumerTag;

public RabbitMQConsumer(IConfiguration configuration)
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
    _queueName = rabbitMQConfig["QueueName"]!;
    _exchangeName = rabbitMQConfig["ExchangeName"]!;
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
        onMessageReceived(deserializedMessage!);
    };

    _consumerTag = _channel.BasicConsume(_queueName, autoAck: true, _consumer);
}

public void Dispose()
{
    _channel.Dispose();
    _connection.Dispose();
}
} 
}*/