namespace product_update_service.GraphQL.Types
{
public class MutationType : ObjectType<Mutation>
{
    protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor
            .Field(f => f.CreateWine(default!))
            .Argument("wine", a => a.Type<WineInputType>())
            .Type<WineType>();
    }
}
}