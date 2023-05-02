using HotChocolate.Execution;
using HotChocolate.Subscriptions.IEventStream;
public class Subscription
{
    private readonly IEventStream _eventStream;

    public Subscription(IEventStream eventStream)
    {
        _eventStream = eventStream;
    }

    [Subscribe]
    [Topic("wine.create")]
    public Wine OnWineCreated([EventMessage] Wine wine) => wine;

    [Subscribe]
    [Topic("wine.update")]
    public Wine OnWineUpdated([EventMessage] Wine wine) => wine;

    [Subscribe]
    [Topic("wine.delete")]
    public Guid OnWineDeleted([EventMessage] Guid productGuid) => productGuid;
}