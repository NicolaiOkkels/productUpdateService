namespace product_update_service.RabbitMQ
{
    public interface IRabbitMQConsumer : IDisposable
    {
        void Subscribe<T>(string routingKey, Action<T> onMessageReceived);
    }
}