using product_update_service.Entities;
using product_update_service.Repositories;

namespace product_update_service.GraphQL.Types
{
public class Mutation
{
    private readonly IProductService _productService;

    public Mutation(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Wine> CreateWine(Wine wine)
    {
        return await _productService.CreateWineAsync(wine);
    }
}
}