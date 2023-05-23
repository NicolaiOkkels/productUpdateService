namespace product_update_service.RabbitMQ
{
    public interface IRabbitMQConsumer
    {
        //void Subscribe<T>(string routingKey, Action<T> onMessageReceived);
        public void Subscribe<T>(T message);
    }
}