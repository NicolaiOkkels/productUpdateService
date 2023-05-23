namespace product_update_service.GraphQL.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(f => f.GetWinesAsync(default!))
                .Type<ListType<WineType>>();
            descriptor
                .Field(f => f.GetWine(default!, default!))
                .Type<WineType>();
            //descriptor
           //.Field(f => f.SearchWinesByCategoryAsync(default!, default!))
           //.Type<ListType<WineType>>();
        }
    }
}