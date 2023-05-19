using product_update_service.Entities;

namespace product_update_service.GraphQL.Types
{

public class WineType : ObjectType<Wine>
{
    protected override void Configure(IObjectTypeDescriptor<Wine> descriptor)
    {
        descriptor.Field(w => w.Id).Type<NonNullType<IdType>>();
        descriptor.Field(w => w.ProductGuid).Type<NonNullType<UuidType>>();
        descriptor.Field(w => w.Name).Type<NonNullType<StringType>>();
        descriptor.Field(w => w.Description).Type<StringType>();
        descriptor.Field(w => w.Price).Type<NonNullType<DecimalType>>();
        descriptor.Field(w => w.Origin).Type<StringType>();
        descriptor.Field(w => w.AlcoholPercentage).Type<FloatType>();
        descriptor.Field(w => w.Year).Type<IntType>();
        descriptor.Field(w => w.Image).Type<ByteArrayType>();
        descriptor.Field(w => w.Size).Type<StringType>();
        descriptor.Field(w => w.CategoryId).Type<NonNullType<IntType>>();
        descriptor.Field(w => w.ModifiedDate).Type<NonNullType<DateTimeType>>();
    }
}
}