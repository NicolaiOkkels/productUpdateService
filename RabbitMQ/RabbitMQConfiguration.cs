namespace product_update_service.RabbitMQ{
    public class RabbitMQConfiguration
    {
        public string Hostname { get; set; }
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}