public class Mutation
{
    private readonly IProductService _productService;

    public Mutation(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Wine> CreateWineAsync(Wine input)
    {
        return await _productService.CreateWineAsync(input);
    }

    public async Task<Wine> UpdateWineAsync(Guid id, Wine input)
    {
        return await _productService.UpdateWineAsync(id, input);
    }

    public async Task DeleteWineAsync(Guid id)
    {
        await _productService.DeleteWineAsync(id);
    }
}