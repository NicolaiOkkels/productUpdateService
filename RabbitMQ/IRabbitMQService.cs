public interface IRabbitMQService : IDisposable
{
    void Subscribe<T>(string routingKey, Action<T> onMessageReceived);
    void Unsubscribe();
}